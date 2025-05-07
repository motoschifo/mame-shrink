#nullable enable
namespace MameTools.Net48.Extensions;

public static class Int64Extension
{
    public static string ToFormattedString(this long value) => value.ToString("#,##0");

    /// <summary>
    /// Esempio di utilizzo
    ///   long fileSize = 23500000; // 23.5 MB
    ///   Console.WriteLine(fileSize.ToFileSizeString());
    /// </summary>
    /// <param name="fileSize"></param>
    /// <returns></returns>
    public static string ToFileSizeString(this long fileSize)
    {
        string[] suffixes = ["B", "KB", "MB", "GB", "TB"];
        double size = fileSize;
        var index = 0;

        while (size >= 830 && index < suffixes.Length - 1)
        {
            size /= 1024;
            index++;
        }

        var format = (size % 1 == 0) ? "{0:0} {1}" : "{0:0.#} {1}";
        return string.Format(format, size, suffixes[index]);
    }
}
