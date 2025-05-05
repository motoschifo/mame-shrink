#nullable enable
namespace MAME_Shrink.Settings;

public partial class UserPreferences
{
    public partial class GridColumnDefinition
    {
        public GridColumnKind Kind { get; set; } = GridColumnKind.Unknown;
        public int Position { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Width { get; set; }
        public bool Visible { get; set; }
        public bool RightAlignment { get; set; }
    }
}