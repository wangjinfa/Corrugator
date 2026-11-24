# 瓦楞纸板生产线生管与工艺参数系统

基于 **WPF + .NET 8 + SqlSugar + 仓储模式 + 后端 API** 的分层解决方案，按企业现有 **IPS 数据库数据字典（155 张表 / 2296 个字段）** 建模，覆盖瓦楞纸板生产线的生管排程、工艺参数、告警复核三条主线。

数据库目标为 **SQL Server**（原库是 PostgreSQL 15.12 的 IPS 库）。

---

## 一、目录结构

```
Corrugator.sln
├─ src/
│  ├─ Corrugator.Shared/         # 共享契约：DTO / 分页 / 统一返回 / 登录契约（被 Api 与 WPF 共用）
│  ├─ Corrugator.Domain/         # 领域实体：155 张 IPS 表 + 2 张自建表，SqlSugar 实体特性
│  ├─ Corrugator.Application/    # 业务层：服务接口与实现、仓储接口、事务接口、密码哈希、异常
│  ├─ Corrugator.Infrastructure/ # 数据访问：SqlSugar 配置、BaseRepository、UnitOfWork
│  ├─ Corrugator.Api/            # .NET 8 WebAPI：JWT 认证、Swagger、控制器
│  └─ Corrugator.Client.Wpf/     # WPF 客户端：MVVM（Prism 9 + Unity）+ DI
├─ db/
│  └─ sqlserver_schema.sql       # 155 张表的 SQL Server 建表脚本（幂等）
├─ tools/
│  ├─ parse_dd.py                # 数据字典 PDF 解析器（输出 schema.json）
│  ├─ gen_code.py                # 由 schema.json 生成实体类与建表脚本
│  ├─ gen_registry.py            # 生成 EntityRegistry.cs（供 CodeFirst 一键建表）
│  └─ schema.json                # 结构化 schema（唯一数据来源）
└─ tests/
   └─ Corrugator.SmokeTest/      # 冒烟测试：用 SQLite 跑通仓储 + 服务（无需装 SQL Server）
```

分层依赖方向：`Api → Application → Domain`，`Infrastructure → Application`，`WPF → Shared`。
Api 只依赖应用层接口，实体与 ORM 细节不下渗到控制器。

---

## 二、数据字典 → SQL Server 建模

解析链路（可重跑）：

```bash
python3 tools/parse_dd.py     # DataDictionary.pdf → tools/schema.json
python3 tools/gen_code.py     # schema.json → 实体类 + db/sqlserver_schema.sql
python3 tools/gen_registry.py # schema.json → Domain/Entities/EntityRegistry.cs
```

**类型映射**（PostgreSQL → SQL Server）：

| PostgreSQL | SQL Server | 说明 |
|---|---|---|
| varchar(n) | nvarchar(n) | 中文注释多，统一 Unicode |
| text | nvarchar(max) | |
| int4 / int8 | int / bigint | |
| bool | bit | |
| timestamp(6) | datetime2(6) | |
| numeric(p,s) | decimal(p,s) | 未标精度按 decimal(18,4) |
| float8 | float | |
| uuid | uniqueidentifier | |

**主键规则**：数据字典中每张表恰好有 1 列带 `nextval` 默认值，即自增主键；生成实体时标 `IsPrimaryKey = true, IsIdentity = true`，建表脚本对应 `IDENTITY(1,1)` + 主键约束。

**表注释与列注释**：全部写入 `[SugarTable(TableName="...", TableDescription="...")]` 与 `[SugarColumn(ColumnDescription="...")]`。这些中文说明是运行时可见的元数据，"工艺参数"页面就是靠它把 192 列宽表翻译成中文参数名的。

**模块划分**（按表前缀，便于按产线部位找人）：

| 目录 | 代表表 |
|---|---|
| `Entities/Production` | W_Orders（未完工）、W_OrderFinishs（完工）、W_Alarms（告警） |
| `Entities/Process/Wet` | 糊机、预热缸、喷雾、单面机等湿部参数 |
| `Entities/Process/Dry` | TB_QDM_FormSetFactor（工艺系数总表，192 列）、热板、堆码 |
| `Entities/Process/Common` | 修边、纸板、楞型组合等通用工艺 |
| `Entities/MasterData` | S_ProductWaves（楞型资料）、S_PaperCodes（材质）、S_AlarmParts / Reasons |
| `Entities/Plc` / `Pms` | PLC 点位、驱动与产线参数 |
| `Entities/Erp` / `Logging` / `History` / `Dictionary` | ERP 接口、日志、历史、数据字典表 |

---

## 三、仓储模式（本项目核心设计）

### 3.1 一份实现服务 155 张表

155 张表的 CRUD 不需要写 155 个仓储。`IRepository<T>` + `BaseRepository<T>` 用泛型统一实现，通过 SqlSugar 的 `EntityMaintenance.GetEntityInfo<T>()` 在运行时拿到主键、列名、自增信息：

```csharp
public interface IRepository<T> where T : class, new()
{
    ISugarQueryable<T> Queryable { get; }              // 逃生门：复杂查询直接用 ISugarQueryable
    Task<T?> GetByIdAsync(object id);
    Task<T?> FirstAsync(Expression<Func<T, bool>> where);
    Task<List<T>> ListAsync(Expression<Func<T,bool>>? where = null, string? orderBy = null, int? top = null);
    Task<PagedResult<T>> PageAsync(Expression<Func<T,bool>>? where, PageQuery page, string? defaultOrderBy = null);
    Task<int> CountAsync(Expression<Func<T,bool>>? where = null);
    Task<bool> ExistsAsync(Expression<Func<T,bool>> where);
    Task<int> InsertAsync(T entity);
    Task<int> InsertRangeAsync(IEnumerable<T> entities);
    Task<int> UpdateAsync(T entity);
    Task<int> UpdateRangeAsync(IEnumerable<T> entities);
    Task<int> DeleteAsync(object id);
    Task<int> DeleteAsync(Expression<Func<T,bool>> where);
    Task<int> SaveAsync(T entity);                     // 主键有值→更新，无值→插入
}
```

服务层注入即可：

```csharp
public class OrderService : IOrderService
{
    public OrderService(IRepository<W_Orders> orders, IRepository<W_OrderFinishs> finished, IUserContext user) { }
}
```

### 3.2 四个统一处理（这是自己做仓储最容易漏的地方）

1. **自增主键回填**：`InsertAsync` 走 `ExecuteReturnEntityAsync()` 并把生成的 Id 写回实体，业务层 `new` 完直接 `Insert` 就能拿到 `WO_ID`，不用再查一次。
2. **软删除过滤**：实体实现 `ISoftDelete`（`IsDeleted` 列）时，所有查询自动带 `Where("IsDeleted = 0")`，删除自动改写为置位更新。未实现的表走物理删除。
   注意：`W_Orders` 的软删除列是业务列 `WO_IsDel`（IPS 原有口径），由 `OrderService` 显式处理，与框架层的 `IsDeleted` 是两套语义，不要混。
3. **审计字段**：实体实现 `IAuditable`（`CreatedAt/CreatedBy/UpdatedAt/UpdatedBy`）时，插入/更新自动填充，用户名取自 `IUserContext`（API 侧实现为从 JWT 取，控制台/测试侧为 `NullUserContext`）。
4. **排序白名单**：分页排序的 `OrderBy` 来自前端，`BaseRepository` 用实体列名做白名单校验，只放行真实存在的列，防止把任意 SQL 片段拼进 ORDER BY。

### 3.3 事务

```csharp
await _uow.BeginAsync();
try
{
    await _orders.InsertAsync(entity);
    await _finished.InsertAsync(record);
    await _uow.CommitAsync();
}
catch { await _uow.RollbackAsync(); throw; }
```

`UnitOfWork` 基于 `_db.AsTenant().BeginTran()/CommitTran()/RollbackTran()`，内部嵌套深度计数，只有最外层真正提交（服务之间互相调用不会提前提交）。
（踩坑记录：`ISqlSugarClient` 上没有 `BeginTran()`，必须通过 `AsTenant()` 走租户事务，否则 CS1061。）

### 3.4 宽表策略：TB_QDM_FormSetFactor（192 列）

这张表存当前运行的各类 QMD 系数（糊机胶水、烘缸包角、张力、喷雾…），192 列逐个建 DTO 既冗长又容易随 IPS 升级失效。做法是 **元数据驱动键值化**：

- `ProcessParamService.GetFactorsAsync()` 用反射读取实体列 + `ColumnDescription`，输出 `{Key, Name(中文), Value, IsOpen}`；
- 前端只按 `Key` 读写，IPS 以后新增系数列，前端无需改动；
- 表无记录时仍返回全部 192 项（值为空），保存时 `createIfMissing` 自动建首行。

注意：不要把 `TB_QDM_FormSetFactor` 的字段注释清理掉，中文说明就是界面的参数名。

---

## 四、后端 API

- 框架：.NET 8 WebAPI + JWT（`Microsoft.AspNetCore.Authentication.JwtBearer`）+ Swagger
- 统一返回：`ApiResult<T>`（`Code / Message / Data / Success`），异常由 `ExceptionMiddleware` 兜底转成 `Code=5000`
- JSON 命名：`PropertyNamingPolicy = null`，保持 **PascalCase**，与数据字典列名（`WO_Width`）一致，便于前后端对照排查
- 认证：除 `POST /api/auth/login` 外全部要 `Bearer Token`

| 方法 | 路径 | 说明 |
|---|---|---|
| POST | `/api/auth/login` | 登录，返回 JWT + 用户信息 |
| GET | `/api/auth/me` | 当前用户 |
| GET | `/api/orders` | 未完工订单分页（`PageIndex/PageSize/Keyword/Wave/OnlyUrgent`） |
| GET | `/api/orders/finished` | 完工订单分页 |
| GET | `/api/orders/{id}` | 订单详情 |
| POST | `/api/orders` | 新增订单（NOT NULL 列已由服务层补默认值） |
| PUT | `/api/orders/{id}` | 修改订单 |
| DELETE | `/api/orders/{id}` | 业务软删除（写 `WO_IsDel=true`） |
| GET | `/api/process-params/waves` | 楞型/门幅工艺资料分页 |
| GET | `/api/process-params/factors` | 工艺系数（192 项，支持 `keyword` 过滤中文名/键名） |
| PUT | `/api/process-params/factors` | 修改单项系数 |
| PUT | `/api/process-params/factors/batch` | 批量修改系数 |
| GET | `/api/alarms` | 告警历史分页 |
| POST | `/api/alarms/{id}/confirm` | 告警确认（写确认人/复核说明） |
| GET | `/api/dashboard/overview` | 看板聚合：在制单数、插单数、今日完工单数/米数、未确认告警 |
| GET | `/api/dictionary/types` | 数据字典类型 |
| GET | `/api/dictionary/types/{typeId}/data` | 字典明细 |

Swagger：`http://localhost:5099/swagger`

---

## 五、WPF 客户端

- 框架：WPF（`net8.0-windows`）+ **Prism 9.0.537（Prism.Wpf / Prism.Unity）**，DI 用 Prism 内置 Unity 容器
- 结构：`Views`（窗口/页面）/ `ViewModels`（属性与命令）/ `Services`（`ApiClient`、`AppSession`、`AppConfig`）/ `Converters`
- `ApiClient` 统一封装：自动带 Token、自动解析 `ApiResult`、把 401/超时/连接失败转成可直接展示的中文提示，ViewModel 里只有一行 `await _api.GetAsync<OrderDto>("api/orders/1")`
- 界面风格：按现场 IPS「图形化控制」主界面复刻（深藏青顶栏 `#132136` + 图标式页签 + 浅灰工作区），主题集中在 `App.xaml`（`NavTabItem` / `CardBorder` / `ChipBorder` / 全局 DataGrid 深蓝表头 / 行色 `RowNavy` `RowOrange` `RowYellow`）。改造前后的对照预览见 `design/ui-preview.png`。
- 顶栏壳：`MainWindow.xaml` 用自定义 `TabControl` 模板（Row 64）：圆角齿轮 logo、`TabPanel` 图标页签（选中态浅一档底 + 底部蓝线 + 文字转白）、右侧「复位 / 本班：B / Line1 / CCC·服务端指示灯 / V 1.0.0.0 · 用户 · 时间（每秒刷新）」。
- 页面（7 个页签，切页即刷新，登录后先加载前 3 个）：

| 页签 | 内容 |
|---|---|
| 生管控制 | 在制/插单/今日完工单数/完工米数/未确认告警 5 张指标卡 + 当前排程列表 |
| 图形化控制 | **现场主界面复刻**：左列「湿部·单面机 SF1」「双面机组 SF2」两张机台示意卡（原纸架/预热缸/瓦楞辊/天桥 → 糊机/热板/冷却/纵切/横切/堆码，金色纸幅 + 蓝色参数块 + 上弯/下弯轻中重开关），右列 0–400 m/min 速度仪表 + 趋势线 + 「当前订单备注」本班/本单 10 列指标（总长/生产/剩余/平方/均速/不良率/修边率/生产时间/停机时间/停次）+ 汇总行 + 彩条排程工单表（当前生产深蓝 → 插单橙 `#F2811E` → 待生产黄 `#FFDD7B` → 普通白） |
| 工单管理 | 关键字与楞型筛选、分页、DataGrid、新增订单表单、删除（软删除） |
| 预警管理 | 告警历史列表 + 复核说明 + 确认 |
| 报表管理 | 完工记录按楞型汇总（单数 / 米数 / 平均线速 / 最后完工时间）+ 顶部汇总卡 |
| 基础信息 | 左 `P_DictTypes` 类型树、右 `P_DictDatas` 明细（选中类型自动加载） |
| QDM基础表 | 192 项工艺系数列表，选中后右侧改值保存 |

- 图形化控制页的数据来源（`ViewModels/GraphicControlViewModel.cs`）：

| 界面元素 | 来源 |
|---|---|
| 排程工单表、门幅/切长/切宽/修边/排程米数、汇总行「总计剩余 / 当前剩余 / 预计时间 / 选中订单总长」 | `GET /api/orders`（`WO_ScheduleMeter` 缺失时用 `WO_CutLength × WO_CutQty ÷ 1000` 兜底） |
| 速度仪表、本班生产米数/均速/班次单数、平方 | `GET /api/dashboard/overview` |
| 参数块「胶量 / 糊量」 | `GET /api/process-params/factors` 的 `F_Glue_GU_1st_Form_Factor` / `F_Glue_GU_0_Form_Factor` |

> 说明：弯曲辊轻/中/重开关、热板温度、实际线速、不良率/修边率/停机时间与停次属于 **PLC 实时点位**，当前未接 PLC 网关（`VW_Plc_PointData` 视图也未迁移），界面先展示工艺设定值与排程数据，这几项显示占位值 `0`。接入 OPC UA / PLC 采集后，只需在 `GraphicControlViewModel` 里把这些属性改为订阅推送，XAML 不用动。

- 登录窗口用 `PasswordBox`（不走绑定，`LoginWindow` 里把密码传给 ViewModel），登录成功后由 `App.Services` 解析出单例 `MainViewModel` 交给 `MainWindow`。

---

## 六、运行步骤

### 1. 准备数据库（SQL Server）

```sql
CREATE DATABASE IPS;
GO
```

用 SSMS 或 sqlcmd 执行 `db/sqlserver_schema.sql`（脚本幂等，`IF OBJECT_ID(...) IS NULL` 包裹，可重复执行）：

```bash
sqlcmd -S localhost -U sa -P 'YourStrong!Passw0rd' -d IPS -i db/sqlserver_schema.sql
```

也可以用代码优先：把 `appsettings.json` 的 `AutoCreateTables` 设为 `true`，启动时按实体建表（逐张建、单张失败不影响其余表，失败清单会打到日志）。

### 2. 配置 API

`src/Corrugator.Api/appsettings.json`：

```json
{
  "Database": {
    "Provider": "SqlServer",
    "ConnectionString": "Server=localhost;Database=IPS;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;Encrypt=False;MultipleActiveResultSets=True",
    "AutoCreateTables": false,
    "SeedData": true,
    "SlowSqlThresholdMs": 1000
  },
  "Jwt": {
    "Secret": "改成你自己的 32 位以上密钥",
    "Issuer": "Corrugator.Api",
    "Audience": "Corrugator.Client",
    "ExpireMinutes": 480
  }
}
```

`Provider` 支持 `SqlServer`（默认）/ `Sqlite` / `MySql` / `PostgreSQL`，本地没数据库时可用 `Sqlite` 先跑通。

### 3. 启动

```bash
dotnet build Corrugator.sln
dotnet run --project src/Corrugator.Api/Corrugator.Api.csproj      # 默认 5099
dotnet run --project src/Corrugator.Client.Wpf/Corrugator.Client.Wpf.csproj   # 需在 Windows 上运行
```

内置账号（首次启动自动写入 `Sys_Users`，密码 PBKDF2-SHA256 加盐存储）：

| 账号 | 密码 | 角色 |
|---|---|---|
| admin | 123456 | 系统管理员 |
| planner | 123456 | 排产员 |
| operator | 123456 | 操作工 |

### 4. 自测（不需要 SQL Server）

```bash
dotnet run --project tests/Corrugator.SmokeTest/Corrugator.SmokeTest.csproj
```

覆盖：建表、种子账号与登录、订单增/改/分页/软删除、工艺系数读写、告警确认、看板聚合、`ISoftDelete` 过滤与审计字段。

