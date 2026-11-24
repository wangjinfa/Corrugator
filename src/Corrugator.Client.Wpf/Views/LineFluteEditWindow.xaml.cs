using Corrugator.Client.Wpf.ViewModels;
using System.Windows;

namespace Corrugator.Client.Wpf.Views;

/// <summary>产线楞型-编辑/新增弹窗（三列布局，字段与现场一致）</summary>
public partial class LineFluteEditWindow : Window
{
    public LineFluteEditWindow(LineFluteRow row, bool isNew)
    {
        InitializeComponent();

        Row = row;
        Options = new LineFluteEditOptions(row);
        DataContext = this;

        Title = isNew ? "产线楞型-新增" : "产线楞型-修改";
        TitleText.Text = Title;
    }

    public LineFluteRow Row { get; }

    public LineFluteEditOptions Options { get; }

    public string Creator => Row.Creator ?? "(当前用户)";

    public string Editor => Row.Editor ?? "(当前用户)";

    public string CreateTimeText => Row.CreateTime is null ? string.Empty : Row.CreateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

    public string EditTimeText => Row.EditTime is null ? string.Empty : Row.EditTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

    private void OnOkClick(object sender, RoutedEventArgs e)
    {
        if (Row.DoorWidth <= 0)
        {
            MessageBox.Show(this, "门幅不能为空", "产线楞型", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(Row.FluteType))
        {
            MessageBox.Show(this, "楞型不能为空", "产线楞型", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        DialogResult = true;
        Close();
    }

    private void OnCancelClick(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}

/// <summary>弹窗下拉的可选值</summary>
public class LineFluteEditOptions
{
    public LineFluteEditOptions(LineFluteRow row)
    {
        DoorWidths = new[] { "2800", "2500", "2200", "1800", "1600" };
        FluteTypes = new[] { "3A", "3B", "5A", "5B", "7A", "E楞", "BC楞", "B楞", "C楞", "A楞" };
    }

    public IReadOnlyList<string> DoorWidths { get; }

    public IReadOnlyList<string> FluteTypes { get; }
}
