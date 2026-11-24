using System.Text;
using Corrugator.Api.Middleware;
using Corrugator.Api.Security;
using Corrugator.Api.Security;
using Corrugator.Application;
using Corrugator.Application.Abstractions;
using Corrugator.Application.Services;
using Corrugator.Infrastructure.MultiLine;
using Corrugator.Infrastructure.Options;
using Corrugator.Infrastructure.SqlSugar;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SqlSugar;

var builder = WebApplication.CreateBuilder(args);

// ---------- 配置 ----------
builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection("Database"));
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

// ---------- 基础服务 ----------
builder.Services.AddControllers().AddJsonOptions(options =>
{
    // 保持 PascalCase，前后端字段名与数据字典列名一致，便于对照
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

// ---------- TLS 策略 ----------
// 内网 HMI 与 API 之间默认走明文 HTTP；任何 HTTPS 端点（开发证书 / 后续反代）
// 只允许 TLS 1.2 / 1.3，禁止协商 TLS 1.0 / 1.1（旧协议会被运行时打安全警告）。
builder.WebHost.ConfigureKestrel(kestrel =>
{
    kestrel.ConfigureHttpsDefaults(https =>
    {
        https.SslProtocols = System.Security.Authentication.SslProtocols.Tls12
                             | System.Security.Authentication.SslProtocols.Tls13;
    });
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "瓦楞纸板生产线生管系统 API",
        Version = "v1",
        Description = "IPS 数据库（155 张表）的 .NET 8 + SqlSugar 后端接口",
    });

    var scheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "请输入 Bearer {token}",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
    };

    options.AddSecurityDefinition("Bearer", scheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement { [scheme] = Array.Empty<string>() });
});

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// ---------- 应用层 / 数据访问层 ----------
builder.Services.AddApplication();
builder.Services.AddCorrugatorData();
builder.Services.AddScoped<IUserContext, HttpUserContext>(); // 覆盖 Infrastructure 的默认实现
builder.Services.AddScoped<ILineContext, HttpLineContext>();  // 覆盖 Infrastructure 的 NullLineContext
builder.Services.AddSingleton<JwtTokenService>();

// ---------- 认证授权 ----------
var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>() ?? new JwtOptions();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret)),
            ClockSkew = TimeSpan.FromMinutes(2),
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

// ---------- 管道 ----------
app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<LineContextMiddleware>(); // 解析 X-Line-Code，决定本次请求走哪条瓦线库

if (app.Environment.IsDevelopment() || builder.Configuration.GetValue<bool>("EnableSwagger"))
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Corrugator API v1"));
}

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "Corrugator IPS API is running. Swagger: /swagger");

// ---------- 启动初始化 ----------
using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>().CreateLogger("Startup");
    var dbOptions = scope.ServiceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;
    var provider = scope.ServiceProvider.GetRequiredService<LineDbProvider>();
    var lineContext = scope.ServiceProvider.GetRequiredService<ILineContext>();

    // 先读 TB_Line，拿到全部线路；单线部署时退化为一条默认线
    var specs = await provider.GetSpecsAsync();

    if (dbOptions.AutoCreateTables)
    {
        foreach (var spec in specs)
        {
            lineContext.Set(spec.Code);
            try
            {
                SqlSugarServiceCollectionExtensions.InitTables(provider.Get(spec.Code), logger);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "线路 {Line} 自动建表失败，请改用 db/sqlserver_schema.sql 手工初始化", spec.Code);
            }
        }

        // 账号/角色/权限（BaseDB 公共表）只在公共库建一次，不复制到各瓦线库
        try
        {
            SqlSugarServiceCollectionExtensions.InitBaseTables(provider.GetBase(), logger);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "公共库（W_Users 等）建表失败，请用 db/sqlserver_basedb_schema.sql 手工初始化");
        }
    }

    if (dbOptions.SeedData)
    {
        try
        {
            await scope.ServiceProvider.GetRequiredService<IAuthService>().EnsureSeedAsync();
            logger.LogInformation("公共库内置账号初始化完成（admin / planner / operator）");
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "内置账号初始化失败：{Reason}（先按 db/sqlserver_fix_seed_columns.sql 检查 W_Users/W_Roles/W_Permissions 列宽）", ex.Message);
        }
    }

    lineContext.Set(null);
}

app.Run();
