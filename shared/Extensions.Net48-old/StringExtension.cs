#nullable enable
using System;
using System.Globalization;

namespace Extensions.Net48;

public static class StringExtension
{
    public static long ToInt64(this string? s) => long.TryParse(s, out var output) ? output : 0;

    public static float ToFloat(this string? s) => float.TryParse(s, out var output) ? output : 0;

    public static double ToDouble(this string? s) => double.TryParse(s, out var output) ? output : 0;

    public static decimal ToDecimal(this string? s) => decimal.TryParse(s, out var output) ? output : 0;

    /// <summary>
    /// Lettura di una data da controlli di testo
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DateTime GetDate(this string? value)
    {
        DateTime d;
        try
        {
            d = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        catch
        {
            d = DateTime.MinValue;
        }
        return d;
    }

    public static string? SafeSubstring(this string? s, int start, int length)
    {
        return string.IsNullOrEmpty(s) ?
        string.Empty
        :
        (s!.Length <= length ? s : s.Substring(start, length));
    }

    public static string? SafeSubstring(this string? s, int start)
    {
        return string.IsNullOrEmpty(s) ?
            string.Empty
            :
            (start > s!.Length ? string.Empty : s.Substring(start));
    }
}
