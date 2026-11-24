using Corrugator.Client.Wpf.ViewModels;
using System.Windows;

namespace Corrugator.Client.Wpf.Views;

/// <summary>原纸资料-新增/修改</summary>
public partial class PaperEditWindow : Window
{
    public PaperEditWindow(PaperRow row, bool isNew)
    {
        InitializeComponent();

        Row = row;
        DataContext = this;

        Title = isNew ? "原纸资料-新增" : "原纸资料-修改";
        TitleText.Text = Title;
    }

    public PaperRow Row { get; }

    private void OnOkClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Row.Code))
        {
            MessageBox.Show(this, "原纸代号不能为空", "原纸资料", MessageBoxButton.OK, MessageBoxImage.Warning);
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
