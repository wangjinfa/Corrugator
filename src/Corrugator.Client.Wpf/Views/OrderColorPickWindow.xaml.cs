using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Corrugator.Client.Wpf.Views;

/// <summary>调色板：24 个常用颜色 + 无颜色</summary>
public partial class OrderColorPickWindow : Window
{
    private static readonly string[] PaletteColors =
    {
        "#0000FF", "#1B4E8C", "#00BFFF", "#00CED1", "#008080", "#008000", "#32CD32", "#90EE90",
        "#FFFF00", "#FFD700", "#FFA500", "#FF7F00", "#FF4500", "#FF0000", "#C00000", "#FF69B4",
        "#FF9EC4", "#FFC0CB", "#800080", "#4B0082", "#A0522D", "#808080", "#C0C0C0", "#FFFFFF",
    };

    public OrderColorPickWindow(string? current)
    {
        InitializeComponent();

        foreach (var hex in PaletteColors)
        {
            var button = new Button
            {
                Width = 32,
                Height = 26,
                Margin = new Thickness(2),
                Background = (Brush)new BrushConverter().ConvertFromString(hex)!,
                Tag = hex,
                BorderBrush = Brushes.Gray,
                BorderThickness = new Thickness(1),
            };

            if (string.Equals(current, hex, StringComparison.OrdinalIgnoreCase))
            {
                button.BorderBrush = Brushes.DarkRed;
                button.BorderThickness = new Thickness(2);
            }

            button.Click += (s, e) =>
            {
                Result = (string)((Button)s!).Tag!;
                DialogResult = true;
                Close();
            };

            Palette_Add(button);
        }
    }

    private void Palette_Add(Button button) => ((UniformGrid)FindName("Palette")).Children.Add(button);

    /// <summary>选中的 #RRGGBB；无颜色时为 null</summary>
    public string? Result { get; private set; }

    private void OnNoneClick(object sender, RoutedEventArgs e)
    {
        Result = null;
        DialogResult = true;
        Close();
    }

    private void OnCancelClick(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}
