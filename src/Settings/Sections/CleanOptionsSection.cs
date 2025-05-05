#nullable enable
namespace MAME_Shrink.Settings;

public partial class UserPreferences
{
    public class CleanOptionsSection
    {
        public CleanMethodKind CleanMethod { get; set; } = CleanMethodKind.MoveFilesToFolder;
        public string? RemovedFilesFolder { get; set; }
        public bool ValidateBeforeCleaning { get; set; }
    }
}
