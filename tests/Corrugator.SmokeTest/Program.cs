using Corrugator.Application;
using Corrugator.Application.Abstractions;
using Corrugator.Application.Services;
using Corrugator.Domain.Common;
using Corrugator.Domain.Entities;
using Corrugator.Domain.Entities.MasterData;
using Corrugator.Domain.Entities.Process.Dry;
using Corrugator.Domain.Entities.Production;
using Corrugator.Domain.Entities.System;
using Corrugator.Infrastructure.Options;
using Corrugator.Infrastructure.SqlSugar;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Alarms;
using Corrugator.Shared.Contracts.Orders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SqlSugar;

// 用 SQLite 跑一遍仓储层 + 服务层的真实读写，验证仓储模式可用
var dbFile = Path.Combine(AppContext.BaseDirectory, "smoke.db");
if (File.Exists(dbFile))
{
    File.Delete(dbFile);
}

var services = new ServiceCollection();
services.AddLogging();
services.Configure<DatabaseOptions>(o =>
{
    o.Provider = "Sqlite";
    o.ConnectionString = $"Data Source={dbFile}";
    o.SeedData = false;
    o.AutoCreateTables = false;
});
services.AddApplication();
services.AddCorrugatorData();

await using var provider = services.BuildServiceProvider();
var db = provider.GetRequiredService<ISqlSugarClient>();
var logger = provider.GetRequiredService<ILoggerFactory>().CreateLogger("smoke");

// 只建冒烟测试涉及的表
db.CodeFirst.InitTables(
    typeof(Sys_User), typeof(W_Orders), typeof(W_OrderFinishs), typeof(W_Alarms),
    typeof(W_ProductWaves), typeof(W_QDM_FormSetFactor));

Console.WriteLine("建表完成");

using var scope = provider.CreateScope();
var sp = scope.ServiceProvider;
var auth = sp.GetRequiredService<IAuthService>();
var orders = sp.GetRequiredService<IOrderService>();
var alarms = sp.GetRequiredService<IAlarmService>();
var process = sp.GetRequiredService<IProcessParamService>();
var dash = sp.GetRequiredService<IDashboardService>();

// 1) 种子账号 + 登录
await auth.EnsureSeedAsync();
var login = await auth.LoginAsync(new Corrugator.Shared.Auth.LoginRequest { UserName = "admin", Password = "123456" });
Console.WriteLine($"1) 登录成功：{login.DisplayName} / {login.Role}");

// 2) 新增订单
var created = await orders.CreateAsync(new OrderInput
{
    WO_WorkNo = 101,
    WO_PaperCode = "K=A",
    WO_Wave = "BC",
    WO_Width = 1600,
    WO_CutLength = 1200,
    WO_CutQty = 50,
    WO_CustName = "测试纸箱厂",
    WO_Speed = 130,
    WO_ScorDeep = 2,
    WO_Trim = 20,
    WO_OrderDate = DateTime.Now,
});
Console.WriteLine($"2) 新增订单 ID={created.WO_ID} 状态={created.Status}");

// 3) 分页查询
var page = await orders.GetPagedAsync(new OrderQuery { PageIndex = 1, PageSize = 10 });
Console.WriteLine($"3) 分页：Total={page.Total} 本页={page.Items.Count}");

// 4) 修改
created.WO_Speed = 150;
var updated = await orders.UpdateAsync(new OrderInput
{
    WO_ID = created.WO_ID,
    WO_WorkNo = created.WO_WorkNo,
    WO_PaperCode = created.WO_PaperCode,
    WO_Wave = created.WO_Wave,
    WO_Width = created.WO_Width,
    WO_CutLength = created.WO_CutLength,
    WO_CutQty = 60,
    WO_Speed = 150,
    WO_ScorDeep = 2,
});
Console.WriteLine($"4) 修改后：切数={updated.WO_CutQty} 限速={updated.WO_Speed}");

// 5) 删除（W_Orders 的业务软删除 WO_IsDel）
await orders.DeleteAsync(created.WO_ID);
var afterDelete = await orders.GetPagedAsync(new OrderQuery());
Console.WriteLine($"5) 删除后可查条数={afterDelete.Total}");

// 6) 工艺参数（192 列宽表按 Key 读写）
var factors = await process.GetFactorsAsync();
Console.WriteLine($"6) 工艺参数项数={factors.Count}，示例={factors.FirstOrDefault()?.Key}={factors.FirstOrDefault()?.Value}");
await process.UpdateFactorAsync(new Corrugator.Shared.Contracts.Process.ProcessFactorUpdateDto
{
    Key = "WF_Glue_GU_1st_Form_Factor",
    Value = 3.5m,
});
var after = await process.GetFactorsAsync("WF_Glue_GU_1st_Form_Factor");
Console.WriteLine($"6) 修改后 WF_Glue_GU_1st_Form_Factor={after.FirstOrDefault()?.Value}");

// 7) 告警确认
var alarmRepo = sp.GetRequiredService<IRepository<W_Alarms>>();
await alarmRepo.InsertAsync(new W_Alarms
{
    WA_PartCode = "P01",
    WA_ReasonCode = "R01",
    WA_FirstSendTime = DateTime.Now,
    WA_LastSendTime = DateTime.Now,
    WA_SendNum = 3,
    WA_IsConfirm = false,
});
var alarmPage = await alarms.GetPagedAsync(new AlarmQuery());
var first = alarmPage.Items.First();
await alarms.ConfirmAsync(first.WA_ID, new AlarmConfirmInput { ReviewNote = "已处理" });
Console.WriteLine($"7) 告警：共 {alarmPage.Total} 条，确认第一条后 ConfirmBy={ (await alarms.GetPagedAsync(new AlarmQuery())).Items.First().WA_ConfirmBy }");

// 8) 看板聚合
var overview = await dash.GetOverviewAsync();
Console.WriteLine($"8) 看板：在制={overview.ActiveOrders} 插单={overview.UrgentOrders} 未确认告警={overview.UnconfirmedAlarms}");

// 9) 软删除（Sys_User 实现 ISoftDelete）
var userRepo = sp.GetRequiredService<IRepository<Sys_User>>();
var adminUser = await userRepo.FirstAsync(u => u.UserName == "planner");
Console.WriteLine($"9) planner 存在={adminUser is not null}，审计 CreatedBy={adminUser?.CreatedBy}");
if (adminUser is not null)
{
    await userRepo.DeleteAsync(adminUser.Id);
    var stillThere = await userRepo.FirstAsync(u => u.UserName == "planner");
    Console.WriteLine($"9) 软删除后 planner 查询结果={(stillThere is null ? "已过滤（符合预期）" : "仍存在（异常）")}");
}

Console.WriteLine("冒烟测试结束");
