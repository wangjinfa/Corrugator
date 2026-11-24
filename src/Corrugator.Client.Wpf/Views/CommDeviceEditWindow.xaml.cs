using Corrugator.Shared.Contracts.Comm;
using System.Windows;

namespace Corrugator.Client.Wpf.Views;

/// <summary>
/// 通讯设备设置-编辑。
/// 通讯类型 = 协议驱动（Siemens_S7_1200 等），通讯配置 = 配置表里的配置名称（双面机 等）。
/// </summary>
public partial class CommDeviceEditWindow : Window
{
    public CommDeviceEditWindow(CommDeviceDto? editing, IEnumerable<string> deviceTypes, IEnumerable<CommConfigOption> configOptions)
    {
        InitializeComponent();

        TitleText.Text = editing is null ? "通讯设备设置-新增" : "通讯设备设置-编辑";

        foreach (var type in deviceTypes)
        {
            CommTypeInput.Items.Add(type);
        }

        ConfigInput.ItemsSource = configOptions.ToList();

        if (editing is not null)
        {
            CodeInput.Text = editing.Code;
            NameInput.Text = editing.Name ?? string.Empty;
            CommTypeInput.Text = editing.CommType ?? string.Empty;
            ConfigInput.SelectedValue = editing.ConfigName;
            ConfigInput.Text = editing.ConfigName ?? string.Empty;
            DeleteCheck.IsChecked = editing.IsDelete;
            CreatorInput.Text = editing.Creator ?? string.Empty;
            CreateTimeInput.Text = editing.CreateTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? string.Empty;
            EditorInput.Text = editing.Editor ?? string.Empty;
            EditTimeInput.Text = editing.EditTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? string.Empty;
        }

        Loaded += (_, _) => CodeInput.Focus();
    }

    public CommDeviceSaveRequest? Result { get; private set; }

    private void OnConfirmClick(object sender, RoutedEventArgs e)
    {
        var code = CodeInput.Text?.Trim();
        if (string.IsNullOrWhiteSpace(code))
        {
            MessageBox.Show(this, "设备编码不能为空", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            CodeInput.Focus();
            return;
        }

        var configName = ConfigInput.Text?.Trim();
        if (string.IsNullOrEmpty(configName) && ConfigInput.SelectedItem is CommConfigOption option)
        {
            configName = option.Name;
        }

        Result = new CommDeviceSaveRequest
        {
            Code = code,
            Name = NameInput.Text?.Trim(),
            CommType = CommTypeInput.Text?.Trim(),
            ConfigName = configName,
            IsUse = true,
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