已知限制：SQLite 要求自增主键必须是 `INTEGER PRIMARY KEY`，因此 18 张 `bigint` 自增主键表（`T_Cruise_ReasonLog`、`TB_Plc_*`、`TB_IPS_*` 等）在 SQLite 下建不出来；**SQL Server 无此限制，建表脚本与 CodeFirst 都正常**。

---

## 七、二次开发指南

**加一张业务表**：`schema.json` 里加表 → 重跑 `gen_code.py` + `gen_registry.py` → 重新执行建表脚本（或开 `AutoCreateTables`）。生成器只清理它自己管理的模块目录，`Entities/System/Sys_User.cs` 等手写文件不会被覆盖。

**加一个接口**：Application 层写服务接口 + 实现（注入 `IRepository<T>`）→ `DependencyInjection` 注册 → Api 层加控制器方法 → Shared 层补 DTO。

**加一个页面**：WPF 侧 `Views/*.xaml` + `ViewModels/*ViewModel.cs` → `App.xaml.cs` 注册 VM → `MainWindow` 加 `TabItem` 并在 `OnTabChanged` 里挂刷新。

---

## 八、当前范围与后续建议

已完成：155 张表实体化与建表脚本、仓储/事务/审计/软删除、登录与 JWT、订单、工艺参数、告警、看板、字典共 17 个接口、WPF 四个业务页面、SQLite 冒烟测试、Linux 环境下全解决方案编译通过（WPF 用 `EnableWindowsTargeting` 做编译校验，运行需 Windows）。

尚未纳入（IPS 中还有 4 个视图 + 6 个函数）：

| 对象 | 用途 | 建议 |
|---|---|---|
| `V_Orders` / `V_FinishOrders` | 订单视图 | 报表口径，可在 SQL Server 侧重建视图，或由 `IRepository.Queryable` 直接组合 |
| `VW_Plc_PointData` / `VW_Plc_PointDataBase` | PLC 点位数据 | 实时采集链路对接时再处理 |
| `P_GetDetailForReport` / `P_GetFinshOrdersNew` | 报表存储过程 | 需先拿到原报表口径再改写为 SQL Server 存储过程 |
| `P_ClearOrderCache` / `P_UpdateOrderEstFinshTime` / `fn_insert_erp_paper` / `fn_monitor_order_change` | 缓存清理、预计完工时间、ERP 进纸、订单变更监控 | 后两个是 ERP 接口逻辑，建议先与原 IPS 维护方核对 |

另外建议优先确认的三件事：① 报表口径（谁在用哪张视图）；② ERP 进纸接口的调用频次与幂等要求；③ 现场 SQL Server 版本（决定 `datetime2` 精度与索引可用性）。

---

## 九、启动报错排查（重要）

### 1. 「由于应用程序配置不正确，未能启动此应用程序」

这是 **Windows 加载器解析 exe 内嵌清单（RT_MANIFEST）失败** 的经典报错（事件查看器 → Windows 日志 → 应用程序 → 来源 `SideBySide` 会看到对应记录），与业务代码、数据库无关。

本项目早期版本的 `app.manifest` 根节点命名空间误写成了 XAML 命名空间：

```xml
<!-- 错误：manifest 不能使用 XAML 命名空间 -->
<manifest xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" ...>
```

正确写法必须是清单命名空间 + 完整程序集声明（现版本已修正）：

```xml
<?xml version="1.0" encoding="utf-8"?>
<assembly manifestVersion="1.0" xmlns="urn:schemas-microsoft-com:asm.v1">
  <assemblyIdentity version="1.0.0.0" name="Corrugator.Client.app" type="win32" />
  <application xmlns="urn:schemas-microsoft-com:asm.v3">
    <windowsSettings>
      <dpiAware xmlns="http://schemas.microsoft.com/SMI/2005/WindowsSettings">true</dpiAware>
      <dpiAwareness xmlns="http://schemas.microsoft.com/SMI/2016/WindowsSettings">PerMonitorV2</dpiAwareness>
    </windowsSettings>
  </application>
  <compatibility xmlns="urn:schemas-microsoft-com:compatibility.v1">
    <application>
      <supportedOS Id="{8e0f7a12-bfb3-4fe8-b9a5-48fd50a15a9a}" />
      <supportedOS Id="{1f676c76-80e1-4239-95bb-83d0f6d0da78}" />
    </application>
  </compatibility>
</assembly>
```

**改完必须重新编译**（清单是在编译期嵌进 exe 的，换 exe 不是换 dll）：

```powershell
dotnet build src/Corrugator.Client.Wpf/Corrugator.Client.Wpf.csproj -c Release
```

校验是否嵌对：用记事本/资源查看器打开 `bin\Release\net8.0-windows\Corrugator.Client.exe` 的 RT_MANIFEST，根节点应为 `<assembly ... xmlns="urn:schemas-microsoft-com:asm.v1">`。

### 1.1 项目名不叫 exe 名（很容易点错文件）

`src/Corrugator.Client.Wpf` 是**项目名**，但 csproj 里 `<AssemblyName>Corrugator.Client</AssemblyName>` 覆盖了产物名，所以编译出来的是 **`Corrugator.Client.exe`**，不是 `Corrugator.Client.Wpf.exe`。

| 项目 | 产物 |
|---|---|
| `src/Corrugator.Client.Wpf`（WPF 客户端） | `bin\<Configuration>\net8.0-windows\Corrugator.Client.exe` |
| `src/Corrugator.Api`（后端） | `dotnet run --project src/Corrugator.Api` |

想一条命令完成「查运行时 → 编译 → 校验清单 → 启动」，用仓库自带脚本：

```powershell
powershell -ExecutionPolicy Bypass -File tools\run-client.ps1
# 或 Debug 配置
powershell -ExecutionPolicy Bypass -File tools\run-client.ps1 -Configuration Debug
```

脚本会先确认 `Microsoft.WindowsDesktop.App 8.x` 是否存在，再编译、检查 exe 里的清单是否是 `urn:schemas-microsoft-com:asm.v1`，最后拉起 `Corrugator.Client.exe`。清单报错时它会直接指出是「清单不对」还是「缺桌面运行时」，省得两头猜。

### 2. 「缺少 .NET / 提示安装运行时」

WPF 需要 **Microsoft.WindowsDesktop.App 8.x**，只有 `Microsoft.NETCore.App` 或 ASP.NET Core Runtime 是不够的。检查本机：

```powershell
dotnet --list-runtimes
# 必须能看到 Microsoft.WindowsDesktop.App 8.0.x
```

缺就装 **Windows Desktop Runtime 8（x64）**；或者直接用自包含发布，彻底不依赖本机运行库：

```powershell
dotnet publish src/Corrugator.Client.Wpf/Corrugator.Client.Wpf.csproj -c Release -r win-x64 --self-contained true -o publish\client
```

`publish\client\Corrugator.Client.exe` 双击即用（整个目录一起拷贝，不要只拷 exe）。客户端默认连 `http://localhost:5099`，现场改 `Services/AppConfig.cs` 的 `BaseUrl` 后重新编译。

### 3. 其它常见原因

| 现象 | 原因与处理 |
|---|---|
| 双击无反应/闪退 | 先启动 API（`dotnet run --project src/Corrugator.Api`）；客户端登录失败会停在登录窗口但不会闪退，闪退请看事件查看器 `.NET Runtime` 条目 |
| 提示找不到 `Corrugator.Shared.dll` | 只拷了 exe；要拷整个输出目录 |
| 32/64 位混用 | x64 客户端配 x64 运行库；用 `-r win-x64` 发布最省事 |
| 老系统（Win7/8） | .NET 8 最低要求 Windows 10 1809；Win7 需改用 net6.0/net48 方案，不能靠换 runtime 解决 |

---

## 十、BaseDB 基础库建表脚本（2026-11-13 版本字典）

`DataDictionary_20261113163611.pdf` 是**另一个库** `BaseDB` 的字典（不是 IPS 库）：PostgreSQL 15.12、schema public、**12 张表 + 1 个函数**，内容是账号/角色/权限、瓦线配置、日志与登录缓存等基础数据。

- 解析脚本：`tools/parse_basedb.py`（按 Navicat 版面「位置/名称/类型/Not Null/其它」还原，跳过封面与目录里重复的“表: xxx”行）
- 中间结果：`tools/schema_basedb.json`（12 表 / 76 字段）
- 建表脚本：`db/sqlserver_basedb_schema.sql`（幂等 `IF OBJECT_ID(...) IS NULL`，每表 1 个 IDENTITY 主键）

| 表 | 字段 | 主键 | 说明 |
|---|---|---|---|
| S_ApiUserMaps | 3 | SA_ID | 接口授权账号映射 |
| S_ApiUsers | 5 | SA_ID | 接口账号 |
| S_Apis | 4 | SA_ID | 接口清单（Path/Des/是否启用） |
| S_Permissions | 12 | SP_ID | 菜单功能权限 |
| S_Role_Permissions | 3 | SRP_ID | 角色-权限关联 |
| S_Roles | 8 | SR_ID | 角色 |
| S_User_Permissions | 3 | SUP_ID | 用户-权限关联 |
| S_User_Roles | 3 | SUR_ID | 用户-角色关联 |
| S_Users | 13 | SU_ID | 用户（账号/密码/姓名/手机/是否多厂） |
| TB_Line | 11 | F_ID | 瓦线配置（编码/连接串/服务端 IP 端口/ApiUrl/层数/门幅） |
| T_Log | 7 | Id（bigint） | 日志（Date/Thread/Level/Logger/Message/Exception） |
| T_UserLoginCache | 4 | F_ID | 登录缓存（账号/时间/IP） |

类型映射与 IPS 脚本一致：`varchar(n)->nvarchar(n)`、`text->nvarchar(max)`、`int4->int`、`int8->bigint`、`bool->bit`、`timestamp(6)->datetime2`、`nextval(...)->IDENTITY(1,1)`。

两点注意：

1. 12 张表名与 IPS 的 155 张**无重名**，两个脚本可以先后在同一个 SQL Server 库执行，不会互相覆盖。
2. 函数 `delete_old_log_data_batch`（清理历史日志，无参数）在 PDF 里只有元数据、没有函数体，**未迁移**。SQL Server 侧建议写成存储过程 + SQL Agent 作业定时执行，例如按 `T_Log.Date` 保留最近 N 天分批删除。

---

## 十一、多瓦线多库路由

现场有多条瓦线时，每条线一套业务库（IPS 那 155 张表），线路清单与连接串统一放 BaseDB 的 `TB_Line`，服务端按请求路由，客户端顶栏下拉选择当前瓦线。

### 1. 配置

```json
"Database": {
  "ConnectionString": "…（单线路时的库，也作为兜底）",
  "BaseConnectionString": "Server=localhost;Database=BaseDB;User Id=sa;…",   // 留空=线路配置就在当前库
  "DefaultLine": "",                                                          // 留空取 TB_Line 第一条
  "EnableMultiLine": true                                                     // false=全部走 ConnectionString
}
```

`TB_Line` 的关键列：`F_Code`（线路编码，请求头里用它）、`F_ConnectionString`（该线业务库连接串）、`F_ConfigID`（SqlSugar ConfigId，留空用 F_Code）、`F_ApiUrl`、`F_WaveLineLayer`、`F_DoorWidth`。示例数据见 `db/basedb_tb_line_sample.sql`。

### 2. 路由链路

```
WPF 顶栏下拉 → ApiClient 加请求头 X-Line-Code: Line1
  → LineContextMiddleware 校验线路存在，写入 ILineContext
  → ScopedLineDbAccess 按线路取 SqlSugarScope.GetConnection(ConfigId)
  → BaseRepository / UnitOfWork 用该库；事务也落在该库
```

- `LineRegistry`：读 `TB_Line` 并缓存；BaseDB 连不上、表不存在、没有有效行时**自动退化为单线路**，服务不会起不来。
- `LineDbProvider`：把 BaseDB + 每条线注册进一个 `SqlSugarScope`（ConfigId=线路），单例、线程安全；线路增删后调 `POST /api/lines/reload` 重建，无需重启。
- 连接串只在服务端流转，`GET /api/lines` 只返回编码/名称/层数/门幅/ApiUrl，不含密码。

### 3. 接口

| 方法 | 路径 | 说明 |
|---|---|---|
| GET | `/api/lines` | 线路列表（`IsDefault` 标记默认线） |
| POST | `/api/lines/reload` | 重新读 `TB_Line` 并重建多库路由 |
| 其它业务接口 | 带 `X-Line-Code` 头（或 `?line=`） | 落到对应瓦线库；不带则走默认线 |

### 4. 客户端

顶栏原「Line1」白框改为瓦线下拉（`ItemsSource=Lines`、`SelectedItem=SelectedLine`），切换即：
1. `ApiClient.SetLine(code)`，之后所有请求自动带 `X-Line-Code`；
2. 重新加载看板 / 图形化控制 / 工单三页数据。

登录后先 `GET /api/lines` 拿到线路列表并按 `IsDefault` 选中，再加载业务数据。

### 5. 已验证（SQLite 真实双库）

| 用例 | 结果 |
|---|---|
| BaseDB `TB_Line` 配 L1/L2 两条线 | `/api/lines` 返回 2 条，默认 L1 |
| `X-Line-Code: L1` 新增订单 | `WO_ID=1`，写入 `mt_l1.db`（140 张表） |
| `X-Line-Code: L2` 连续新增两单 | `WO_ID=1,2`，写入 `mt_l2.db`，与 L1 互不可见 |
| 不带线路头 | 落到默认线 L1 |
| `X-Line-Code: L9`（不存在） | `Code=4001 线路不存在或未配置：L9` |
| `POST /api/lines/reload` | 返回最新线路列表 |
| 单线路模式（`EnableMultiLine=false`） | 只有 1 条 `Line1`，业务接口正常 |

### 6. 上线注意

1. **每条线的库都要先建表**：`AutoCreateTables=true` 时启动会逐库 `InitTables`；生产建议对每个库执行一次 `db/sqlserver_schema.sql`。
2. 新增瓦线后：先在 BaseDB 插一行 → `POST /api/lines/reload` 让路由生效 → 再对新库建表/初始化账号（或重启服务让 `AutoCreateTables` 处理）。
3. 账号目前仍建在各自业务库里（启动按线路各 `EnsureSeedAsync` 一次）。若要把账号体系统一到 BaseDB 的 `S_Users`，需要把 `AuthService` 的取数切到 BaseDB 连接，这块可以单独做。
4. 跨线路的汇总报表（比如全厂日产量）属于跨库聚合，当前单请求只落一个库；要做得再接一个 `AsTenant()` 遍历或独立统计库。

---

## 十二、BaseDB 并入 IPS 库（统一账号 / 角色 / 权限 / 瓦线配置）

### 1. 合并方式

BaseDB 不再单独建库，12 张表直接进 IPS 库（表名与 155 张业务表无冲突，可同库共存）：

| 表 | 用途 |
|---|---|
| `S_Users` | 账号（`SU_Account` / `SU_Password` / `SU_UserName` / `SU_IsMulti` / `SU_IsDel`） |
| `S_Roles` | 角色（`SR_Name` = admin / planner / operator） |
| `S_User_Roles` | 用户-角色 |
| `S_Permissions` | 功能权限（`SP_Name` = `lines:reload` / `orders:write` / `params:write` / `alarms:confirm`） |
| `S_Role_Permissions` / `S_User_Permissions` | 角色授权 / 用户直授权 |
| `TB_Line` | 瓦线配置（多瓦线路由入口） |
| `T_Log` / `S_Apis` 等 | 预留，未接业务 |

脚本：

| 文件 | 说明 |
|---|---|
| `db/sqlserver_ips_full.sql` | **一次建全**：IPS 155 表 + BaseDB 12 表，同一个库 |
| `db/sqlserver_schema.sql` / `db/sqlserver_basedb_schema.sql` | 也可以分开跑（先 IPS 再 BaseDB） |
| `db/sqlserver_base_user_seed.sql` | 手工种账号（admin/planner/operator，密码 123456，PBKDF2 预生成） |
| `db/sqlserver_migrate_sysusers_to_susers.sql` | 老版 `Sys_Users` 账号迁到 `S_Users`（密码串格式相同，可直接沿用） |
| `db/basedb_tb_line_sample.sql` | 两条瓦线的 `TB_Line` 示例 |

配置只需要把公共库连接串留空，即视为“与业务库同库”：

```json
"Database": {
  "ConnectionString": "Server=localhost;Database=IPS;…",
  "BaseConnectionString": ""
}
```

> `S_Users.SU_Password` 已从原字典的 varchar(50) 加宽为 **nvarchar(200)**：PBKDF2 串（`pbkdf2$100000$salt$hash`）约 89 字符，原长度装不下。

### 2. 认证改造

| 之前 | 现在 |
|---|---|
| `AuthService` 用 `IRepository<Sys_User>`（跟请求线路走，每条线各一套账号） | 改用 `IBaseDbAccess`，**永远读公共库**，与请求线路无关，一次登录全厂通用 |
| 单角色字符串 `Sys_User.Role` | `S_User_Roles → S_Roles` 多角色，`S_Role_Permissions` + `S_User_Permissions` 多权限 |
| 密码仅 PBKDF2 | PBKDF2 写入；校验兼容历史 **32 位 MD5** 和明文（存量库登录不会挂） |
| JWT 一个 `role` claim | 每个角色一个 `Role` claim、每个权限一个 `perm` claim，另加 `multi_line` |
| 启动按线路各插一套 admin | 启动只对公共库插一次种子（admin/planner/operator，密码 123456） |

