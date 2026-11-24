using Corrugator.Shared.Contracts.Comm;
using System.Windows;

namespace Corrugator.Client.Wpf.Views;

/// <summary>通讯配置设置-编辑</summary>
public partial class CommConfigEditWindow : Window
{
    public CommConfigEditWindow(CommConfigDto? editing, IEnumerable<string>? parCodes)
    {
        InitializeComponent();

        TitleText.Text = editing is null ? "通讯配置设置-新增" : "通讯配置设置-编辑";

        if (parCodes is not null)
        {
            foreach (var code in parCodes)
            {
                ParCodeInput.Items.Add(code);
            }
        }

        if (editing is not null)
        {
            CodeInput.Text = editing.Code;
            NameInput.Text = editing.Name ?? string.Empty;
            DescInput.Text = editing.Desc ?? string.Empty;
            ParCodeInput.Text = editing.ParCode ?? string.Empty;
            ParValueInput.Text = editing.ParValue ?? string.Empty;
            DeleteCheck.IsChecked = editing.IsDelete;
            CreatorInput.Text = editing.Creator ?? string.Empty;
            CreateTimeInput.Text = editing.CreateTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? string.Empty;
            EditorInput.Text = editing.Editor ?? string.Empty;
            EditTimeInput.Text = editing.EditTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? string.Empty;
        }

        Loaded += (_, _) => CodeInput.Focus();
    }

    public CommConfigSaveRequest? Result { get; private set; }

    private void OnConfirmClick(object sender, RoutedEventArgs e)
    {
        var code = CodeInput.Text?.Trim();
        if (string.IsNullOrWhiteSpace(code))
        {
            MessageBox.Show(this, "配置编码不能为空", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            CodeInput.Focus();
            return;
        }

        Result = new CommConfigSaveRequest
        {
            Code = code,
            Name = NameInput.Text?.Trim(),
            Desc = DescInput.Text?.Trim(),
            ParCode = ParCodeInput.Text?.Trim(),
            ParValue = ParValueInput.Text?.Trim(),
            IsDelete = DeleteCheck.IsChecked == true,
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
