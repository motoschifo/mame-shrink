#nullable enable
namespace Extensions.Net48;

public static class BoolExtension
{
    public static bool IsNumeric(this string s) => float.TryParse(s, out _);
}
