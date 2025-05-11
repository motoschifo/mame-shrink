#nullable enable
using System.Collections.Generic;
using MAME_Shrink.Resources;
using static MAME_Shrink.Settings.UserPreferences.GridColumnDefinition;

namespace MAME_Shrink.Settings;

public partial class UserPreferences
{
    public static readonly List<GridColumnDefinition> AllColumnDefinitions =
    [
        new GridColumnDefinition { Kind = GridColumnKind.Id, Position = 1, Title = string.Empty, Width = 25, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Romset, Position = 2, Title = Strings.ColumnRomset, Width = 65, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Description, Position = 3, Title = Strings.ColumnTitle, Width = 200, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.GameYear, Position = 4, Title = Strings.ColumnYear, Width = 50, Visible = true, RightAlignment = true },
        new GridColumnDefinition { Kind = GridColumnKind.Manufacturer, Position = 5, Title = Strings.ColumnManufacturer, Width = 80, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.CloneOf, Position = 6, Title = Strings.ColumnClone, Width = 160, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Size, Position = 7, Title = Strings.ColumnFileSize, Width = 70, Visible = true, RightAlignment = true },
        new GridColumnDefinition { Kind = GridColumnKind.DriverStatus, Position = 8, Title = Strings.ColumnStatus, Width = 120, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Genre, Position = 9, Title = Strings.ColumnGenre, Width = 100, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Category, Position = 10, Title = Strings.ColumnCategory, Width = 150, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Release, Position = 11, Title = Strings.ColumnRelease, Width = 80, Visible = false, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Players, Position = 12, Title =  Strings.ColumnPlayers, Width = 50, Visible = false, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Buttons, Position = 13, Title = Strings.ColumnButtons, Width = 50, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Display, Position = 14, Title = Strings.ColumnScreen, Width = 120, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Serie, Position = 15, Title = Strings.ColumnSerie, Width = 120, Visible = false, RightAlignment = false }
    ];
}
