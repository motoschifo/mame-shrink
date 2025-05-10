#nullable enable
using System;
namespace ArcadeDatabaseSdk.Net48.Extensions;

public static class StringExtension
{
    private static readonly StringComparison _ignoreCaseComparer = StringComparison.OrdinalIgnoreCase;

    public static bool EqualsIgnoreCase(this string? source, string? other) => string.Equals(source, other, _ignoreCaseComparer);
}
