#nullable enable
using MameTools.Net48.Extensions;

namespace MAME_Shrink.Settings;

public partial class UserPreferences
{
    public enum CleanMethodKind
    {
        MoveFilesToFolder,
        MoveFilesToRecycleBin,
        DeleteFiles,
    }

    public static CleanMethodKind ParseCleanMethod(string? value) => value.ToEnum(CleanMethodKind.MoveFilesToFolder, CleanMethodKind.MoveFilesToFolder);
}
