#nullable enable
using System;
namespace MameTools.Net48.Extensions;

public static class StringExtension
{
    private static readonly StringComparison _ignoreCaseComparer = StringComparison.OrdinalIgnoreCase;

    public static bool EqualsIgnoreCase(this string? source, string? other) => string.Equals(source, other, _ignoreCaseComparer);

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
