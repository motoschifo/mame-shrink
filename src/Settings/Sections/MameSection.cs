#nullable enable
using System.Collections.Generic;
using MameTools.Net48.Extensions;

namespace MAME_Shrink.Settings;

public partial class UserPreferences
{
    public class MameSection
    {
        public string? ExecutableFilePath { get; set; }
        public bool GenerateGameListFromExecutable { get; set; } = true;
        public bool ForceGameListGeneration { get; set; }
        public string? GameListFilePath { get; set; }
        public string? RomPaths { get; set; }
        public List<string> RomPathList => string.IsNullOrWhiteSpace(RomPaths) ? [] : [.. RomPaths!.Split([';'], System.StringSplitOptions.RemoveEmptyEntries)];
        public bool AutoDetectRomPaths { get; set; } = true;
        public enum MameSetKind
        {
            Auto,
            Splitted,
            Merged,
            NonMerged,
        }
        public MameSetKind MameSetType { get; set; } = MameSetKind.Auto;
        public static MameSetKind ParseMameSet(string? value) => value.ToEnum(MameSetKind.Auto, MameSetKind.Auto);
    }
}