#nullable enable
using System.IO;

namespace MAME_Shrink.Utilities;

public static class FileUtilities
{
    public static string ReplaceFileExtension(string filename, string newExtension)
    {
        if (string.IsNullOrEmpty(filename)) return string.Empty;
        //if (string.IsNullOrEmpty(newExtension)) return filename;
        return Path.ChangeExtension(filename, newExtension);
    }
}
