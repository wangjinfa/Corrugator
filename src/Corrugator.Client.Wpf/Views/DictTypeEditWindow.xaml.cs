using System.Windows;

namespace Corrugator.Client.Wpf.Views;

/// <summary>字典分类新增/修改</summary>
public partial class DictTypeEditWindow : Window
{
    public DictTypeEditWindow(string? parentLabel, int? parentId, string? name, string? code)
    {
        InitializeComponent();

        TitleText.Text = name is null ? "字典分类-新增" : "字典分类-编辑";
        ParentInput.Text = string.IsNullOrEmpty(parentLabel) ? "根目录" : parentLabel;
        NameInput.Text = name ?? string.Empty;
        CodeInput.Text = code ?? string.Empty;
        ParentId = parentId;
        Loaded += (_, _) => NameInput.Focus();
    }

    public int? ParentId { get; }

    public string? ResultName { get; private set; }

    public string? ResultCode { get; private set; }

    private void OnConfirmClick(object sender, RoutedEventArgs e)
    {
        var name = NameInput.Text?.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show(this, "中文名不能为空", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            NameInput.Focus();
            return;
        }

        ResultName = name;
        ResultCode = CodeInput.Text?.Trim();
        DialogResult = true;
        Close();
    }

    private void OnCancelClick(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}
