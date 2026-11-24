using System.Globalization;
using System.Windows.Data;

namespace Corrugator.Client.Wpf.Converters;

/// <summary>布尔取反，用于"加载中禁用按钮"这类绑定</summary>
public class BooleanNegationConverter : IValueConverter
{
    public static readonly BooleanNegationConverter Instance = new();

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is bool b ? !b : true;

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is bool b ? !b : false;
}

/// <summary>bool → 是否已处理 文案</summary>
public class AlarmStateConverter : IValueConverter
{
    public static readonly AlarmStateConverter Instance = new();

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is true ? "已确认" : "未确认";

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
