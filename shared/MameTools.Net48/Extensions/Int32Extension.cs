#nullable enable
using System;
using System.Globalization;

namespace MameTools.Net48.Extensions;

public static class Int32Extension
{
    public static int ToInt32(this string? s) => string.IsNullOrEmpty(s) ? 0 : (int.TryParse(s, out var output) ? output : 0);

    public static int ToInt32(this double d) => Convert.ToInt32(d);

    public static string ToFormattedString(this int value) => value.ToString("#,##0");

    public static string ToDottedString(this int value)
    {
        var nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
        nfi.NumberGroupSeparator = ".";
        return value.ToString("#,##0", nfi);
    }

}
