using Corrugator.Shared.Contracts.Comm;
using System.Windows;

namespace Corrugator.Client.Wpf.Views;

/// <summary>
/// 通讯点位设置-编辑。
/// 字段口径：部位 = F_Position，所属设备 = F_DriverCode，PLC地址/MDI变量名 = F_VarAddress。
/// </summary>
public partial class CommPointEditWindow : Window
{
    public CommPointEditWindow(CommPointDto? editing, CommPointOptions options, IEnumerable<string> existingCodes)
    {
        InitializeComponent();

        TitleText.Text = editing is null ? "通讯点位设置-新增" : "通讯点位设置-编辑";

        foreach (var item in options.Positions)
        {
            PositionInput.Items.Add(item);
        }

        foreach (var item in options.Devices)
        {
            DeviceInput.Items.Add(item);
        }

        foreach (var item in options.DataTypes)
        {
            DataTypeInput.Items.Add(item);
        }

        foreach (var item in existingCodes)
        {
            CodeInput.Items.Add(item);
        }

        foreach (var item in options.Rw)
        {
            RwInput.Items.Add(item);
        }

        if (editing is null)
        {
            DataTypeInput.Text = "Float";
            RwInput.Text = "ReadWrite";
            IntervalInput.Text = "200";
            UseCheck.IsChecked = true;
        }
        else
        {
            PositionInput.Text = editing.Position ?? string.Empty;
            CodeInput.Text = editing.Code;
            NameInput.Text = editing.Name ?? string.Empty;
            DescInput.Text = editing.Desc ?? string.Empty;
            DeviceInput.Text = editing.DriverCode ?? string.Empty;
            AddressInput.Text = editing.VarAddress ?? string.Empty;
            DataTypeInput.Text = editing.DataType ?? string.Empty;
            RwInput.Text = editing.RW;
            IntervalInput.Text = editing.Interval.ToString();
            CurValueInput.Text = editing.CurValue ?? string.Empty;
            UseCheck.IsChecked = editing.IsUse;
            DeleteCheck.IsChecked = editing.IsDelete;
        }

        Loaded += (_, _) => CodeInput.Focus();
    }

    public CommPointSaveRequest? Result { get; private set; }

    private void OnConfirmClick(object sender, RoutedEventArgs e)
    {
        var code = CodeInput.Text?.Trim();
        if (string.IsNullOrWhiteSpace(code))
        {
            MessageBox.Show(this, "变量编码不能为空", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            CodeInput.Focus();
            return;
        }

        if (!int.TryParse(IntervalInput.Text?.Trim(), out var interval))
        {
            MessageBox.Show(this, "读取间隔必须是数字（毫秒）", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            IntervalInput.Focus();
            return;
        }

        Result = new CommPointSaveRequest
        {
            Code = code,
            Name = NameInput.Text?.Trim(),
            Desc = DescInput.Text?.Trim(),
            Position = PositionInput.Text?.Trim(),
            DriverCode = DeviceInput.Text?.Trim(),
            VarAddress = AddressInput.Text?.Trim(),
            DataType = DataTypeInput.Text?.Trim(),
            RW = RwInput.Text?.Trim() ?? "ReadWrite",
            Interval = interval,
            IsUse = UseCheck.IsChecked == true,
            CurValue = CurValueInput.Text?.Trim(),
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
