#nullable enable
using System;
namespace ArcadeDatabaseSdk.Net48.Extensions;

public static class EnumExtensions
{
    public static T ToEnum<T>(this string? value, T fallbackValue, T defaultValue = default!) where T : struct, Enum
    {
        if (string.IsNullOrEmpty(value))
            return defaultValue;
        return Enum.TryParse<T>(value, ignoreCase: true, out var result)
            ? result
            : fallbackValue;
    }
}