using Corrugator.Shared.Contracts.Dictionary;
using System.Windows;

namespace Corrugator.Client.Wpf.Views;

/// <summary>字典明细新增/修改</summary>
public partial class DictDataEditWindow : Window
{
    public DictDataEditWindow(int typeId, string typeLabel, DictDataDto? editing)
    {
        InitializeComponent();

        TypeId = typeId;
        TitleText.Text = editing is null ? "字典明细-新增" : "字典明细-编辑";
        TypeInput.Text = typeLabel;

        if (editing is not null)
        {
            ValueInput.Text = editing.WPD_Value ?? string.Empty;
            EnglishInput.Text = editing.WPD_EnglishName ?? string.Empty;
            ChineseInput.Text = editing.WPD_ChineseName ?? string.Empty;
            PropertyInput.Text = editing.WPD_Property ?? string.Empty;
            SortInput.Text = editing.WPD_SortNo?.ToString() ?? string.Empty;
        }

        Loaded += (_, _) => ValueInput.Focus();
    }

    public int TypeId { get; }

    public DictDataSaveRequest? Result { get; private set; }

    private void OnConfirmClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(ValueInput.Text)
            && string.IsNullOrWhiteSpace(ChineseInput.Text)
            && string.IsNullOrWhiteSpace(EnglishInput.Text))
        {
            MessageBox.Show(this, "值、中文名、英文名至少填一项", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            ValueInput.Focus();
            return;
        }

        int? sortNo = null;
        if (int.TryParse(SortInput.Text?.Trim(), out var parsed))
        {
            sortNo = parsed;
        }

        Result = new DictDataSaveRequest
        {
            WPD_TypeID = TypeId,
            WPD_Value = ValueInput.Text?.Trim(),
            WPD_EnglishName = EnglishInput.Text?.Trim(),
            WPD_ChineseName = ChineseInput.Text?.Trim(),
            WPD_Property = PropertyInput.Text?.Trim(),
            WPD_SortNo = sortNo,
        };

        DialogResult = true;
        Close();
    }

    private void OnCancelClick(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}
