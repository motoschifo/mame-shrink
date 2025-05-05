#nullable enable
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MameTools.Net48.Config;

public class MameConfiguration
{
    public MameConfiguration()
    {
        //
    }

    public MameConfiguration(string exe)
    {
        _mameExe = exe;
    }
    private string _mameExe = default!;

    public string MameExe => _mameExe;

    // CORE SEARCH PATH OPTIONS
    public string HomePath { get; set; } = ".";
    public string RomPath { get; set; } = "roms";
    public string HashPath { get; set; } = "hash";
    public string SamplePath { get; set; } = "samples";
    public string ArtworkPath { get; set; } = "artwork";
    public string ControllerPath { get; set; } = "ctrlr";
    public string IniPath { get; set; } = ".;ini;ini/presets";
    public string FontPath { get; set; } = ".";
    public string CheatPath { get; set; } = "cheat";
    public string CrosshairPath { get; set; } = "crosshair";
    public string PluginsPath { get; set; } = "plugins";
    public string LanguagePath { get; set; } = "language";
    public string SoftwarePath { get; set; } = "software";

    // CORE OUTPUT DIRECTORY OPTIONS
    public string ConfigDirectory { get; set; } = "cfg";
    public string NvramDirectory { get; set; } = "nvram";
    public string InputPlaybackDirectory { get; set; } = "inp";
    public string StateDirectory { get; set; } = "sta";
    public string SnapshotDirectory { get; set; } = "snap";
    public string DiffDirectory { get; set; } = "diff";
    public string CommentDirectory { get; set; } = "comments";
    public string ShareDirectory { get; set; } = "share";

    // CUSTOM FOLDERS
    public string CabinetPath => "cabinets";
    public string ControlPanelPath => "cpanel";
    public string FlyerPath => "flyers";
    public string HiScorePath => "hi";
    public string IconPath => "icons";
    public string MarqueePath => "marquees";
    public string PcbPath => "pcb";
    public string TitlePath => "titles";

    public static List<string> SplitPath(string value) => [.. value.Split([';'], System.StringSplitOptions.RemoveEmptyEntries)];

    public string[] GetMameMachineFilenames(string? name, string resourcePath)
    {
        var parts = SplitPath(resourcePath);
        if (string.IsNullOrEmpty(_mameExe))
            return [];
        return parts.Select(x => Path.Combine(Path.GetDirectoryName(_mameExe), HomePath, x, name)).ToArray();
    }
}
