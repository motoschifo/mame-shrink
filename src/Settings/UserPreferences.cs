#nullable enable
namespace MAME_Shrink.Settings;

public partial class UserPreferences
{
    public MameSection Mame { get; private set; } = new();
    public ArcadeDatabaseSection ArcadeDatabase { get; private set; } = new();
    public GridSection Grid { get; private set; } = new();
    public CleanOptionsSection CleanOptions { get; private set; } = new();
}