新增 `IBaseDbAccess`（Application 抽象）/ `ScopedBaseDbAccess`（Infrastructure）：内部走 `LineDbProvider.GetBase()`，配置了 `BaseConnectionString` 时取 `__base__` 连接，留空则取默认线路连接（合库场景）。

`/api/auth/me` 与登录返回都带上 `Roles` / `Permissions` / `IsMultiLine`，客户端可直接按角色控制菜单。

### 3. 权限落点

`POST /api/lines/reload` 现在要求 **admin 角色或 `lines:reload` 权限**，否则返回 `Code=403`。其它写接口可以照此加：

```csharp
if (!User.IsInRole("admin") && !User.HasClaim("perm", "orders:write"))
    return ApiResult<...>.Fail("无权限", 403);
```

### 4. 实测（SQLite，合并库模式）

| 用例 | 结果 |
|---|---|
| 启动建公共表 | `公共库：已按实体初始化 6/6 张表`，种子写入 S_Users/S_Roles/S_Permissions |
| admin 登录 | 角色 `['admin']`，权限 4 项，`IsMultiLine=true` |
| planner 登录 | 角色 `['planner']`，权限 `orders:write`、`params:write` |
| operator 登录 | 角色 `['operator']`，权限 `alarms:confirm`，`IsMultiLine=false` |
| `/api/auth/me` | 返回全部 Roles / Permissions |
| admin 调 `reload` | `0 线路配置已刷新` |
| operator 调 `reload` | `403 无权限刷新瓦线配置` |
| 密码错误 | `401 账号或密码错误` |
| 同一库再开多瓦线（`TB_Line` 两条，`BaseConnectionString` 留空） | 登录走公共库，`/api/lines` 返回两条；`X-Line-Code: Line1` 落本库、`Line2` 落 `IPS_L2` |

### 5. 现场落地步骤

1. 在 IPS 库执行 `db/sqlserver_ips_full.sql`（或先 `sqlserver_schema.sql` 再 `sqlserver_basedb_schema.sql`）。
2. 账号二选一：让服务 `SeedData=true` 自动写；或执行 `sqlserver_base_user_seed.sql`。
3. 老系统升级：先执行 `sqlserver_migrate_sysusers_to_susers.sql` 把 `Sys_Users` 迁过去，再改配置。
4. 多瓦线：`basedb_tb_line_sample.sql` 配 `TB_Line`，`BaseConnectionString` 仍留空（`TB_Line` 就在公共库/默认库）。
5. `appsettings.json` 里 `Database.ConnectionString` 指向 IPS，`BaseConnectionString` 置空，启动即可。

> 待确认：`S_Users.SU_IsMulti` 目前按“是否允许切换多条瓦线”理解并已写入 claim，但服务端还没据此拦截非默认线路的请求（默认放开）。要我按 `IsMultiLine=false → 只允许默认线` 强制拦截，说一声就加，一条中间件判断的事。

---

## 十三、登录页（按现场 BHS 登录界面复刻）

### 1. 界面结构（1200×440，无系统标题栏）

```
┌───────────────────────────────────────────────┬──────────────────┐
│                                               │            ✕     │
│   瓦线设备实景（深藏青机架 + 原纸卷 + 控制柜） │  智联革新        │
│   右缘向白色面板渐隐                          │  Intelligent…     │
│                                               │  ┌─────────────┐ │
│                                               │  │👤 superadmin ▾│ │
│                                               │  └─────────────┘ │
│                                               │  ┌─────────────┐ │
│  ◉ IPS  瓦楞纸板生产线生管系统                │  │🔒 ●●●●●      │ │
│         CORRUGATOR LINE SUITE                 │  └─────────────┘ │
│                                               │  ☑保存密码 ☐自动登录│
│                                               │  [   登  录   ]  │
└───────────────────────────────────────────────┴──────────────────┘
```

- 左侧 792px 设备实景：`Assets/login-bg.jpg`（`<Resource>` 打包，pack URI 引用），`UniformToFill` 裁切 + 右缘白色渐变过渡；左下角 IPS 圆形标识 + 产品名。
- 右侧 408px 登录面板：图标用 `Segoe MDL2 Assets`（`E77B` 人 / `E72E` 锁 / `E70D` 下拉箭头 / `E711` 关闭），输入框为 42px 高白底细边框，账号框带下拉箭头（视觉同现场，暂未接账号历史列表），复选框为 14px 方框蓝勾，登录按钮 `#1A6FD0` + hover/pressed 三态。
- 窗口可拖动（根 Border `MouseLeftButtonDown → DragMove`），✕ 关闭即退出；`Esc` 未绑定，保留给后续。

### 2. 交互与本地记忆

| 行为 | 实现 |
|---|---|
| 保存密码 | 账号 + 密码写入 `%LOCALAPPDATA%\Corrugator\login.json`；密码用 **Windows DPAPI（CryptProtectData）** 加密，换机器/换用户无法解密，不是明文文件 |
| 自动登录 | 勾选且本地有密码时，窗口 `Loaded` 后 500ms 自动提交；失败停在登录页显示错误 |
| 登录成功 | 保存偏好 → `MainWindow` 打开 → 登录窗关闭 |
| 服务端地址 | 面板右下角显示 `AppConfig.BaseUrl`，现场确认连的是哪台服务器 |

### 3. 启动流程修正

之前 `App.OnStartup` 只注册了 DI，**从未创建任何窗口**（`LoginWindow` 有 XAML 但没人 new），客户端其实是启动即退出。现在：

```
App.OnStartup → DI → new LoginWindow().Show()
LoginWindow 登录成功 → new MainWindow().Show() → 关闭登录窗（MainWindow 关闭 = 退出）
```

### 4. 换背景图

现场如果想用 BHS 官方拍摄的实景图：直接把图存成 `src/Corrugator.Client.Wpf/Assets/login-bg.jpg`（建议 1600×900 或更宽），重新编译即可，代码不用改。当前仓库内置的是按参考图重绘的同类工业实景图。

---

## 十四、基础信息页（系统设置竖向菜单）

按现场截图复刻：左侧 150px「系统设置」折叠条 + 竖排深蓝菜单按钮，右侧内容区随选中项切换。

### 1. 左侧菜单（与现场一致，12 项）

| 菜单 | 右侧内容 | 数据来源 |
|---|---|---|
| 功能管理 | 权限表列表（ID/父ID/权限编码/类型/命名空间/排序/备注） | `S_Permissions` |
| 角色管理 | 角色列表（角色/排序/用户数/权限数/状态） | `S_Roles` + 关联计数 |
| 用户管理 | 用户列表（账号/姓名/角色/手机/多瓦线/创建时间，**不含密码**） | `S_Users` + `S_User_Roles` |
| 数据字典 | 复用现有字典视图（字典类型 ↔ 明细联动） | IPS `P_DictTypes` / `P_DictDatas` |
| 个人信息 | 登录账号、姓名、角色、瓦线权限、服务端地址、功能权限 | 登录返回的 `Roles/Permissions/IsMultiLine` |
| 通讯设置 / 系统设置 / API授权 / 订单颜色设置 / IPS部位显示·隐藏 / 订单扩展字段设置 / 打印标签设置 | 居中说明卡片，标注待接入范围 | — |

菜单样式：按钮 `#1B4E8C` 深蓝、30px 高、3px 圆角、11.5px 加粗白字、间距 9；hover `#245D9E`、选中 `#0E3866`。折叠条 `#E7EBF0` + 右侧 `⌃`。

### 2. 新增接口（仅管理员）

| 方法 | 路径 | 说明 |
|---|---|---|
| GET | `/api/system/users` | 用户列表（角色用 `S_User_Roles → S_Roles` 拼成 `admin`，不返回密码哈希） |
| GET | `/api/system/roles` | 角色列表，带 `UserCount` / `PermissionCount` |
| GET | `/api/system/permissions` | 功能权限列表 |

非 admin 调用返回统一 JSON：`{"Code":403,"Message":"仅管理员可查看用户管理"}`（不是裸 403 空响应，客户端能直接显示原因）。

### 3. 实测

| 用例 | 结果 |
|---|---|
| admin 调 `/api/system/users` | `Code=0`，3 条：admin/系统管理员/角色 admin、planner、operator |
| admin 调 `/api/system/roles` | 3 条：admin 用户 1 权限 4、planner 1/2、operator 1/1 |
| admin 调 `/api/system/permissions` | 4 条功能权限（lines:reload / orders:write / params:write / alarms:confirm） |
| operator 调 `/api/system/users` | `Code=403 仅管理员可查看用户管理` |

### 4. 顶栏对齐

用户名由「姓名（账号）」改为只显示姓名（现场是“超级管理员”），账号移到基础信息 → 个人信息里查看。

---

## 十五、基础信息 → 功能管理（菜单树 + 功能增删改）

按现场截图实现：顶部「查询条件」条、左侧菜单树、右侧功能表格。

### 1. 布局

```
┌ 查询条件 ───────────────────────────────────────────────────────────┐
│ 菜单名称: [________]  ☐显示全部   [搜索] [重置] [＋新增菜单功能]      │
└────────────────────────────────────────────────────────────────────┘
┌ 菜单树（252px） ┬ 操作 名称 父节点 类型 命名空间 排序号 删除 创建人 创建时间 修改人 修改时间 ┐
│ › 生管控制      │ 编辑 删除  测试功能 生管控制 功能 api 9  否  admin  2026-11-14 10:12  …   │
│ › 图形化控制    │                                                                          │
│ › 系统管理      │                                                                          │
│   └ 切换班组    │                                                                          │
└────────────────┴──────────────────────────────────────────────────────────────────────────┘
```

- 查询条：白底 1px `#D8DDE4` 边框，「查询条件」标题为 `#1B4E8C` 加粗小字；按钮为 27px 深蓝小按钮（hover `#245D9E`、pressed `#0E3866`）。
- 左侧菜单树：17 个一级菜单（生管控制、图形化控制、工单管理、系统管理、预警管理、报表管理、基础档案、QDM基础表、DF/SF1/SF2/SF3 系数修改、DF/SF1/SF2/SF3 参数控制开关、弯翘自动控制开关），`系统管理` 下挂 `切换班组`。
- 右侧表格：操作列是文字链接（编辑 / 删除，删除为红色），其余列与截图一致。
- 选中左侧节点 = 过滤该节点下的功能；点「重置」回到全部。
- 左侧菜单选中态按现场做成**白底 + 蓝边 + 蓝字**，未选中为深蓝实心。

### 2. 接口（全部管理员限定）

| 方法 | 路径 | 说明 |
|---|---|---|
| GET | `/api/system/permissions?name=&showAll=&parentId=` | 名称模糊查 + 是否含已删除 + 按父节点过滤；`parentId=0` 时列出根节点和菜单节点 |
| GET | `/api/system/permissions/tree` | 菜单树（`SP_Type=菜单`，按排序号，父子自动组装） |
| POST | `/api/system/permissions` | 新增（同级同名会拒绝） |
| PUT | `/api/system/permissions/{id}` | 修改（写 `SP_Editor / SP_EditTime`） |
| DELETE | `/api/system/permissions/{id}` | 软删除 `SP_IsDel=1`，有子节点时拒绝 |

请求体：`{ name, parentId, type（菜单/功能）, nameSpace, sortNo, remark }`。

### 3. 实测

| 用例 | 结果 |
|---|---|
| 菜单树 | 17 个一级 + 系统管理下的「切换班组」 |
| 列表（默认） | 22 条：17 菜单 + 切换班组 + 4 条功能权限（`lines:reload` 等） |
| 生管控制下新增「测试功能A」 | `0 已新增`，父节点显示「生管控制」，`parentId` 过滤只出这一条 |
| 改名「测试功能A-改」 | `0 已保存`，写入修改人 admin + 修改时间 |
| 软删除 | `0 已删除`；默认过滤下 0 条，`showAll=true` 时可见且 `IsDeleted=true` |
| operator 新增 | `403 仅管理员可维护功能权限` |

### 4. 层级与行样式（对齐现场展开态）

- 左树同时包含**菜单**与**功能**两类节点：菜单作分组（加粗、无标记），功能作叶子（前面一个 6×6 实心小方块）。
- 同层排序：先菜单分组、再功能，组内按排序号 → 现场看到的「生管控制 → 生管总控 → 强换/停换/重传…」这种三层结构可直接来自 `S_Permissions` 的 `SP_PID`。
- 点菜单节点 → 过滤其下所有子项；点功能叶子 → 自动按该功能名称定位到它自己那一行。
- 表格首列加了勾选框（表头 ▦，预留批量操作），行内操作文案为「修改 / 删除」，名称列对功能行同样显示实心方块。
- 时间列改为 `yyyy-MM-dd HH:mm:ss`；数据库里空日期按原值直出（现场会显示 `0001-01-01 04:30:00`，后续可改成空白/短横线，等你确认口径）。
- 种子补了 3 个示例分组（生管控制 → 生管总控；图形化控制 → 总控右手机 / 总控左手机，备注「示例分组，可按需删除」），真实层级数据由你们的 `S_Permissions` 决定。

### 4. 新增/编辑对话框

420×392 小窗：名称、父节点（下拉，自动铺平菜单树）、类型（功能/菜单）、命名空间、排序号、备注；保存写库并自动刷新左树+右表，取消不做任何写操作。

---

## 十六、基础信息 → 角色管理（查询 + 权限绑定）

角色管理按现场截图实现：顶部查询条、表格行选中深蓝、`权限绑定 / 删除` 行内操作，
新增与授权合并成一个「角色管理-编辑」弹窗。

### 1. 布局

```
┌ 查询条件 ─────────────────────────────────────────────────────────────┐
│ 角色名称: [____________]   [搜索] [重置]                               │
└──────────────────────────────────────────────────────────────────────┘
┌▦ 操作               角色名称   创建人      创建时间            修改人     修改时间          ┐
│▢ 权限绑定 删除      参数管理   超级管理员  2023-04-26 11:09:06 超级管理员 2025-04-02 13:42:17│ ← 选中行整行深蓝、文字白色
│▢ 权限绑定 删除      生产管理   超级管理员  2023-04-26 11:12:23 超级管理员 2025-04-02 13:11:05│
│▢ 权限绑定 删除      生产监控   超级管理员  …                                                │
└──────────────────────────────────────────────────────────────────────────────────────────┘
```

- 列顺序与现场一致：勾选列（表头 `▦`）、操作、角色名称、创建人、创建时间、修改人、修改时间。ID / 排序号 / 用户数 / 权限数不进列表，避免和现场错位。
- 选中行：整行 `#1B4E8C` 深蓝底 + 白字，行内链接自动转浅蓝 `#D9E8FF`，删除保持浅红，蓝底上不糊。
- 行高 34px、无竖线，白底 + `#F7F9FB` 隔行色。

### 2. 角色管理-编辑（合并弹窗）

640×560，无系统边框：标题栏「角色管理-编辑」+ 右上 ✕，内容为

| 区域 | 内容 |
|---|---|
| 角色名称 | 输入框（新增可填，编辑带回原名，为空拒绝） |
| 权限绑定 | 与「功能管理」同源的树（菜单加粗、功能灰字），逐项 CheckBox，勾父不强制勾子 |
| 底部 | 已勾选 N 项 + 取消 / 确定（都是深蓝实心，同现场） |

点「确定」一次完成两件事：先 `POST/PUT /api/system/roles` 保存角色，再 `PUT /api/system/roles/{id}/permissions` 整组替换授权。新增时用返回的自增 `RoleId` 去授权，不会出现"角色建了但权限没落库"。

### 3. 接口（全部管理员限定）

| 方法 | 路径 | 说明 |
|---|---|---|
| GET | `/api/system/roles?name=` | 角色列表，`name` 模糊过滤；带创建/修改人及时间 |
| POST | `/api/system/roles` | 新增（同名拒绝） |
| PUT | `/api/system/roles/{id}` | 改角色名，写 `SR_Editor`、`SR_EditTime` |
| DELETE | `/api/system/roles/{id}` | 软删除；内置 `admin`、仍有用户占用的角色拒绝 |
| GET | `/api/system/roles/{id}/permissions` | 已授权权限 ID 列表 |
| PUT | `/api/system/roles/{id}/permissions` | 整组替换 `S_Role_Permissions` |

### 4. 实测（SQLite 合并库，端口 5123 / 5124）

| 用例 | 结果 |
|---|---|
| `?name=plan` | 只返回 planner（2 权限，创建人 system） |
| `?name=zzz` | 0 条 |
| 新增「测试角色X」 | `0 已新增`，创建人 admin |
| 授权 `[5, 1]` → 读回 | `0 已保存授权 2 项` → `[5, 1]` |
| **改动前** operator 调 `POST /api/lines/reload` | `403 无权限刷新瓦线配置` |
| 给 operator 角色授权 `lines:reload` 后重登 | `/api/auth/me` → `Permissions=['lines:reload']` |
| **改动后** 同一接口 | `0 线路配置已刷新` |
| 删除 admin 角色 | `-1 内置管理员角色不可删除` |
| operator 新增角色 | `403 仅管理员可维护角色` |

结论：角色授权 → 重新登录换 JWT → `[Authorize]` 放行，链路已真机验证，不是只写库。

### 5. 权限体系闭环

