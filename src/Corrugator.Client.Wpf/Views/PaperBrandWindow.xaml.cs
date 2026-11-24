using Corrugator.Client.Wpf.ViewModels;
using Corrugator.Shared.Contracts.Base;
using System.Collections.ObjectModel;
using System.Windows;

namespace Corrugator.Client.Wpf.Views;

/// <summary>原纸品牌信息修改（供应商张力表 + 胶水值网格），关闭时保存</summary>
public partial class PaperBrandWindow : Window
{
    private static readonly string[] SingleFaceFluteTypes = { "A", "B", "C", "E" };

    private static readonly string[] DoubleFaceFluteTypes = { "3A", "3B", "3C", "3E", "4BA", "4BC" };

    private readonly string _paperCode;
    private readonly PaperInfoViewModel _parent;

    public PaperBrandWindow(string paperCode, PaperBrandSaveRequest info, PaperInfoViewModel parent)
    {
        InitializeComponent();

        _paperCode = paperCode;
        _parent = parent;
        StatusText = $"原纸 {paperCode}：供应商 {info.Suppliers.Count} 个";

        Suppliers = new ObservableCollection<PaperSupplierRow>(info.Suppliers.Select(s =>
        {
            var row = new PaperSupplierRow
            {
                Id = s.Id,
                Supplier = s.Supplier,
                RatedTension = s.RatedTension,
                SteamGsm = s.SteamGsm,
                GlueGsm = s.GlueGsm,
                WrapGsm = s.WrapGsm,
                TensionLS0 = s.TensionLS0,
                TensionMS1 = s.TensionMS1,
                TensionLS1 = s.TensionLS1,
                TensionMS2 = s.TensionMS2,
                TensionLS2 = s.TensionLS2,
                TensionMS3 = s.TensionMS3,
                TensionLS3 = s.TensionLS3,
            };
            return row;
        }));

        SingleFaceGlues = BuildGlues("单面机", SingleFaceFluteTypes, info.GlueValues);
        DoubleFaceGlues = BuildGlues("双面机", DoubleFaceFluteTypes, info.GlueValues);

        Title = "原纸品牌信息修改";
        TitleText.Text = Title;
        DataContext = this;
    }

    public ObservableCollection<PaperSupplierRow> Suppliers { get; }

    public ObservableCollection<PaperGlueRow> SingleFaceGlues { get; }

    public ObservableCollection<PaperGlueRow> DoubleFaceGlues { get; }

    public string StatusText { get; private set; }

    private static ObservableCollection<PaperGlueRow> BuildGlues(string machineType, string[] fluteTypes,
        List<PaperGlueValueDto> existing)
    {
        var rows = new ObservableCollection<PaperGlueRow>();

        foreach (var flute in fluteTypes)
        {
            var match = existing.FirstOrDefault(g => g.MachineType == machineType && g.FluteType == flute);
            rows.Add(new PaperGlueRow
            {
                Id = match?.Id ?? 0,
                MachineType = machineType,
                FluteType = flute,
                Layer = match?.Layer ?? (machineType == "双面机" ? "1层" : null),
                GlueValue = match?.GlueValue ?? 0m,
            });
        }

        // 库里多出来的楞型也带出来，别丢
        foreach (var extra in existing.Where(g => g.MachineType == machineType && !fluteTypes.Contains(g.FluteType)))
        {
            rows.Add(new PaperGlueRow
            {
                Id = extra.Id,
                MachineType = extra.MachineType,
                FluteType = extra.FluteType,
                Layer = extra.Layer,
                GlueValue = extra.GlueValue,
            });
        }

        return rows;
    }

    private async void OnCloseClick(object sender, RoutedEventArgs e)
    {
        // 提交正在编辑的单元格
        SupplierGrid.CommitEdit(System.Windows.Controls.DataGridEditingUnit.Row, true);

        // 空白新增行未填供应商名的丢掉
        var request = new PaperBrandSaveRequest
        {
            Suppliers = Suppliers.Where(s => !string.IsNullOrWhiteSpace(s.Supplier)).Select(s => s.ToDto()).ToList(),
            GlueValues = SingleFaceGlues.Concat(DoubleFaceGlues).Select(g => g.ToDto()).ToList(),
        };

        var saved = await _parent.SaveBrandInfoAsync(_paperCode, request);
        StatusText = saved ? "已保存" : _parent.StatusMessage;

        if (!saved)
        {
            MessageBox.Show(this, _parent.StatusMessage, "原纸品牌信息", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        DialogResult = saved;
        Close();
    }
}
