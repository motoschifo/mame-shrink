#nullable enable
using System.Collections.Generic;
using static MAME_Shrink.Settings.UserPreferences.GridColumnDefinition;

namespace MAME_Shrink.Settings;

public partial class UserPreferences
{
    public static readonly List<GridColumnDefinition> AllColumnDefinitions =
    [
        new GridColumnDefinition { Kind = GridColumnKind.Id, Position = 1, Title = string.Empty, Width = 25, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Romset, Position = 2, Title = "Romset", Width = 65, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Description, Position = 3, Title = "Titolo", Width = 200, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.GameYear, Position = 4, Title = "Anno", Width = 50, Visible = true, RightAlignment = true },
        new GridColumnDefinition { Kind = GridColumnKind.Manufacturer, Position = 5, Title = "Produttore", Width = 80, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.CloneOf, Position = 6, Title = "Clone", Width = 160, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Size, Position = 7, Title = "Dimensione", Width = 70, Visible = true, RightAlignment = true },
        new GridColumnDefinition { Kind = GridColumnKind.DriverStatus, Position = 8, Title = "Stato", Width = 120, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Genre, Position = 9, Title = "Genere", Width = 100, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Category, Position = 10, Title = "Categoria", Width = 150, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Release, Position = 11, Title = "Versione", Width = 80, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Players, Position = 12, Title = "Giocatori", Width = 50, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Buttons, Position = 13, Title = "Pulsanti", Width = 50, Visible = true, RightAlignment = false },
        new GridColumnDefinition { Kind = GridColumnKind.Display, Position = 14, Title = "Schermo", Width = 120, Visible = true, RightAlignment = false }
    ];
}