```
S_Users ─(S_User_Roles)─ S_Roles ─(S_Role_Permissions)─ S_Permissions
   └─(S_User_Permissions 直授)─┘
功能管理建菜单/功能 → 角色管理授权 → 用户重登换 JWT perm → 接口鉴权
```

待拍板：`S_Users.SU_IsMulti` 目前只写 `multi_line` claim，服务端未据此拦截非默认线路请求。

---

## 十七、WPF 客户端切换到 Prism（Prism 9.0.537 + Unity）

客户端原来用 CommunityToolkit.Mvvm + Microsoft.Extensions.DependencyInjection，现整体切到 Prism：

| 能力 | 原来 | 现在 |
|---|---|---|
| MVVM 基类 | `ObservableObject` + `[ObservableProperty]` 源生成器 | `Prism.Mvvm.BindableBase` + 手写 `SetProperty` 属性 |
| 命令 | `[RelayCommand]` 源生成器 | `Prism.Commands.DelegateCommand` + 自封 `AsyncCommand`（可 await、执行期自动禁用按钮） |
| 依赖注入 | `ServiceCollection` / `App.Services` | Prism `IContainerRegistry` / `Container.Resolve` / `ContainerLocator.Container` |
| 启动 | `App.OnStartup` 里手动 new 登录窗 | `PrismApplication.CreateShell()` 返回登录窗，登录成功后换成 MainWindow |

### 1. NuGet 与启动

```xml
<PackageReference Include="Prism.Unity" Version="9.0.537" />
```

`App.xaml` 根节点由 `<Application>` 改为 `<prism:PrismApplication xmlns:prism="http://prismlibrary.com/">`，去掉 `StartupUri`。

`App.xaml.cs`：

```csharp
public partial class App : PrismApplication
{
    protected override Window CreateShell() => Container.Resolve<LoginWindow>();

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<ApiClient>();
        containerRegistry.RegisterSingleton<AppSession>();
        containerRegistry.RegisterSingleton<MainViewModel>();
        containerRegistry.Register<LoginViewModel>();
        containerRegistry.Register<DashboardViewModel>();
        // … 其余页面 VM 与 LoginWindow / MainWindow
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        if (MainWindow is { IsVisible: false }) MainWindow.Show();
    }
}
```

登录成功后（`LoginWindow.OnLoginSucceeded`）：

```csharp
var main = ContainerLocator.Container.Resolve<MainWindow>();
main.Show();
Application.Current.MainWindow = main;
Close();
```

登录窗作为入口 Shell，主窗由容器构造并接管；关掉登录窗（点 ✕）程序即退出（`ShutdownMode` 默认按最后一个窗口关闭）。

### 2. AsyncCommand（补 Prism 的空白）

Prism 9.0 的 `DelegateCommand` 只接受同步委托，`async () =>` 传进去是 `async void`，没法禁用按钮、也没法等待。这里新增 `Services/AsyncCommand.cs`，基于 `DelegateCommandBase`：

```csharp
public class AsyncCommand : DelegateCommandBase
{
    private bool _isExecuting;
    protected override bool CanExecute(object? parameter) => !_isExecuting && (_canExecute?.Invoke() ?? true);
    protected override async void Execute(object? parameter) { /* await _execute(); 期间 IsExecuting=true */ }
}
```

VM 里这样用：

```csharp
public AsyncCommand LoadCommand { get; }
public OrdersViewModel(ApiClient api) { _api = api; LoadCommand = new AsyncCommand(LoadAsync); }
```

XAML 绑定不变：`Command="{Binding LoadCommand}"`。执行期间按钮自动变灰，异常统一兜底提示，不会静默丢。

### 3. ViewModel 改写要点

- 字段式属性 → `SetProperty`：

```csharp
private string _statusMessage = string.Empty;
public string StatusMessage { get => _statusMessage; set => SetProperty(ref _statusMessage, value); }
```

- 联动属性（如 `OrdersViewModel.TotalPages`）在 `Total` / `PageSize` 的 setter 里 `RaisePropertyChanged(nameof(TotalPages))`。
- `partial void OnSelectedXChanged` 的副作用直接写进 setter，例如 `BasicInfoViewModel.SelectedMenu` 里刷新 5 个 `Visibility` 再按 key 加载数据。
- 子页面的 `DataContext` 仍由 MainWindow 绑定（`<views:DashboardView DataContext="{Binding Dashboard}" />`），未启用 Prism 的 ViewModelLocator，避免改文件名/命名约定。
- `BasicInfoView` 里的内嵌字典页由容器解析：`ContainerLocator.Container.Resolve<DictionaryViewModel>()`。

### 4. 改动清单

| 文件 | 变化 |
|---|---|
| `Corrugator.Client.Wpf.csproj` | 去掉 CommunityToolkit.Mvvm、Microsoft.Extensions.DependencyInjection；加 Prism.Unity 9.0.537 |
| `App.xaml` / `App.xaml.cs` | PrismApplication + RegisterTypes + CreateShell(登录窗) |
| `Services/AsyncCommand.cs` | 新增，异步命令 |
| `ViewModels/*.cs`（9 个） | BindableBase + 显式属性 + AsyncCommand |
| `Views/LoginWindow.xaml.cs` | 构造函数注入 LoginViewModel；成功后容器解析 MainWindow |
| `Views/MainWindow.xaml.cs` | 构造函数注入 MainViewModel |
| `Views/BasicInfoView.xaml.cs` | App.Services → ContainerLocator |

### 5. 验证情况（如实说明）

- `dotnet build Corrugator.sln` 全绿，Prism 9.0.537 已正常还原并进入引用。
- 命令绑定名与 VM 属性逐个核对通过（Load / Search / NextPage / PrevPage / Create / Delete / Confirm / Save）。
- **尚未真机运行**：本环境是 Linux，WPF 无法启动，只做了编译级验证；Prism 的 Shell 显示、登录窗切主窗的运行时行为需在你 Windows 机器上跑一次确认。
- 已知待你确认的点：登录窗关闭即退出、主窗最大化启动、Prism 版本用 9.0.537（NuGet 上 9.1.0 不存在，9.0.537 为当前最新）。

---

## 十八、用户管理（S_Users + S_User_Roles）

按现场截图复刻：查询条件条 `用户姓名 + 显示全部 + 搜索/重置/＋新增用户`，表格带行序号与「修改 / 删除 / 清理登录缓存」三个行内链接，首行选中深蓝；编辑弹窗为三栏 `用户详情 / 所属角色 / 可用功能`。

### 1. 列表页

| 项 | 实现 |
|---|---|
| 查询 | `GET /api/system/users?name=&account=&showAll=`，`name` 对 `SU_UserName` 模糊，`showAll=false` 时过滤 `SU_IsDel` |
| 行序号 | 客户端按加载顺序回填 `SystemUserDto.RowNo`（不参与接口语义） |
| 列 | `▦`、操作、序号、姓名、账号、手机号码、停机点位、多瓦线、是否删除、创建人、创建时间、修改人、修改时间 |
| 行样式 | 行高 34、无竖线、隔行 `#F7F9FB`；选中行 `#1B4E8C` 深蓝底白字，行内链接转 `#D9E8FF`，删除链接选中转 `#FFB4A8` |
| 操作 | 修改 → 弹窗；删除 → 二次确认后软删除；清理登录缓存 → 直接调接口并在查询条右侧回显结果 |

### 2. 编辑弹窗（UserEditWindow，800×620）

- 左「用户详情」：账号* / 用户名* / 密码*（新增必填，编辑留空表示不改）/ 性别（可输入下拉）/ 手机号码 / 停机点位（可输入下拉：湿部/干部/全机）/ 多端登录 / 是否删除 / 创建人 / 创建时间 / 修改人 / 修改时间（后四项只读，灰底）。
- 中「所属角色」：`S_Roles` 的 CheckBox 列表，勾选即 `RoleIds`。
- 右「可用功能」：**按所选角色的 `S_Role_Privileges` 并集**实时派生，`IsHitTestVisible=false` 只读展示；菜单加粗、功能常规。勾角色 → 逐角色拉 `GET roles/{id}/permissions` → 合并 → 重建树。
- 底部：提示文案（新增必填密码 / 编辑留空不改）+ 取消 + 确定。

保存语义：先 `POST` 或 `PUT users` 落 `S_Users` 并拿到 `SuId`，再整组替换 `S_User_Roles`（先删后插），一次提交完成资料与角色的变更。

### 3. 接口

| 方法 | 路径 | 说明 |
|---|---|---|
| GET | `/api/system/users?name=&account=&showAll=` | 列表（含 `Gender`/`StopPosition`/`RoleIds`/`Creator`/`Editor`） |
| POST | `/api/system/users` | 新增：账号非空且唯一、密码必填、`PasswordHasher.Hash` 存 PBKDF2 |
| PUT | `/api/system/users/{id}` | 修改：账号改名查重、密码留空不改、可置 `SU_IsDel`、写 `Editor`/`EditTime` |
| DELETE | `/api/system/users/{id}` | 软删除，`admin` 账号拒绝 |
| POST | `/api/system/users/{id}/clear-login-cache` | `DELETE FROM T_UserLoginCache WHERE F_Account=@account`；表缺失时返回 `0 未执行清理：…` 不报红 |

### 4. 实测（SQLite /tmp/merged.db，端口 5125，admin 令牌）

| 场景 | 结果 |
|---|---|
| 新增 `uu001/测试甲` 密码 888888，角色 planner | `0 已新增`，`SuId=4`、`Roles=planner`、`RoleIds=[2]` |
| 再用同账号新增 | `-1 账号已存在` |
| 新用户登录 | `0 ok`，`Role=planner`，权限 `orders:write / params:write` |
| 修改资料 + 密码留空 + 角色改 `[2,5]` | `0 已保存`，`Roles=planner / 参数管理`，`Gender=女`、`StopPosition=干部`、`IsMultiLine=false` |
| 密码留空后旧密码登录 | `0 ok`（未被清空） |
| 改密码为 999999 | 旧密码 `401 账号或密码错误`，新密码 `0 ok` |
| 清理登录缓存 | `0 未执行清理：no such table: T_UserLoginCache`（SQLite 未建该表，SQL Server 有表会返回清理条数） |
| 删除用户 | `0 已删除`；删除后该账号登录 `401`；`showAll=true` 可见 `uu001 IsDeleted=true` |
| 删 admin | `-1 内置管理员账号不可删除` |
| operator 新增用户 | `403 仅管理员可维护用户` |

### 5. 口径与未完成

- 「多端登录」当前映射 `SU_Users.SU_IsMulti`，只写 JWT 的 `multi_line` claim，**服务端尚未据此拦截非默认线路请求**，等确认是否强制。
- 「可用功能」是角色权限的只读投影，不在用户表上单独存权限，避免角色授权与用户授权两套数据打架。
- WPF 侧只做了编译验证（Linux 不能跑 WPF），弹窗三栏布局与行选中配色需在 Windows 上核对；如与截图有像素级偏差，按截图微调列宽/行高。

---

## 十九、数据字典（P_DictTypes + P_DictDatas）

按现场截图复刻：左侧分类树 + 上方「＋新增 / ✎修改 / 🗑删除」，右侧「＋新增字典明细」+ 明细表。树节点显示 `中文名|英文名`，根节点是虚拟的「根目录」。

### 1. 页面结构

| 区域 | 实现 |
|---|---|
| 分类树 | 452px 宽；`P_DictTypes.PD_PID` 递归挂接；根目录默认展开的父节点；选中行浅灰 `#EDF0F3`；根目录加粗、不可改删（`CanEditNode` 控制按钮 `IsEnabled`） |
| 分类操作 | 新增时父节点取当前选中项（选根目录即挂根）；修改回填当前节点；删除前二次确认 |
| 明细表 | 列：`▦ / 操作(修改·删除) / 序号 / 值 / 英文名 / 中文名 / 属性 / 排序号`；行高 34、隔行 `#F7F9FB`、选中深蓝 |
| 明细序号 | 客户端按加载顺序回填 `RowNo`，与现场截图一致 |
| 切菜单加载 | 基础信息左侧点「数据字典」时触发 `DictionaryViewModel.LoadAsync()`（`BasicInfoView` 持有该 VM 实例） |

### 2. 接口

| 方法 | 路径 | 说明 |
|---|---|---|
| GET | `/api/dictionary/types` | 分类平铺列表（含创建人/时间、修改人/时间） |
| GET | `/api/dictionary/types/{id}/data` | 指定分类下的明细，按 `PD_SortNo, PD_ID` 排序 |
| POST | `/api/dictionary/types` | 新增分类，中文名必填 |
| PUT | `/api/dictionary/types/{id}` | 修改分类 |
| DELETE | `/api/dictionary/types/{id}` | 删除分类，有子分类或有明细时拒绝 |
| POST | `/api/dictionary/datas` | 新增明细，`PD_TypeID` 必填 |
| PUT | `/api/dictionary/datas/{id}` | 修改明细 |
| DELETE | `/api/dictionary/datas/{id}` | 删除明细 |

写操作均要求 `admin`（与功能/角色/用户维护口径一致），审计字段写 `PD_Creator/PD_CreateTime`、`PD_Editor/PD_EditTime`（明细创建人列名为历史遗留的 `PD_Ctreator`）。

### 3. 实测（SQLite /tmp/merged.db，端口 5126）

| 场景 | 结果 |
|---|---|
| 新增根分类 `PMS_瓦线设置/PMSTileSet` | `0 已新增`，PD_ID=1 |
| 其下新增子分类 `错位/Bundle` | `0 已新增`，PD_ID=2、PD_PID=1 |
| 子分类下新增明细 值=0 属性=启用错位 0-NO 1-Yes | `0 已新增` |
| 读回明细 | `(1, '0', '启用错位 0-NO 1-Yes', 0)` |
| 改明细（中文名=错位开关，排序=1） | `0 已保存` |
| 删有明细的分类 | `-1 该分类下还有字典明细，请先删除明细` |
| 删有子分类的父类 | `-1 该分类下还有子分类，请先删除子分类` |
| 先删明细再删子类、父类 | 三条均 `0 已删除` |
| operator 新增分类 | `403 仅管理员可维护数据字典` |

### 4. 已知口径

- 字典数据按现场截图只做「分类 + 明细」，未做跨瓦线同步；P_DictTypes/P_DictDatas 属于 IPS 线库，多瓦线时各自独立。
- 现场那条 `启用错位 0-NO 1-Yes` 的「属性」是自由文本，没有做枚举校验。
- WPF 仅编译验证（Linux 不能运行 WPF），树的展开箭头与选中灰底需在 Windows 上确认。

---

## 二十、通讯设置（TB_Plc_DriverConfig / TB_Plc_PointVar）

基础信息 → 通讯设置，现场截图是三个页签：`通讯配置设置 / 通讯设备设置 / 通讯点位变量设置`，第一个页签带深蓝下划线。

### 1. 页面

| 区域 | 实现 |
|---|---|
| 页签 | 单选按钮样式（`RadioButton` 模板），选中态深蓝字加粗 + 底部 2px `#1B4E8C` 下划线；点页签即切数据源并加载 |
| 查询条 | `配置名称:[ ] 参数编码:[下拉可输入] ☐显示全部 [🔍搜索] [↻重置] [＋新增通讯设置]` |
| 配置表 | 列：`▦(勾选) / 操作(修改) / 配置编码 / 配置名称 / 参数说明 / 参数编码 / 参数值 / 是否删除`；行高 34、隔行 `#F7F9FB`、选中深蓝 |
| 底部 | `删除 / 刷新 / 立即生效` 三颗深蓝按钮；删除取勾选行（无勾选提示） |
| 编辑弹窗 | 720×420，`通讯配置设置-编辑`，左右两列：配置编码* / 配置名称* / 参数说明* / 参数编码*（下拉可输入，取现有去重值）/ 参数值* / 是否删除 / 创建人 / 创建时间 / 修改人 / 修改时间（后四只读灰底），底部取消/确定 |
| 设备页签 | 按 `F_Code` 归并展示：配置编码 / 配置名称 / 参数条数 / 是否删除（只读，参数仍在配置页维护） |
| 点位页签 | `TB_Plc_PointVar` 只读列表：点位编码 / 名称 / 驱动编码 / 变量地址 / 数据类型 / 读写 / 启用 / 当前值 |

### 2. 接口

| 方法 | 路径 | 说明 |
|---|---|---|
| GET | `/api/comm/configs?name=&code=&parCode=&showAll=` | 配置列表；`showAll=false` 过滤 `F_IsDelete` |
| GET | `/api/comm/par-codes` | 参数编码下拉值（现有数据去重） |
| GET | `/api/comm/devices?showAll=` | 按配置编码归并的设备视图 |
| GET | `/api/comm/points?showAll=` | 点位变量列表 |
| POST | `/api/comm/configs` | 新增（配置编码必填） |
| PUT | `/api/comm/configs/{id}` | 修改（可改配置编码、可置是否删除） |
| DELETE | `/api/comm/configs/{id}` | 单条软删（置 `F_IsDelete`） |
| POST | `/api/comm/configs/batch-delete` | 底部「删除」按钮用，body `{Ids:[…]}` |
| POST | `/api/comm/reload` | 「立即生效」：重读有效配置条数并刷新服务端缓存；**PLC 网关未接入，不下发设备**，返回文案已注明 |

写操作与生效均限 `admin`。

### 3. 实测（SQLite /tmp/merged.db 手工建通讯表 + 截图同款 5 条样例，端口 5127）

