#nullable enable
using MameTools.Net48.Extensions;

namespace MAME_Shrink.Settings;

public partial class UserPreferences
{
    public partial class GridColumnDefinition
    {
        public enum GridColumnKind
        {
            Unknown,
            Id,
            Romset,
            Description,
            Size,
            GameYear,
            Manufacturer,
            CloneOf,
            DriverStatus,
            Genre,
            Release,
            Players,
            Buttons,
            Display,
            Category,
        }

        public static GridColumnKind ParseGridColumn(string? value) => value.ToEnum(GridColumnKind.Unknown, GridColumnKind.Unknown);
    }
}