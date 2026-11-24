using Corrugator.Client.Wpf.ViewModels;
using System.Windows;

namespace Corrugator.Client.Wpf.Views;

/// <summary>班组资料设置-新增/修改</summary>
public partial class TeamEditWindow : Window
{
    public TeamEditWindow(TeamRow row, bool isNew)
    {
        InitializeComponent();

        Row = row;
        DataContext = this;

        Title = isNew ? "班组资料设置-新增" : "班组资料设置-修改";
        TitleText.Text = Title;
    }

    public TeamRow Row { get; }

    private void OnOkClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Row.ShiftNo))
        {
            MessageBox.Show(this, "班次号不能为空", "班组资料设置", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(Row.TeamName))
        {
            MessageBox.Show(this, "班组名称不能为空", "班组资料设置", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        NormalizeTimeInput();

        DialogResult = true;
        Close();
    }

    private void NormalizeTimeInput()
    {
        Row.StartTime = Normalize(Row.StartTime);
        Row.EndTime = Normalize(Row.EndTime);

        string? Normalize(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            var text = value.Trim();
            if (TimeSpan.TryParse(text, out var span) && span.TotalHours < 24)
            {
                return $"{span.Hours:00}:{span.Minutes:00}:{span.Seconds:00}";
            }

            return text;
        }
    }

    private void OnCancelClick(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}