| 场景 | 结果 |
|---|---|
| 列表 | `0`，5 条；DFConfig/双面机/IPAddress/192.168.110.99、DFConfig/Port/102、LS0Config/面纸接纸机… |
| 配置名称=双面 查询 | `0`，命中 2 条 DFConfig |
| 参数编码下拉 | `["IPAddress","Port"]` |
| 新增 SF1Config/单面机1 | `0 已新增`，F_ID=6 |
| 修改参数值 | `0 已保存`，192.168.110.100 |
| 设备归并 | DFConfig(2 参数)、LS0Config(1)、SF1Config(2)、SF2Config(1) |
| 勾选批量删除 | `0 已删除 1 条`，`showAll=true` 里该行 `IsDelete=true` |
| 立即生效 | `0 已重新加载 5 条通讯配置（PLC 网关未接入，本次仅刷新服务端缓存）` |
| operator 新增配置 | `403 仅管理员可维护通讯设置` |
| 点位列表 | `0`，0 条（测试库未灌点位） |

### 4. 说明

- 「通讯设备设置」没有独立表，按 `F_Code` 把配置行归并成设备视图；现场如果需要真实的设备主数据（设备名、厂商、协议），要再建一张设备表。
- 「立即生效」目前只刷新服务端缓存，PLC/OPC UA 网关未接入，不做真实下发。
- SQLite 测试库原本没有这两张表（bigint 自增在 SQLite 建表会失败），本轮为联调手工建表并灌了截图同款样例；SQL Server 上用 `db/sqlserver_ips_full.sql` 建即可。
- WPF 仍为编译级验证，页签下划线、勾选框与选中行配色需在 Windows 实机确认。

---

## 二十一、通讯设备设置（TB_Plc_Device）

通讯设置第二个页签。和上一章不同，这里是**独立的设备主数据表**，不再按配置编码归并。

### 1. 表结构 `db/sqlserver_plc_device.sql`

| 列 | 类型 | 说明 |
|---|---|---|
| F_Code | nvarchar(36) | 设备编码，业务唯一（未删除记录内查重） |
| F_Name | nvarchar(100) | 设备名称 |
| F_CommType | nvarchar(50) | 通讯类型（协议驱动：Siemens_S7_1200 等） |
| F_ConfigName | nvarchar(100) | 通讯配置（配置表里的配置名称：双面机、湿部PLC配置…） |
| F_IsUse | bit | 启用（列表勾选框） |
| F_IsDelete | bit | 删除（列表勾选框，软删标记） |
| F_Creator/F_CreateTime/F_Editor/F_EditTime | | 审计 |
| F_ID | bigint identity | 主键 |

脚本内含 `IF NOT EXISTS` 建表保护 + 12 条现场截图同款样例（DF/双面机、LSO/面纸接纸机、SF1/SF2、MS1/MS2、LS1/LS2、PLC03 湿部PLC、PLC02 干部订单PLC、PLC01 回收机PLC、PLC04 巡航PLC）。

### 2. 接口

| 方法 | 路径 | 说明 |
|---|---|---|
| GET | `/api/comm/devices?name=&code=&commType=&config=&showAll=` | 设备列表，支持按名称模糊、编码模糊、类型精确、配置精确过滤 |
| GET | `/api/comm/device-types` | 通讯类型下拉，12 个协议常量（截图里那一列） |
| GET | `/api/comm/config-options` | 通讯配置下拉，取配置表未删除记录按名称去重 |
| POST | `/api/comm/devices` | 新增（编码必填、未删记录查重） |
| PUT | `/api/comm/devices/{id}` | 修改（改编码时查重，可带是否删除） |
| POST | `/api/comm/devices/batch-delete` | 底部「删除」按钮，body `{Ids:[…]}` |
| POST | `/api/comm/reload` | 「立即生效」，文案已带设备条数 |

写操作限 `admin`。

### 3. 页面

- 查询条：`配置名称:[ ] 通讯类型:[下拉，可输入] 通讯配置:[下拉] ☐显示全部 [🔍搜索] [↻重置] [＋新增通讯设备]`
- 表格：`▦(勾选) | 操作(修改) | 设备编码 | 设备名称 | 通讯类型 | 通讯配置 | 启用 | 删除`；行高 34、隔行 `#F7F9FB`、选中深蓝白字；启用/删除两列是只读勾选框
- 底部：`删除 / 刷新 / 立即生效`
- 编辑弹窗 `CommDeviceEditWindow` 740×420「通讯设备设置-编辑」：左列 设备编码* / 通讯类型*（协议下拉）/ 是否删除 / 创建时间 / 修改时间，右列 设备名称* / 通讯配置*（配置下拉）/ 创建人 / 修改人；审计四格只读灰底

### 4. 实测（SQLite，端口 5127，12 条设备样例）

| 场景 | 结果 |
|---|---|
| 设备列表 | `0`，12 条；DF/双面机/Siemens_S7_1200/双面机/启用，PLC01、PLC04 停用 |
| 通讯类型下拉 | 12 个：ModBusAscii…LenzeMDI |
| 通讯配置下拉 | 4 项去重（双面机、面纸接纸机、单面机1、单面机2；受测试库配置条数限制） |
| commType=Siemens_S7_1200 | 命中 12 条 |
| config=湿部PLC配置 | 命中 PLC03 |
| 新增 PLC05 | `0 已新增`，F_ID=13 |
| 重复编码 | `-1 设备编码已存在` |
| 修改 | `0 已保存`，名称/类型/启用全部更新 |
| 勾选批量删除 | `0 已删除 1 条`，showAll 里 `IsDelete=true` |
| 立即生效 | `0 已重新加载 5 条通讯配置、12 个通讯设备（…仅刷新服务端缓存）` |
| operator 新增 | `403 仅管理员可维护通讯设置` |

### 5. 说明：截图里弹窗两个标签疑似串位

现场截图列表：`通讯类型` 列是协议名（Siemens_S7_1200）、`通讯配置` 列是配置名（双面机）；但弹窗里 `通讯类型` 显示「双面机」、`通讯配置` 反而挂的是协议下拉（ModBusAscii…）。

本实现统一按**列表口径**：`通讯类型`=协议驱动、`通讯配置`=配置名称，弹窗两个字段也按这个语义各挂各的下拉（协议下拉在通讯类型、配置下拉在通讯配置）。若确认要照搬现场的错位显示，改 `CommDeviceEditWindow.xaml` 两个标签文案与两个下拉的绑定即可，不影响数据。

---

## 二十二、通讯点位变量设置（TB_Plc_PointVar）

通讯设置第三个页签。字段最多的一页，表已在 IPS 全量脚本里（`db/sqlserver_ips_full.sql`），本轮补齐增删改与下拉。

### 1. 字段口径

| 界面字段 | 列 | 说明 |
|---|---|---|
| 部位 | F_Position | 双面机 / 面纸接纸机 / 单面机1 … |
| 所属设备 | F_DriverCode | 取设备表名称（通讯设备设置里的设备） |
| 变量编码 | F_Code | 如 DF_BartrolPressure_Pulling_Section |
| 变量名称 | F_Name | DF冷板部压力设定值 |
| 变量说明 | F_Desc | 同名称，现场两者内容一致 |
| PLC地址/MDI变量名 | F_VarAddress | DB4.DBD12 这种 S7 地址 |
| 数据类型 | F_DataType | Bool / Short / Int / Float / Double / String |
| 可读可写 | F_RW | int 存 1/2/3，界面显示 ReadOnly / ReadWrite / WriteOnly |
| 读取间隔 | F_Interval | 毫秒，截图默认 200 |
| 当前值 | F_CurValue | 可手填，PLC 未接入时只作占位 |
| 启用 / 是否删除 | F_IsUse / F_IsDelete | 勾选框 |
| 其余保留列 | F_Priority、F_IsAlarm、F_AlarmInterval、F_AlarmOffset、F_DataOK*、F_TransferKey* | 页面暂未暴露，接口保留字段 |

### 2. 接口

| 方法 | 路径 | 说明 |
|---|---|---|
| GET | `/api/comm/points?position=&device=&code=&showAll=` | 点位列表，部位/设备精确过滤，编码模糊 |
| GET | `/api/comm/point-options` | 一次返回四组下拉：部位、所属设备、数据类型、可读可写 |
| POST | `/api/comm/points` | 新增（变量编码必填） |
| PUT | `/api/comm/points/{id}` | 修改 |
| POST | `/api/comm/points/batch-delete` | 底部「删除」，body `{Ids:[…]}` |
| POST | `/api/comm/reload` | 「立即生效」，文案带配置/设备/点位三段计数 |

写操作限 `admin`。

### 3. 页面

- 查询条：`部位:[下拉] 所属设备:[下拉] ☐显示全部 [🔍搜索] [↻重置] [＋新增点位变量]`
- 表格：`▦ | 操作(修改) | 部位 | 当前值 | 变量编码 | 变量名称 | 变量说明 | 所属设备 | PLC地址/MDI变量名 | 数据类型 | 可读可写 | 读取间隔 | 启用 | 是否删除`，列多可横向滚动
- 底部：`删除 / 刷新 / 立即生效`
- 弹窗 `CommPointEditWindow` 770×460「通讯点位设置-编辑」：左列 部位*（下拉）/ 变量名称* / 所属设备*（下拉）/ 数据类型*（下拉）/ 读取间隔* / 启用；右列 变量编码*（下拉可输入）/ 变量说明* / PLC地址/MDI变量名* / 可读可写*（下拉）/ 当前值 / 是否删除

### 4. 实测（SQLite，20 条点位样例，端口 5127）

| 场景 | 结果 |
|---|---|
| 点位列表 | `0`，20 条；双面机 / DF_BartrolPressure_Pulling_Section / DB4.DBD12 / Float / ReadWrite / 200 / 启用 |
| 末两条 | DF_BartrolSpeed_17 DB4.DBD84、_18 DB4.DBD88（与截图步进 4 一致） |
| 下拉 | 部位 4 项（双面机/面纸接纸机/单面机1/单面机2）、设备同名 4 项、类型 6 项、读写 3 项 |
| position=双面机 / device=双面机 | 各 20 条 |
| 新增 DF_TEST_01（RW=ReadOnly，500ms） | `0 已新增`，F_ID=21，RW/间隔正确回显 |
| 修改（Int/WriteOnly/300/停用） | `0 已保存`，四项全部落库 |
| 变量编码为空 | `-1 变量编码不能为空` |
| 勾选批量删除 | `0 已删除 1 条`，showAll 见 `IsDelete=true` |
| 立即生效 | `已重新加载 5 条通讯配置、12 个通讯设备、20 个点位变量（…仅刷新服务端缓存）` |
| operator 新增 | `403 仅管理员可维护通讯设置` |

### 5. 待定

- 当前值为手动占位，PLC/OPC UA 采集未接入，所以「立即生效」仍只刷新服务端缓存。
- 报警相关四列（F_IsAlarm/F_AlarmInterval/F_AlarmOffset/F_DataOK*）接口已带出，页面未做编辑入口，需要时再加一栏。

---

## 二十三、系统设置（TB_Sys_Config）

基础信息 → 系统设置，纯表单页，字段和截图一一对应。

### 1. 表结构 `db/sqlserver_sys_config.sql`

键值对表：`F_Key / F_Value / F_Desc / F_Editor / F_EditTime / F_ID`。脚本带建表保护 + 五条默认值（与截图一致）。

| F_Key | 默认值 | 界面 |
|---|---|---|
| UpdateUrl | http://127.0.0.1:7776/BtsClientUpdate.xml | 自动更新URL（文本框，440 宽） |
| StartPage | SF1生管 | 生管控制起始页（下拉，选项来自 S_Permissions 的菜单节点） |
| ShowTaskbar | True | 是否显示任务栏（是/否下拉） |
| Language | zh-CN | 语言（zh-CN / en-US） |
| ShowGluePosition | False | 显示糊机部位选择（复选框） |

### 2. 接口

| 方法 | 路径 | 说明 |
|---|---|---|
| GET | `/api/system/settings` | 返回五个参数值 + 起始页下拉（S_Permissions 菜单节点）+ 语言下拉；无记录时给默认值 |
| POST | `/api/system/settings` | 保存五个参数（管理员），返回「已保存配置（客户端下次启动生效）」 |

读取不限角色，保存限 `admin`；`UpdateUrl` 为空时拒绝。

### 3. 页面

- 左对齐标签（右对齐 140 宽）+ 输入控件：URL 440、起始页 440、任务栏 440、语言 240，最后一行「☐ 显示糊机部位选择」
- 左下 `保存配置` 深蓝按钮，右侧跟一行状态文字
- 新增 `SystemSettingView.xaml` + `SystemSettingViewModel`，宿主是 `BasicInfoView` 的 `SystemHost`，`Visibility` 绑 `SystemVisibility`；左侧菜单点「系统设置」时 `LoadAsync()`

### 4. 实测（SQLite，端口 5127）

| 场景 | 结果 |
|---|---|
| 首次读取 | `0`，五个默认值与截图一致（URL/ SF1生管 / True / zh-CN / False） |
| 起始页下拉 | 取 S_Permissions 菜单节点（测试库 5 项，真实库按功能管理菜单全量） |
| 语言下拉 | `zh-CN`、`en-US` |
| 保存（任务栏=否、糊机部位=是） | `0 已保存配置（客户端下次启动生效）` |
| 再读回 | `ShowTaskbar=False`、`ShowGluePosition=True`，落库生效 |
| URL 为空 | `-1 自动更新URL不能为空` |
| operator 保存 | `403 仅管理员可保存系统设置` |
| operator 读取 | `0`，可正常读 |

### 5. 说明

- 「生管控制起始页」的选项来自功能管理的菜单数据（S_Permissions 里 SP_Type=菜单 且非根节点）；现场库里就是 生管总控/SF1生管…这一批。
- 保存后由客户端下次启动读取生效，服务端不主动下发；任务栏显隐、语言切换的真实效果要等主界面把这些参数接上（目前主界面固定布局）。
- 糊机部位选择开关已存库，图形化控制页尚未消费该开关。

---

## 二十四、API授权（S_ApiUsers / S_Apis / S_ApiAuthorizes）

基础信息 → API授权，左右两栏，底部「授权」。

### 1. 三张表 `db/sqlserver_api_auth.sql`

| 表 | 用途 | 关键列 |
|---|---|---|
| `S_ApiUsers` | 左表：对外接口调用账号 | F_Account 账号、F_Secret 秘钥、F_SystemName 系统名称、F_IsUse 启用、F_IsDelete、审计、F_ID |
| `S_Apis` | 右表：对外接口清单 | F_Desc 接口说明、F_Url Url路径、F_SystemName 系统名称、F_IsUse 启用、F_IsDelete、审计、F_ID |
| `S_ApiAuthorizes` | 授权关系 | F_ApiUserId、F_ApiId、F_IsUse、F_Editor、F_EditTime、F_ID |

脚本带建表保护，样例数据为截图同款：3 个账号（test/1/测试账号、baoche/123#/抱车系统1、js/1/江苏）与 14 个接口（添加生产订单 … 获取接纸机本批和下批数据）。

### 2. 接口

| 方法 | 路径 | 说明 |
|---|---|---|
| GET | `/api/system/api-users?showAll=` | 账号列表 |
| POST | `/api/system/api-users` | 新增账号（账号必填、未删记录查重，返回自增 ID） |
| PUT | `/api/system/api-users/{id}` | 修改账号（秘钥/系统名称/启用） |
| GET | `/api/system/apis?userId=&showAll=` | 接口清单；带 `userId` 时按授权关系算 `Authorized`，供右表勾选 |
| POST | `/api/system/apis/authorize` | 保存授权：`{UserId, ApiIds:[…]}`，**整组替换**（先清该账号的授权关系再按本次勾选重建） |

写操作限 `admin`；未选账号时返回「请先在左侧选择账号」。

### 3. 页面

- 左表：`▦ | 账号 | 秘钥 | 系统名称 | 启用`，行选中深蓝白字，选中账号即刷新右表
- 右表：`▦ | 授权(勾选) | 接口说明 | Url路径 | 系统名称 | 启用`；「授权」列勾选表示该账号当前已被授权
- 底部：左侧状态文字（`账号 / 接口 N 个，已授权 M 个`），右侧深蓝「授权」按钮 → 保存并回读
- 新增 `ApiAuthView.xaml` + `ApiAuthViewModel`，宿主 `BasicInfoView` 的 `ApiAuthHost`，`Visibility` 绑 `ApiAuthVisibility`

### 4. 实测（SQLite，端口 5127/5129）

| 场景 | 结果 |
|---|---|
| 账号列表 | `0`，3 条：test/1/测试账号、baoche/123#/抱车系统1、js/1/江苏，均启用 |
| 接口清单 | `0`，14 条：添加生产订单 /api/ErpOrder/AddOrders … |
| 账号1 的接口（未授权） | 授权数 0 |
| 授权 test 前 3 个 | `0 已授权 test 共 3 个接口` |
| 读回 | 1/2/3 已授权，第 4 条未授权 |
| 改成只授权第 2 个 | `0 已授权 test 共 1 个接口`，读回授权数 1（整组替换生效） |
| 未选账号 | `-1 请先在左侧选择账号` |
| 新增账号 mes | `0 已新增`，F_ID=4（改前返回 0，已修为 `ExecuteReturnEntityAsync`） |
| 重复账号 mes | `-1 账号已存在` |
| 新增账号 plc1 | `0 已新增`，F_ID=5，列表变 5 条 |
| operator 授权 | `403 仅管理员可维护 API 授权` |

