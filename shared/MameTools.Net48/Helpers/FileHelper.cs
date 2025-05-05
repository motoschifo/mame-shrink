#nullable enable
using System.IO;
namespace MameTools.Net48.Helpers;

public static class FileHelper
{
    public static bool MoveFolder(string fromFolder, string toFolder)
    {
        if (!Directory.Exists(fromFolder))
            return false;
        if (Directory.Exists(toFolder))
            return false;
        Directory.Move(fromFolder, toFolder);
        return true;
    }
}
