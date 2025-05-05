#nullable enable
namespace MAME_Shrink.Settings;

public partial class UserPreferences
{
    public partial class ArcadeDatabaseSection
    {
        public ConnectionOptionKind ConnectionOption { get; set; }
        // TODO: public string? Url { get; set; }
        // TODO: public string? LastReleaseCheck { get; set; }
    }
}