### 5. 说明

- 授权是「整组替换」语义：点「授权」时，右表勾选哪些就授权哪些，未勾选的会被撤销。
- 左表截图里没有新增/删除按钮，但接口已备好 POST/PUT（账号新增、改秘钥），实际现场账号一般由管理员在后台加；需要页面上给出「新增账号」按钮我随时补。
- 对外接口本身还是清单+授权标记，真正的接口鉴权（用 F_Account/F_Secret 换 Token、按 Url 判权）还没实现，需要时接进一个 ApiKey 中间件。

---

## 二十五、订单颜色设置（TB_Order_ColorSet）

基础信息 → 订单颜色设置，一张 8 行颜色表 + 底部保存与红色优先级说明。

### 1. 表结构 `db/sqlserver_order_color.sql`

| 列 | 类型 | 说明 |
|---|---|---|
| F_Condition | nvarchar(50) | 条件：首笔订单 / 前3笔订单 / 插单 / 修改订单 / 新增订单 / 复制订单 / 重做订单 / 默认 |
| F_Priority | int | 优先级，数字越小越优先 |
| F_BackColor | nvarchar(20) | 背景颜色 `#RRGGBB`，空=无色 |
| F_FontColor | nvarchar(20) | 字体颜色 `#RRGGBB`，空=不设置（截图前两行为空框） |
| F_IsUse | bit | 启用 |
| F_Editor / F_EditTime | | 审计 |
| F_ID | bigint identity | 主键 |

样例与截图一致：首笔订单 #0000FF/1、前3笔订单 #F7941E/2、插单 #FFFF99/3、修改订单 #FF9EC4/4、新增订单 #90EE90/5、复制订单 #90EE90/6、重做订单 #FF9EC4/7、默认 #FFFFFF/8。

### 2. 接口

| 方法 | 路径 | 说明 |
|---|---|---|
| GET | `/api/system/order-colors` | 按优先级升序返回全表 |
| POST | `/api/system/order-colors` | 整表保存：`{Items:[{Id,Condition,Priority,BackColor,FontColor,IsUse}]}`，逐行按 Id（缺 Id 时按条件）匹配，无记录则插入 |

保存限 `admin`，空提交拒绝。

### 3. 页面

- 表格列：`条件 | 优先级 | 背景颜色 | 字体颜色 | 启用`，行高 36、隔行 `#F7F9FB`
- 优先级为可编辑文本框；背景/字体颜色是色块按钮，点击弹调色板（24 个常用色 + 无颜色），选完立即反映在色块上
- 底部：`保存` 深蓝按钮 + 红字提示「优先级数量越小表示优先级越高，例如当一行数据同时满足几个条件的时候，最终显示的是优先级最高的条件颜色！」
- 新增 `OrderColorView.xaml`、`OrderColorPickWindow.xaml`、`OrderColorViewModel`；宿主 `BasicInfoView` 的 `OrderColorHost`，`Visibility` 绑 `OrderColorVisibility`

### 4. 实测（SQLite，端口 5130）

| 场景 | 结果 |
|---|---|
| 读取 | `0`，8 条按优先级 1..8 排序；首笔订单 #0000FF、字体为空；插单起字体 #000000 |
| 保存 2 条（改优先级 5 + 绿色 + 白色字体 + 停用） | `0 已保存 2 条订单颜色设置` |
| 读回 | 该行 Priority=5、BackColor=#00FF00、IsUse=False 已落库，其余未动 |
| 空提交 | `-1 没有需要保存的行` |
| operator 保存 | `403 仅管理员可保存订单颜色设置` |

### 5. 说明

- 颜色是自由 `#RRGGBB` 字符串，调色板只是快捷入口，直接改库换色也生效。
- 这张表目前只存不消费：图形化控制页工单彩条还没读这些颜色（要接的话按 条件→优先级 匹配后给行着色，我可以接着做）。
- 条件名称与现场的「首笔订单/前3笔订单/插单…」一致，若现场还有其他条件（如「换单」「急单」），加行即可，页面无需改动。

---

## 二十六、IPS部位显示/隐藏（TB_Ips_PartDisplay）

基础信息 → IPS部位显示/隐藏，三列表格 + 底部保存。

### 1. 表结构 `db/sqlserver_ips_parts.sql`

| 列 | 类型 | 说明 |
|---|---|---|
| F_Code | nvarchar(40) | 部位编码，如 GlueGU1 / WrapLS2 |
| F_Name | nvarchar(100) | 部位名称，如 糊机胶水-1层 |
| F_IsShow | bit | 显示/隐藏（勾选=显示） |
| F_SortNo | int | 排序号，页面按它升序 |
| F_Editor / F_EditTime | | 审计 |
| F_ID | bigint identity | 主键 |

样例为截图同款 18 个部位：GlueGU1-3（糊机胶水 1~3 层）、GlueSF1-3（单面机 1~3 胶水）、WrapGU1-3（糊机包角 1~3 层）、WrapGUAdd1/2（附加烘缸 1/2）、WrapLSO（面纸包角）、WrapMS1/WrapLS1/WrapMS2/WrapLS2/WrapMS3/WrapLS3（1~3 芯/里包角）。

### 2. 接口

| 方法 | 路径 | 说明 |
|---|---|---|
| GET | `/api/system/ips-parts` | 按排序号返回全表 |
| POST | `/api/system/ips-parts` | 整表保存：`{Items:[{Id,Code,Name,IsShow,SortNo}]}`，按 Id（缺 Id 按 Code）匹配，缺失则插入 |

保存限 `admin`，空提交拒绝。

### 3. 页面

- 表格列：`部位编码 | 部位名称 | 显示/隐藏`；部位编码加粗、行高 36、隔行 `#F7F9FB`
- 「显示/隐藏」是可编辑勾选框，直接勾掉即隐藏该部位
- 底部 `保存` 深蓝按钮 + 右侧状态文字
- 新增 `IpsPartView.xaml` + `IpsPartViewModel`；宿主 `BasicInfoView` 的 `IpsPartHost`，`Visibility` 绑 `IpsPartVisibility`

### 4. 实测（SQLite，端口 5131）

| 场景 | 结果 |
|---|---|
| 读取 | `0`，18 条，顺序 GlueGU1 → WrapLS3，全部 IsShow=True（与截图一致） |
| 保存（隐藏 GlueGU1、WrapGUAdd1） | `0 已保存 2 个部位的显示设置` |
| 读回 | GlueGU1=False、WrapGUAdd1=False，GlueGU2 仍 True（只改提交的行） |
| 空提交 | `-1 没有需要保存的行` |
| operator 保存 | `403 仅管理员可保存 IPS 部位显示设置` |

### 5. 说明

- 这份清单就是图形化控制页的部位开关白名单：编码（GlueGU1…）与主界面各部件的标签一一对应。
- 目前只存不消费，图形化控制页还没按开关隐藏部件；接的话按 F_Code 找控件切 Visibility。
- 现场表格可继续往下滚动，截图只到 WrapLS3；如后续还有部位（如天桥/纵切相关），按同样格式加行即可。

---

## 二十七、订单扩展字段设置（TB_Order_ExtField）

基础信息 → 订单扩展字段设置，18 个 Define 槽位，左上只有一个「刷新」，改动即自动保存。

### 1. 表结构 `db/sqlserver_order_ext_field.sql`

| 列 | 类型 | 说明 |
|---|---|---|
| F_Seq | int | 序号 1..18 |
| F_Code | nvarchar(40) | 字段编码 Define1..Define18（固定） |
| F_JsonCode | nvarchar(40) | Json 字段编码 ex1..ex18（订单扩展值以此键存 Json） |
| F_Name | nvarchar(100) | 扩展字段显示名称 |
| F_DataType | nvarchar(20) | 数据类型 string / int / bool / decimal / datetime |
| F_IsShowInList | bit | 是否要在列表中显示 |
| F_Editor / F_EditTime | | 审计 |
| F_ID | bigint identity | 主键 |

样例：Define1 ex1「文本扩展」string 勾选、Define2 ex2「数字扩展2」int 勾选、Define3 ex3「布尔扩展3」bool 勾选，Define4..18 空且未勾选（与截图一致）。

### 2. 接口

| 方法 | 路径 | 说明 |
|---|---|---|
| GET | `/api/system/order-ext-fields` | 按序号返回 18 行 |
| POST | `/api/system/order-ext-fields` | 保存：`{Items:[{Id,Seq,Code,JsonCode,Name,DataType,IsShowInList}]}`，按 Id（缺 Id 按 Code）匹配，缺失则插入 |

保存限 `admin`，空提交拒绝。

### 3. 页面

- 顶部：`刷新` 深蓝按钮 + 右侧状态文字
- 表格列：`序号 | 字段编码 | Json字段编码 | 扩展字段显示名称 | 数据类型 | 是否要在列表中显示`
- 序号与字段编码只读；Json 字段编码、显示名称可直接输入（失焦提交）；数据类型是下拉（string/int/bool/decimal/datetime）；最后一列勾选框可勾
- 没有「保存」按钮：单元格编辑提交、下拉切换、勾选框点击都会立即整表保存并刷新状态文字
- 新增 `OrderExtFieldView.xaml` + `OrderExtFieldViewModel`；宿主 `BasicInfoView` 的 `OrderExtHost`，`Visibility` 绑 `OrderExtVisibility`

### 4. 实测（SQLite，端口 5132）

| 场景 | 结果 |
|---|---|
| 读取 | `0`，18 行；Define1-3 为 ex1/ex2/ex3 + 文本扩展/数字扩展2/布尔扩展3 + 勾选，Define4 起为空 |
| 保存 Define4（ex4/日期扩展4/datetime/勾选） | `0 已保存 1 个扩展字段` |
| 读回 | Define4 = ex4 / 日期扩展4 / datetime / True；Define1 未受影响；Define5 仍空 |
| 空提交 | `-1 没有需要保存的行` |
| operator 保存 | `403 仅管理员可保存订单扩展字段设置` |

### 5. 说明

- 18 个槽位是固定的（订单表结构决定），页面只维护每格的 Json 键、显示名、类型和列表开关。
- 只在勾选「是否要在列表中显示」的字段才会出现在工单列表里，现在前 3 个是启用状态。
- 页面无保存按钮是照搬现场：编辑提交即自动保存，避免管理员忘记点保存。

---

## 二十八、基础信息分组与产线楞型（TB_Line_Flute / TB_Line_FluteRule）

基础信息页签左侧菜单扩成两组：**基础信息**（11 项）+ **系统设置**（12 项），并实现其中的「产线楞型」。

### 1. 左侧菜单分组

- 菜单模型加 `IsGroup`：分组标题只显示灰条（`#E7EBF0`、左对齐、高 30），不可选中；点到分组时自动回到上一个可选菜单
- 基础信息组：产线楞型 / 原纸资料 / 班组资料 / 楞型错位资料 / 基础楞型资料 / 瓦线楞型配置 / 生产路线 / 停机原因维护 / 刀头作业管理 / 能耗粉耗配置 / 生产目标值设置
- 系统设置组沿用原有的功能管理、角色管理、用户管理、数据字典、通讯设置、系统设置、API授权、个人信息、订单颜色设置、IPS部位显示/隐藏、订单扩展字段设置、打印标签设置
- 切换菜单时按 key 加载对应子页（产线楞型、订单颜色、IPS部位、扩展字段、API授权、系统设置、通讯设置）

### 2. 表结构 `db/sqlserver_line_flute.sql`

`TB_Line_Flute`（门幅+楞型唯一索引）：

| 分组 | 列 |
|---|---|
| 主键 | F_DoorWidth 门幅(mm)、F_FluteType 楞型 |
| 厚度 | F_Thickness、F_Thickness1/2/3 |
| 克重 | F_WeightThreshold1/2/3 纸板克重临界值 |
| 切长修边 | F_MaxSlit 最大剖数、F_MinCutLength、F_MaxCutLength、F_MinTrim、F_MaxTrim |
| 堆码 | F_UpperStackLimit、F_LowerStackLimit、F_StackOpenThreshold1/2/3、F_UpperStackCount1/2/3、F_LowerStackCount1/2/3 |
| 压线 | F_SmallLine、F_SmallLineDeepen、F_PlainLineDepth、F_NormalLineDepth、F_DeepLineDepth |
| 其它 | F_MaxSpeed、F_RollerCount、F_Trim、软删/审计、F_ID |

`TB_Line_FluteRule`（页面底部规则，单行）：F_AutoTrimEnabled 自动修边规则启用、F_AutoTrimThreshold 修边阈值、F_AutoTrimType 修边类型、F_ThicknessCompressRate 压缩率、F_StackCountBasis 出垛判定依据、F_StackDirection 排垛方向、F_ThicknessCalcMode 厚度计算模式。

样例 11 条，首行与截图一致：2800 / 3A / 厚度 4.34、克重临界值 210/400/590、厚度 4.36/4.31/4.30、最大剖数 7、切长 500~4500、修边 0~300、上/下堆码限高 1800/1700、出垛 7/300、小压线 0/0、压线深度 200/440/350、最大车速 300、锟数 0。

### 3. 接口

| 方法 | 路径 | 说明 |
|---|---|---|
| GET | `/api/base/line-flutes?fluteType=&showAll=` | 按门幅、楞型排序，楞型模糊过滤 |
| POST | `/api/base/line-flutes` | 新增；门幅与楞型必填，重复（同门幅+同楞型）拒绝 |
| PUT | `/api/base/line-flutes/{id}` | 修改，保留创建人与创建时间 |
| DELETE | `/api/base/line-flutes/{id}` | 软删（F_IsDelete=true） |
| POST | `/api/base/line-flutes/refresh-orders` | 立即更新订单（当前刷新服务端缓存并回条数） |
| GET | `/api/base/line-flute-rules` | 读取底部规则；无记录时返回截图默认值 |
| POST | `/api/base/line-flute-rules` | 保存底部规则 |

写操作限 `admin`。

### 4. 页面

- 查询条：`楞型名称` 输入 + 搜索 / 重置 / ＋新增产线楞型 / 立即更新订单 + 右侧状态文字
- 表格：`序号 | 操作(修改/删除) | 门幅(mm) | 楞型 | 厚度(mm) | 厚度1~3 | 克重临界值1~3 | 最大剖数 | 最小/最大切长 | 最小/最大修边 | 上/下堆码限高 | 出垛开数临界值 | 上/下堆码出垛数 | 小压线 | 小压线加深 | 平/普/深压线深度 | 最大车速 | 锟数数量 | 修边`，横向滚动，行高 34、隔行 `#F7F9FB`、选中行深蓝白字
- 弹窗 `LineFluteEditWindow` 1180×700，三列布局照搬现场：门幅* / 楞型* / 厚度 → 克重临界值与厚度 1~3 → 剖数切长 → 修边与堆码限高 → 三组出垛临界值与上下垛数 → 小压线与三种压线深度 → 车速/锟数/修边 → 创建人、创建时间、修改人、修改时间（只读），底部 取消 / 确定；门幅与楞型必填校验
- 底部规则条：`自动修边规则启用` + 修边阈值 + 修边类型下拉 + 压缩率；第二行 `出垛数设置判定依据`、`堆码排垛默认排出方向`、`纸板厚度计算模式`，红字标签同截图；任一改动立即保存
- 新增 `LineFluteView.xaml(.cs)`、`LineFluteEditWindow.xaml(.cs)`、`LineFluteViewModel`；宿主 `BasicInfoView` 的 `LineFluteHost`，`Visibility` 绑 `LineFluteVisibility`

### 5. 实测（SQLite，端口 5133 / 5134）

| 场景 | 结果 |
|---|---|
| 列表 | 11 条，门幅升序再按楞型 |
| 楞型过滤 3A | 2 条（2500/3A、2800/3A） |
| 新增 2800/7C | `0 已新增产线楞型`，返回自增 Id=12 |
| 重复新增同门幅同楞型 | `-1 门幅 2800 / 楞型 7C 已存在` |
| 修改 Id=12（厚度 7.75、修边 20） | `0 已保存产线楞型`，读回已生效，创建人保留 |
| 规则读取 | 返回截图默认值（未启用、10、不修边、0.8、剁数、操作侧、克重区间模式） |
| 规则保存并读回 | 7 项全部落库（启用、8、修边、0.85、开数、非操作侧、楞型模式） |
| 立即更新订单 | `0 已重新加载 12 条产线楞型（订单侧刷新将在订单接口联调后生效）` |
| 删除 | `0 已删除产线楞型`，列表回 11 条 |
| operator 新增 | `403 仅管理员可维护产线楞型` |

### 6. 说明

- 门幅与楞型组合唯一，SQL Server 侧建了带 `WHERE F_IsDelete = 0` 的唯一索引，软删后可重新录入同一组合。
- 底部规则是产线级全局配置，存单行表，页面无保存按钮、改动即存。
- 「立即更新订单」目前只刷新服务端缓存；等订单接口联调后改为按新楞型重算在制订单的切长/修边/堆码。
- 基础信息分组其余 10 项（原纸资料、班组资料、楞型错位资料、基础楞型资料、瓦线楞型配置、生产路线、停机原因维护、刀头作业管理、能耗粉耗配置、生产目标值设置）仍是占位卡，等现场截图逐页复刻。

---

## 二十九、原纸资料（TB_Paper_Info / TB_Paper_BrandParam / TB_Paper_GlueValue）

基础信息 → 原纸资料；「详情」打开「原纸品牌信息修改」弹窗（供应商张力表 + 胶水值网格）。

