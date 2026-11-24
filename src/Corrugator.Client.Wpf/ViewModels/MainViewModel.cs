using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Contracts.Lines;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>主窗（Prism）：顶栏信息 + 瓦线切换 + 各业务页 VM</summary>
public class MainViewModel : BindableBase
{
    private readonly AppSession _session;
    private readonly ApiClient _api;

    private string _statusMessage = "就绪";
    private string _shiftName = "B";
    private string _lineName = "Line1";
    private string _version = "V 1.0.0.0";
    private string _nowText = string.Empty;
    private LineDto? _selectedLine;

    private bool _suppressLineChange;

    public MainViewModel(
        AppSession session,
        ApiClient api,
        DashboardViewModel dashboard,
        GraphicControlViewModel graphicControl,
        OrdersViewModel orders,
        AlarmsViewModel alarms,
        ReportViewModel report,
        DictionaryViewModel dictionary,
        BasicInfoViewModel basicInfo,
        ProcessParamsViewModel processParams)
    {
        _session = session;
        _api = api;
        Dashboard = dashboard;
        GraphicControl = graphicControl;
        Orders = orders;
        Alarms = alarms;
        Report = report;
        Dictionary = dictionary;
        BasicInfo = basicInfo;
        ProcessParams = processParams;
        NowText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public string ShiftName
    {
        get => _shiftName;
        set => SetProperty(ref _shiftName, value);
    }

    public string LineName
    {
        get => _lineName;
        set => SetProperty(ref _lineName, value);
    }

    public string Version
    {
        get => _version;
        set => SetProperty(ref _version, value);
    }

    public string NowText
    {
        get => _nowText;
        set => SetProperty(ref _nowText, value);
    }

    /// <summary>BaseDB.TB_Line 里的全部瓦线</summary>
    public ObservableCollection<LineDto> Lines { get; } = new();

    public LineDto? SelectedLine
    {
        get => _selectedLine;
        set
        {
            if (!SetProperty(ref _selectedLine, value) || _suppressLineChange || value is null)
            {
                return;
            }

            _session.LineCode = value.Code;
            _api.SetLine(value.Code);
            LineName = value.Code;
            StatusMessage = $"已切换到 {value.Name}（{value.Code}）";

            _ = ReloadAfterSwitchAsync(value);
        }
    }

    public DashboardViewModel Dashboard { get; }
    public GraphicControlViewModel GraphicControl { get; }
    public OrdersViewModel Orders { get; }
    public AlarmsViewModel Alarms { get; }
    public ReportViewModel Report { get; }
    public DictionaryViewModel Dictionary { get; }
    public BasicInfoViewModel BasicInfo { get; }
    public ProcessParamsViewModel ProcessParams { get; }

    /// <summary>顶栏只显示姓名（同现场：超级管理员），账号在基本信息里查</summary>
    public string UserDisplay => _session.User is null
        ? "未登录"
        : _session.User.DisplayName;

    public string ApiDisplay => AppConfig.BaseUrl;

    private async Task ReloadAfterSwitchAsync(LineDto line)
    {
        try
        {
            await SafeLoadAsync($"瓦线 {line.Code} 看板", Dashboard.LoadAsync);
            await SafeLoadAsync($"瓦线 {line.Code} 图形化", GraphicControl.LoadAsync);
            await SafeLoadAsync($"瓦线 {line.Code} 工单", Orders.LoadAsync);
        }
        catch (Exception ex)
        {
            StatusMessage = $"切换瓦线失败：{ex.Message}";
        }
    }

    /// <summary>登录后首屏加载：先取线路列表，再按默认线路加载业务数据</summary>
    public async Task InitializeAsync()
    {
        await LoadLinesAsync();

        await SafeLoadAsync("生产看板", Dashboard.LoadAsync);
        await SafeLoadAsync("图形化控制", GraphicControl.LoadAsync);
        await SafeLoadAsync("工单管理", Orders.LoadAsync);
    }

    private async Task LoadLinesAsync()
    {
        var result = await _api.GetAsync<List<LineDto>>("api/lines");
        if (!result.Success || result.Data is null || result.Data.Count == 0)
        {
            StatusMessage = result.Message ?? "未获取到瓦线配置，使用默认线路";
            return;
        }

        var defaultLine = result.Data.FirstOrDefault(l => l.IsDefault) ?? result.Data[0];

        _suppressLineChange = true;
        try
        {
            Lines.Clear();
            foreach (var line in result.Data)
            {
                Lines.Add(line);
            }

            SelectedLine = Lines.FirstOrDefault(l => l.Code == defaultLine.Code) ?? Lines[0];

            _session.LineCode = defaultLine.Code;
            _api.SetLine(defaultLine.Code);
            LineName = defaultLine.Code;
        }
        finally
        {
            _suppressLineChange = false;
        }

        StatusMessage = $"已连接 {Lines.Count} 条瓦线，当前 {defaultLine.Name}（{defaultLine.Code}）";
    }

    private async Task SafeLoadAsync(string name, Func<Task> action)
    {
        try
        {
            await action();
            StatusMessage = $"{name} 加载完成 {DateTime.Now:HH:mm:ss}";
        }
        catch (Exception ex)
        {
            StatusMessage = $"{name} 加载异常：{ex.Message}";
        }
    }
}
