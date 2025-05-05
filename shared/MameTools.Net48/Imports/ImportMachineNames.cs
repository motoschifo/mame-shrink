#nullable enable
using System.Collections.Generic;
using System.IO;
namespace MameTools.Net48.Imports;

public static class ImportMachineNames
{
    public static List<string> LoadFromFile(Mame mame, string filename)
    {
        if (string.IsNullOrEmpty(filename) || !File.Exists(filename)) return [];
        return [.. File.ReadAllLines(filename)];
    }
}