### 1. 表结构 `db/sqlserver_paper.sql`

| 表 | 用途 | 关键列 |
|---|---|---|
| `TB_Paper_Info` | 原纸主数据 | F_Code 原纸代号（唯一，区分大小写）、F_GramWeight 克重(gsm)、F_PaperWidth 门幅(mm)、F_Brand 品牌、F_RemainLS2/MS3/LS3 残卷、软删/审计、F_ID |
| `TB_Paper_BrandParam` | 品牌信息：按 原纸+供应商 | F_Supplier 供应商、F_RatedTension 额定接纸机张力、F_SteamGsm 蒸汽克重、F_GlueGsm 胶水克重、F_WrapGsm 包角克重、F_TensionLS0/MS1/LS1/MS2/LS2/MS3/LS3 各部位额定张力(daN)、审计、F_ID |
| `TB_Paper_GlueValue` | 胶水值 | F_MachineType 单面机/双面机、F_FluteType 楞型、F_Layer 层数、F_GlueValue 胶水值、审计、F_ID |

样例：13 条原纸（J/Z/S/K/M/L/N/P/Q/R/T/U/V，克重 120~200、门幅 2200~2800、品牌玖龙/理文/晨鸣）；原纸 J 的品牌信息带 2 个供应商（胶水克重 200 / 230）与 10 条胶水值（单面机 A/B/C/E、双面机 3A/3B/3C/3E/4BA/4BC 各 1 层），与截图数值一致。

### 2. 接口

| 方法 | 路径 | 说明 |
|---|---|---|
| GET | `/api/base/papers?code=&showAll=` | 原纸列表，代号模糊过滤（区分大小写） |
| POST | `/api/base/papers` | 新增原纸；代号必填，同代号拒绝 |
| PUT | `/api/base/papers/{id}` | 修改；改代号时品牌参数与胶水值的 F_PaperCode 一起迁移 |
| DELETE | `/api/base/papers/{id}` | 软删 |
| GET | `/api/base/papers/{code}/brand-info` | 读取供应商行 + 胶水值行 |
| POST | `/api/base/papers/{code}/brand-info` | 保存：整组替换该原纸的供应商行与胶水值 |

写操作限 `admin`。

### 3. 页面

- 查询条：`原纸代号（区分大小写）` + 搜索 / 重置 / ＋新增原纸
- 表格：`序号 | 操作(修改/删除) | 原纸代号(加粗) | 克重(gsm) | 门幅(mm) | 品牌 | LS2残卷 | MS3残卷 | LS3残卷 | 详情`
- 新增/修改弹窗 `PaperEditWindow` 470×360：原纸代号 / 克重 / 门幅 / 品牌 / LS2·MS3·LS3 残卷
- 详情弹窗 `PaperBrandWindow` 1400×860，照搬现场：
  - 上表：`供应商 | 额定接纸机张力 | 蒸汽克重(gsm) | 胶水克重(gsm) | 包角克重(gsm) | LS0/MS1/LS1/MS2/LS2/MS3/LS3 额定张力(daN)`，单元格直接编辑，表格底部带一个空白行用来新增供应商（未填供应商名的空白行保存时丢弃）；表格下方为灰底填充区，同现场
  - 「胶水值」是左侧一个小标签（浅蓝 `#B8D4E8`）+ 右侧细分隔线，不是通栏色条
  - 下方两块：`单面机`（楞型 A/B/C/E + 值）、`双面机`（楞型 3A/3B/3C/3E/4BA/4BC + 层 + 值），值可编辑
  - 右下「关闭」：关闭时把供应商表与胶水值整组保存
- 新增 `PaperInfoView.xaml(.cs)`、`PaperEditWindow.xaml(.cs)`、`PaperBrandWindow.xaml(.cs)`、`PaperInfoViewModel`；宿主 `BasicInfoView` 的 `PaperHost`

### 4. 实测（SQLite，端口 5135）

| 场景 | 结果 |
|---|---|
| 原纸列表 | 13 条（J/K/L…），按代号排序 |
| 过滤 J | 1 条 |
| 品牌信息 | 供应商1(200)、供应商2(230)；胶水值 10 条（单面机 4 + 双面机 6，均 1 层） |
| 修改品牌信息（2 供应商 + 2 胶水值） | `0 已保存原纸 J 的 2 个供应商参数与 2 条胶水值` |
| 读回 | 供应商1 张力 15 / 胶水克重 205 / LS0 300；新增供应商3 胶水克重 240；胶水值只剩 2 条（整组替换生效） |
| 新增原纸 W | `0 已新增原纸`，Id=14 |
| 新增小写 j | `0 已新增原纸`（区分大小写，J 与 j 视为不同代号） |
| 修改 W→X（含残卷 120） | `0 已保存原纸` |
| 删除 | `0 已删除原纸` |
| operator 新增 | `403 仅管理员可维护原纸资料` |

### 5. 说明

- 原纸代号区分大小写，SQL Server 侧建了 `WHERE F_IsDelete = 0` 的唯一索引，软删后可重录同代号。
- 品牌信息是「按原纸整组替换」：关闭弹窗时把当前表格整体写回，删掉的行会真的消失。
- 主表中间那些被弹窗遮住的列（截图里只看到一串 170/150/200 数字）没敢猜：现在只落了代号/克重/门幅/品牌/三种残卷。等给一张不带弹窗的原纸资料表格截图，我把逐层克重/张力列补齐。

---

## 三十、班组资料（TB_Team_Info）

基础信息 → 班组资料；班次号 + 班组名称 + 班次时间段 + 班长 / 抱车工。

### 1. 表结构 `db/sqlserver_team.sql`

`TB_Team_Info`：F_ShiftNo 班次号（唯一，`WHERE F_IsDelete = 0` 唯一索引）、F_TeamName 班组名称、F_StartTime / F_EndTime 班次开始与结束时间（`HH:mm:ss` 文本，为空表示未设）、F_Leader 班长、F_Forklift1 / F_Forklift2 抱车工 1/2、软删与审计、F_ID。

样例 6 条与截图一致：

| 班次号 | 班组 | 开始 | 结束 | 创建时间 | 修改时间 |
|---|---|---|---|---|---|
| 01 | A | — | — | 2022-03-25 14:46:16 | 2025-05-28 13:07:21 |
| 02 | B | — | — | 2022-03-25 14:46:21 | 2025-04-22 11:22:41 |
| 03 | C | — | — | 2023-03-13 13:43:52 | — |
| 04 | D | 07:00:00 | — | 2023-04-14 09:55:43 | — |
| 07 | G | 2025-06-10 00:00:00 | — | 2025-06-10 14:37:41 | 2025-06-10 14:37:52 |
| 09 | STOP | 00:00:00 | 23:59:59 | 2022-02-07 13:07:53 | — |

### 2. 接口

| 方法 | 路径 | 说明 |
|---|---|---|
| GET | `/api/base/teams?name=&showAll=` | 列表，按班次号排序；name 同时匹配班组名称与班次号 |
| POST | `/api/base/teams` | 新增；班次号/班组名称必填，班次号重复拒绝 |
| PUT | `/api/base/teams/{id}` | 修改；创建人/创建时间保留，回写修改人与修改时间 |
| DELETE | `/api/base/teams/{id}` | 软删 |

时间入参统一归一：`15:00` / `15:00:00` / `2025-06-10 00:00:00` 都按 `HH:mm:ss` 存，空串存 null。写操作限 `admin`。

### 3. 页面

- 查询条：`班组名称` + 搜索 / 重置 / ＋新增班组
- 表格：`序号 | 操作(修改/删除) | 班次号 | 班组名称 | 开始时间 | 结束时间 | 班长 | 抱车工 1 | 抱车工 2 | 创建人 | 创建时间 | 修改人 | 修改时间`；选中行深蓝底白字、班次号加粗
- 弹窗 `TeamEditWindow` 660×450「班组资料设置-修改」：左右两列 —— 班次号* / 班长 / 结束时间* / 抱车工2 / 创建时间(只读) / 修改时间(只读)，右列 —— 班组名称* / 开始时间* / 抱车工1 / 创建人(只读) / 修改人(只读)；红色 * 标必填，底部取消/确定
- 新增 `TeamInfoView.xaml(.cs)`、`TeamEditWindow.xaml(.cs)`、`TeamInfoViewModel`；宿主 `BasicInfoView` 的 `TeamHost`

### 4. 实测（SQLite，端口 5136）

| 场景 | 结果 |
|---|---|
| 列表 | 6 条，按班次号 01/02/03/04/07/09 |
| 过滤 STOP | 1 条（09 / STOP） |
| 新增 05 / E（开始 15:00、结束 23:00） | `0 已新增班组`，Id=7，回写 `15:00:00` / `23:00:00` |
| 重复 05 | `-1 班次号 05 已存在` |
| 缺班组名称 | `-1 班组名称不能为空` |
| 修改 Id=7（E班组、15:30~23:30、补抱车工2、班长张三） | `0 已保存班组`，创建人保留、修改人写入 |
| 删除 | `0 已删除班组` |
| operator 新增 | `403 仅管理员可维护班组资料` |

### 5. 说明

- 班次号是唯一键，软删后可重录同一班次号。
- 开始/结束时间用文本存 `HH:mm:ss`：现场 04 是 07:00 白班、09 是 00:00 跨零点的 STOP 班，留空表示该班组不定班次时间。
- 「班组名称」查询会同时匹配班次号（截图里列表短，现场是按名称搜；这样输入 09 也能直接命中 STOP 班）。
- 本次联调的 SQLite 测试库用 `Database__AutoCreateTables=true` 重建（146 张表由 CodeFirst 生成），`TB_Team_Info` 因 bigint 自增在 SQLite 下 CodeFirst 失败，仍按老办法手工建表补 6 条样例。

---

## 三十一、内置账号初始化「将截断字符串或二进制数据」修复

### 1. 现场报错

```
warn: Corrugator.Infrastructure.MultiLine.LineRegistry[0]
      TB_Line 中没有可用的线路配置（需要 F_Code 与 F_ConnectionString），回退为单线路模式
info: Corrugator.Infrastructure.MultiLine.LineDbProvider[0]
      多库路由已就绪：1 条线路（默认 Line1）
warn: Startup[0]
      内置账号初始化失败（S_Users 是否已建表？）
      Microsoft.Data.SqlClient.SqlException (0x80131904): 将截断字符串或二进制数据。语句已终止。
```

（前两条是正常提示：没有配 TB_Line 就退化成单线路。真正要处理的是第三条。）

### 2. 根因

`S_Users` / `S_Roles` / `S_Permissions` 是现场老库已有的表，列宽按当年明文密码（`1`、`123#`）设计，典型 `SU_Password` 只有 `nvarchar(20)`。而现在的种子写的是 PBKDF2 哈希：

```
pbkdf2$100000$<16字节salt的Base64>$<32字节hash的Base64>
```

长度约 83~84 字符，超出 20 → SQL Server 直接抛 8152「将截断字符串或二进制数据」，整条 INSERT 被终止。表现就是三个内置账号一个都没写进去，登录报「账号或密码错误」。

### 3. 修复（两层）

**① 服务端启动自动加宽**（`AuthService.EnsureSeedColumnWidthsAsync`，只在 SqlServer 生效）

灌种子前先读 `INFORMATION_SCHEMA.COLUMNS`，逐个比对代码要求的宽度，只把「比要求更窄」的字符列 `ALTER COLUMN` 加宽，已够宽的不动，可重复执行：

| 表 | 列 | 最小宽度 |
|---|---|---|
| S_Users | SU_Account / SU_Password / SU_UserName / SU_PhoneNo / SU_StopPosition | 50 / **200** / 50 / 50 / 50 |
| S_Users | SU_Gender | 10 |
| S_Users | SU_Creator / SU_Editor | 20 |
| S_Roles | SR_Name / SR_Creator / SR_Editor | 50 / 20 / 20 |
| S_Permissions | SP_Name / SP_Type / SP_NameSpace / SP_Remark / SP_Creator / SP_Editor | 50 / 10 / 100 / 500 / 20 / 20 |

加宽动作会打日志：`[SeedFix] S_Users.SU_Password 由 20 加宽到 200`。

**② 失败时给准确原因**

`S_Users` / `S_Roles` 的插入包了 try/catch，异常重写成可读文案，不再只报「是否已建表？」：

```
写入 S_Users 失败（账号 admin，多半是 SU_Password/SU_UserName 列宽不足，PBKDF2 哈希需要 nvarchar(200)）：…
```

启动日志的 warning 也带上 `{Reason}`。

**③ 手工兜底脚本** `db/sqlserver_fix_seed_columns.sql`

不能重启服务、或想先看现状时，手工跑一遍：第 1 段列出三张表当前列宽，第 2~4 段按上表加宽，第 5 段复核 `SU_Password >= 200`。加宽不改数据，原明文密码仍是明文，登录照旧兼容「明文 / 32 位 MD5 / PBKDF2」三种。

### 4. 验证

用 SQLite 库跑了一遍完整启动（`AutoCreateTables=true` + `SeedData=true`）：

| 项 | 结果 |
|---|---|
| 启动日志 | `公共库内置账号初始化完成（admin / planner / operator）`，无 warning |
| 登录 admin / 123456 | `Code=0`，返回 `('admin','admin')` |
| S_Users 落库 | 3 条，`SU_Password` 长度 83 且以 `pbkdf2$` 开头 |
| S_Roles 落库 | admin / planner / operator |
| 班组接口回归 | `/api/base/teams` 返回 2 条，正常 |

### 5. 说明

- 加宽只处理字符列，不动 `bit`/`datetime2`/`int` 等类型；`SU_Account`、`SR_Name`、`SP_Name` 这些 NOT NULL 列加宽时保留 NOT NULL。
- 现场库如果已有账号，`EnsureSeedAsync` 会跳过账号插入，但菜单树仍会补写；列宽检查在菜单补写之前，所以老库的窄列同样会被先加宽。
- SQLite 测试库不走这套（`CurrentConnectionConfig.DbType != SqlServer` 直接 return），SQLite 侧仍按老办法手工建表。

---

## 三十二、TLS 协议版本锁定（禁止 TLS 1.0/1.1）

### 1. 现象

启动日志：

```
安全警告:协商的 TLS 1.0 是非安全协议，只有在为了实现向后兼容性才受支持。建议的协议版本为 TLS 1.2 及更高版本。
warn:  LineRegistry[0]  TB_Line 中没有可用的线路配置（需要 F_Code 与 F_ConnectionString），回退为单线路模式
info:  LineDbProvider[0]  多库路由已就绪：1 条线路（默认 Line1）
info:  Startup[0]  公共库内置账号初始化完成（admin / planner / operator）
info:  Now listening on: https://localhost:55824
info:  Now listening on: http://localhost:55825
```

其中后三条都是正常状态：`TB_Line` 未配置 → 单线路回退；内置账号已初始化成功；双端口是 VS / `dotnet run` 开发默认同时起的 HTTP 与 HTTPS（开发证书）端点。**只有第一条 TLS 1.0 警告需要处理**：握手时被 Schannel 协商降到了 TLS 1.0。

### 2. 改动

**服务端 `Program.cs`**：Kestrel 的所有 HTTPS 端点统一锁定 TLS 1.2 / 1.3

```csharp
builder.WebHost.ConfigureKestrel(kestrel =>
{
    kestrel.ConfigureHttpsDefaults(https =>
    {
        https.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13;
    });
});
```

明文 HTTP 端点不受影响；内网 HMI 与 API 之间仍走 `http://localhost:5099`。

**客户端 `ApiClient.cs`**：`HttpClientHandler` 同样锁定 TLS 1.2 / 1.3，并打开 gzip/deflate 解压

```csharp
var handler = new HttpClientHandler
{
    SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13,
    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
};
_http = new HttpClient(handler) { ... };
```

**`appsettings.json`**：显式指定监听 `http://localhost:5099`，避免开发环境随机起一个 HTTPS 开发证书端点；需要 HTTPS 时由反向代理（IIS / Nginx）在终止 TLS 后转发明文到本端口。

### 3. 说明

- 锁定后，对端如果只支持 TLS 1.0/1.1，握手会直接失败（而不是静默降级到不安全协议），日志会给出明确的握手错误。
- 数据库连接串 `Encrypt=False`，SQL Server 侧不参与 TLS 协商；后续若改成 `Encrypt=Strict`，需要单独确认 SQL Server 证书与协议版本。
- 若仍看到 55824/55825 这种随机双端口，说明是 Visual Studio 开发配置（IIS Express 自动生成的 launch 配置）覆盖了 `Urls`；在项目属性 → 调试里把启动 URL 固定为 `http://localhost:5099` 即可。

---

## 三十三、主窗顶栏菜单与现场截图对齐（图标 / 顺序 / 选中态 / 基础信息入口修复）

### 1. 对照依据

按现场主界面顶栏裁切图，主窗第一排共 7 个页签，顺序与文案固定为：

| 序 | 页签 | 目标图标 |
|----|------|----------|
| ① | 生管控制 | 齿轮（轮盘 + 中心孔） |
| ② | 图形化控制 | 文档框 + 山地折线 |
| ③ | 工单管理 | 单据图片框（山形 + 圆点） |
| ④ | 预警管理 | 徽章 + 对勾 |
| ⑤ | 报表管理 | 三柱柱状图 |
| ⑥ | 基础信息 | 三条横线（汉堡菜单） |
| ⑦ | QDM基础表 | 文档框 + 折线图 |

