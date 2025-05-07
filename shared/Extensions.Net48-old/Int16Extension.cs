#nullable enable
namespace Extensions.Net48;

public static class Int16Extension
{
    public static string ToFormattedString(this short value) => value.ToString("#,##0");
}
