#nullable enable
namespace Extensions.Net48;

public static class DoubleExtension
{
    public static long ToInt64(this double d) => long.TryParse(d.ToString(), out var output) ? output : 0;

    public static string ToFormattedString(this double value) => value.ToString("#,##0.00");
}