文字与顺序此前已与现场一致；本轮按裁切图逐格替换 5 个不符的 Path 图标（生管控制/工单管理/预警管理/基础信息/QDM基础表），并微调图形化控制、报表管理图标轮廓。

### 2. 改动清单

**`Views/MainWindow.xaml`**：7 个 `TabItem.Header` 内的图标 Path 全部按上表重绘，20×20、描边 1.3，颜色跟随页签 `Foreground`（未选 `#C8D3E0`，选中白色）。

**`App.xaml`（NavTabItem 样式）**：选中态去掉底部蓝色下划线，只保留浅藏青底 `#21375A` + 白色文字/图标，与现场选中页签（基础信息）观感一致；悬停底色 `#1A2B47` 不变。

**基础信息入口修复（顺带修掉的老问题）**：
- `MainWindow.xaml.cs` 页签切换 `case 5` 原误调 `Dictionary.LoadAsync()`（旧数据字典面板），改为 `await _viewModel.BasicInfo.InitializeAsync()`，进入「基础信息」时加载当前选中子页数据。
- `BasicInfoViewModel` 构造时默认选中基础信息组第一项「产线楞型」，避免首次进入是空白占位；新增公开 `InitializeAsync()`，按当前菜单走 `LoadForAsync`。
- `BasicInfoView` 订阅 `Loaded` 事件，首次加载时调用 `LoadCurrentPanelAsync()`，把默认子面板（产线楞型）数据拉起来；左侧菜单切换仍走原 `OnMenuSelectionChanged`。

### 3. 验证

- `dotnet build Corrugator.sln` 编译通过（无 error）。
- 7 个页签文案、顺序、图标与现场裁切图一一对应；选中/未选/悬停三态样式与现场顶栏一致。
- 切到「基础信息」默认打开「产线楞型」子页，不再落入旧数据字典；其余 6 个页签的数据加载路径不变。

### 4. 说明

- 图标为矢量 Path 轮廓，20×20 视口；后续若现场换成套图（PNG/SVG），只需替换各 `TabItem.Header` 内的 `Path`，布局与样式不动。
- 「基础信息」左侧仍有 8 项占位菜单（楞型错位资料、基础楞型资料、瓦线楞型配置、生产路线、停机原因维护、刀头作业管理、能耗粉耗配置、生产目标值设置），待对应现场截图后逐页复刻。

### 5. 二轮复核：图标轮廓修正 + 字号图标放大

对照更清晰的顶栏裁切图二次核对，修正两处图标轮廓并整体放大：

- **图标轮廓**
  - ③ 工单管理：图片框 + 双山峰（去掉首版误加的左上角圆点）。
  - ④ 预警管理：圆环 + 内部对勾（首版误做成靶心圆点，已改回徽章对勾）。
  - 其余：① 齿轮、② 图片框+山峰+圆点、⑤ 三柱柱状图、⑥ 汉堡三横线、⑦ 文档+折线，与现场一致。
- **尺寸放大**（解决「文字太小看不清」）：页签宽度 `104 → 132`；图标 `20×20 → 26×26`；页签文字 `12.5 → 14.5`，图标与文字间距加大；顶栏高度 64px 不变，内容居中。
- 编译 `dotnet build Corrugator.sln` 通过，无 error。

> 说明：WPF 为桌面端，改动需在 Windows 侧重新生成（Rebuild Solution）后生效；Linux 环境仅做编译校验，不运行界面。

### 6. 三轮：按钮文字白色修复（深底按钮黑字看不清）

**问题**：各页「搜索 / 重置 / ＋新增…」等深蓝底（`#1B4E8C`）按钮，样式里虽把 `Foreground` 设为白色，但自定义控件模板里的 `ContentPresenter` 未把前景色向下传递，生成的文本块回落到默认黑色，深底黑字看不清。

**修复**：
- 全局 `App.xaml` 默认按钮模板，以及各视图本地按钮样式（`QBtn / CommButton / QueryButton / DictToolButton / LoginButton` 等）的 `ContentPresenter`，统一加上 `TextElement.Foreground="{TemplateBinding Foreground}"`，把按钮前景色显式传给内部文本块。
- 白底表格内的文字、链接按钮（OpLink/DelLink 蓝/红）保持原有深色/彩色，未改动。
- 说明：`ContentPresenter` 本身没有 `Foreground` 属性，前景需通过 `TextElement.Foreground` 附加属性向下传递。

`dotnet build Corrugator.sln` 编译通过，无 error。

---

## 三十四、现网日志两类报错处理：208 缺表补齐脚本 + 4145 布尔 OR 语法修复

### 1. 日志现象（现场导出的 ExceptionMiddleware 日志）

| 错误号 | 现象 | 涉及接口 / 表 |
|--------|------|----------------|
| 208 对象名无效 | 新业务表未在现网 SQL Server 库中建表 | `/api/base/line-flutes`（TB_Line_Flute、TB_Line_FluteRule）、`/api/base/papers`（TB_Paper_Info / BrandParam / GlueValue）、`/api/base/teams`（TB_Team_Info）、`/api/system/settings`（TB_Sys_Config）、`/api/system/order-ext-fields`（TB_Order_ExtField）、`/api/system/order-colors`（TB_Order_ColorSet）、`/api/system/ips-parts`（TB_Ips_PartDisplay） |
| 4145 在应使用条件的上下文(在 'OR' 附近)中指定了非布尔类型的表达式 | SqlSugar 把捕获的布尔参数 `showAll` 直接拼进 WHERE，生成 `@p OR 列=...`，SQL Server 无法把参数当布尔条件 | `/api/system/api-users`、`/api/system/apis`，以及 base 三个列表接口同类写法 |

### 2. 4145 代码修复

**根因**：`Where(x => showAll || x.F_IsDelete != true)` 这类表达式里，`showAll` 是方法参数（捕获变量），SqlSugar 无法把它解析成 SQL 比较条件，原样输出为参数占位符，导致 `OR` 左侧不是布尔表达式。

**改法**：改成 SqlSugar 的条件追加 `WhereIF`，`showAll=true` 时不加删除过滤，`false` 时才追加 `F_IsDelete != true`：

```csharp
// 改前
.Where(r => showAll || r.F_IsDelete != true)

// 改后
.WhereIF(!showAll, r => r.F_IsDelete != true)
```

涉及 5 处：`BaseInfoController`（line-flutes / papers / teams）、`SystemController`（api-users / apis）。
其余 `列 IS NULL OR 列 = 0` 这类纯列条件保持不变（可正常翻译）。

### 3. 208 缺表：汇总幂等建表脚本

新增 `db/sqlserver_ensure_business_tables.sql`，把上述 10 张业务表一次性补齐：

- 每张表用 `IF NOT EXISTS (sys.tables / sys.indexes)` 守卫，**可重复执行**，已有表不改动、不丢数据；
- 含 3 个过滤唯一索引：门幅+楞型、原纸代号、班次号；
- 脚本末尾输出本次应存在的表清单，便于复核；
- 样例数据仍走各专题脚本（`sqlserver_line_flute.sql / paper.sql / team.sql` 等），本脚本只建结构。

> 执行位置：API 连接串指向的 IPS 公共库（BaseDB 已并入 IPS 库）。Base 鉴权表 `S_Users / S_Roles / S_ApiUsers ...` 由 `sqlserver_api_auth.sql / sqlserver_base_user_seed.sql` 负责，不在本脚本内。

### 4. 联调验证（SQLite 冒烟）

- `line-flutes / line-flute-rules / papers / teams / settings / order-ext-fields / order-colors / ips-parts` 均返回 200；
- `api-users / apis` 在 SQLite 因 `S_ApiUsers` 等 base 鉴权表未由 CodeFirst 建成（SQLite bigint 自增限制）报缺表；在 SQL Server 上由 api_auth 脚本建表后即可访问，日志中的 4145 布尔 OR 错误已随 WhereIF 修复消除。
- `dotnet build Corrugator.sln` 编译通过，无 error。

### 5. 上线步骤建议

1. 在现网 SQL Server 库先执行 `db/sqlserver_api_auth.sql`（鉴权表）与历史基础脚本；
2. 执行 `db/sqlserver_ensure_business_tables.sql` 补齐业务表；
3. 按需执行各专题样例脚本；
4. 重启 API，再从前端进入「基础信息 / 系统设置」各页核对。

---

## 三十五、系统设置从基础信息拆出：左上角圆环图标独立入口

### 1. 调整前

顶栏「基础信息」页左侧菜单里混着两组：基础信息 11 项 + 系统设置 12 项，用分组标题隔开。现场要求系统设置单独成入口，不与基础信息放在一起。

### 2. 改动方案（按确认：左上角圆环头像做成按钮，打开独立窗口）

- **`BasicInfoViewModel` 增加模式开关** `settingsOnly`：
  - `false`（基础信息页，默认）：左侧只列基础信息 11 项（产线楞型 / 原纸资料 / 班组资料 / 楞型错位 / 基础楞型 / 瓦线楞型 / 生产路线 / 停机原因 / 刀头作业 / 能耗粉耗 / 生产目标值）；
  - `true`（系统设置窗口）：左侧只列系统设置 12 项（功能 / 角色 / 用户 / 数据字典 / 通讯 / 系统设置 / API授权 / 个人信息 / 订单颜色 / IPS部位 / 订单扩展字段 / 打印标签）。
  - 菜单在构造时按模式生成，默认选中当前模式第一项；用户/角色/功能/字典/通讯等业务逻辑与子面板复用同一套，不重复实现。
- **新增 `SystemSettingsWindow`**：深藏青顶栏（#132136）+ 圆环靶心图标 + 标题「系统设置」+ 关闭按钮；内容复用 `BasicInfoView`，以 `settingsOnly: true` 构造 VM 并在 Loaded 时 `InitializeAsync()` 加载默认子页。
- **主窗左上角圆环改为按钮**：原装饰性圆框换成带悬停高亮的 `Button`，`Click=OnOpenSettings` 以 `Owner=主窗` 非模态打开系统设置窗口；顶栏其余 7 个页签与布局不变。

### 3. 文件清单

| 文件 | 改动 |
|------|------|
| `ViewModels/BasicInfoViewModel.cs` | 拆出 `BaseMenus / SystemMenus`，按 `settingsOnly` 生成 `Menu`，默认选中第一项 |
| `Views/SystemSettingsWindow.xaml(.cs)` | 新增独立系统设置窗口，复用 BasicInfoView |
| `Views/MainWindow.xaml(.cs)` | 圆环头像改按钮，点击打开 SystemSettingsWindow |
| `Views/BasicInfoView.xaml` | 左侧菜单注释改为通用描述 |

### 4. 验证

- `dotnet build Corrugator.sln` 编译通过，无 error。
- 基础信息页只显示基础信息菜单；点左上角圆环弹出系统设置窗口，窗口内只显示系统设置菜单，两边子面板数据加载路径不变。
- 说明：WPF 桌面端改动需在 Windows 侧 Rebuild 后生效；Linux 仅做编译校验。

### 5. 修正：系统设置改为内嵌切换，不弹独立窗口

按反馈取消独立 `SystemSettingsWindow`：

- 系统设置视图改为挂在主窗内容区的 `SettingsHost` 宿主上，与当前页签内容叠放；
- 点左上角圆环在主界面内打开/收回系统设置，不再 `Show()` 弹出二级窗口；
- 点任意顶栏页签自动收回设置页；再次点圆环可返回设置；
- 系统设置视图惰性构建（首次进入时按名取模板宿主），逻辑仍复用 `BasicInfoViewModel(settingsOnly: true)`。
- 已删除不再使用的 `SystemSettingsWindow.xaml(.cs)`。

`dotnet build Corrugator.sln` 编译通过，无 error。

### 6. 顶栏图标真正放大 + 文字白色（修复 Stretch=None 不生效）

**根因**：此前图标 Path 设了 `Width/Height=26` 但 `Stretch="None"`，矢量几何按原始坐标（约 10px）绘制，宽高不生效，所以图标一直偏小；文字未显式绑白色，跟随页签默认灰蓝前景，发灰看不清。

**修复**：
- 7 个页签图标 `Stretch="None" → "Uniform"`，宽高 `26 → 30`，描边 `1.3 → 1.5`，几何真正缩放到图标框；
- 页签文字显式 `Foreground="White"`、字号 `14.5 → 15`；
- `NavTabItem` 默认前景由灰蓝 `NavTextBrush` 改为 `White`，图标描边跟随页签前景，整体为白色。

`dotnet build Corrugator.sln` 编译通过，无 error；Windows 侧 Rebuild 后生效。

### 7. 修复：通讯设置视图残留宿主可见性绑定导致进系统设置报错

**现象**：点左上角圆环进入系统设置时，设计器/运行时报错 `在类型为 CommViewModel 的对象上找不到 CommVisibility 属性`（CommView.xaml 根 Grid）。

**根因**：CommView 早期嵌在基础信息页里，根 Grid 绑的是宿主 `BasicInfoViewModel.CommVisibility`；视图独立挂载后 DataContext 变成 `CommViewModel`，该属性不存在，绑定失败。

**修复**：去掉 CommView 根 Grid 上的 `Visibility="{Binding CommVisibility}"`，显隐完全由宿主 BasicInfoView 的 `CommHost` 控制；视图内部三个页签的 `ConfigTabVisibility / DeviceTabVisibility / PointTabVisibility` 仍由 CommViewModel 提供，保持不变。

`dotnet build Corrugator.sln` 编译通过，无 error。

### 8. 修复：进入系统设置 NullReferenceException（模板查找宿主为空）

**现象**：点左上角圆环打开系统设置时，`EnsureSettingsView()` 抛 `NullReferenceException`。

**根因**：`SettingsHost` 定义在 `MainTabs`（TabControl）的 `ControlTemplate` 内部，原先用窗口自己的 `Template.FindName` 查找，跨模板命名空间取不到，返回 null，给 null 设 Content 触发空引用。

**修复**：改从 `MainTabs.Template.FindName("SettingsHost", MainTabs)` 取宿主；查找前先 `ApplyTemplate()` 物化模板，避免模板未应用时为空。

`dotnet build Corrugator.sln` 编译通过，无 error。

### 9. 根治：深蓝底按钮文字发黑（全局 TextBlock 隐式样式压过白色继承）

**现象**：系统设置 / 基础信息各页「搜索 / 重置 / ＋新增…」按钮仍是黑字，之前给按钮加的白色前景不生效。

**根因**：`App.xaml` 全局隐式 `Style TargetType="TextBlock"` 里设了 `Foreground=#1E2A38`。样式 setter 优先级高于属性继承，按钮 ContentPresenter 生成的 TextBlock 会被这个隐式样式强制改成深色，按钮自身的白色 Foreground 继承不上去。

**修复**：从全局 TextBlock 样式中移除 `Foreground` 设置（保留字体族与字号）；文字颜色改由父级继承——深蓝底按钮继承白色，白底页面继承系统默认深色。各按钮样式本身的 `Foreground=White` 保持不变。

`dotnet build Corrugator.sln` 编译通过，无 error。

### 10. 主题主色统一为蓝色（对齐登录按钮 #1A6FD0）

**调整**：此前主按钮/选中行/强调文字用的是深藏青 `#1B4E8C / #1F5C99`，与登录按钮的亮蓝不一致。全局把主题色换成登录按钮同款蓝色系列：

| 用途 | 旧色 | 新色 |
|------|------|------|
| 主按钮 / 强调 | `#1B4E8C`、`#1F5C99` | `#1A6FD0` |
| 悬停 | `#245D9E` | `#3582D8` |
| 按下 | `#0E3866` | `#1662BB` |
| 浅强调 | `#2E86AB` | `#2E86C8` |

覆盖 `App.xaml` 全局画刷与各视图主按钮、选中行、链接文字；取色板里用户可选色值（OrderColorPickWindow）保持不变。

`dotnet build Corrugator.sln` 编译通过，无 error。

### 11. 选中页签背景与列表表头背景统一为主题蓝

**漏改项**：上一轮只换了按钮/强调色，两处背景仍是旧藏青：
- 顶栏选中页签 `NavActiveBrush #21375A`
- 数据表头 `TableHeaderBrush #12395E`

**修复**：两者都改为主题蓝 `#1A6FD0`；表头文字、页签文字本就是白色，保持不变。悬停底色 `#1A2B47` 与列分隔线维持原样。

`dotnet build Corrugator.sln` 编译通过，无 error。

### 12. 干净重编译并清理残留藏青

复查结论：`NavActiveBrush`、`TableHeaderBrush` 均已指向 `#1A6FD0`，无重复画刷、无外部主题字典；源码中旧值 `#21375A / #12395E / #0D2E4C` 已清零，表头分隔线改为浅蓝 `#3582D8`。

为排除旧 BAML 缓存干扰，已删除客户端 `bin/obj` 后重新 `dotnet build Corrugator.sln`，编译通过。若在 Visual Studio 中仍看到旧藏青，请执行「生成 → 清理解决方案」后再重新生成。

### 13. 整条顶栏改为蓝色

按要求把顶栏底色 `NavBgBrush` 由深藏青改为主题蓝 `#1A6FD0`；为保证选中页签在蓝底上仍有区分度，选中态 `NavActiveBrush` 调整为深蓝 `#0F56A0`，悬停 `#2E86C8`，顶栏文字 `NavTextBrush` 提亮为 `#E6F0FA`；左上角设置按钮悬停同步改为 `#2E86C8`。
