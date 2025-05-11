#nullable enable
using MameTools.Net48.Extensions;

namespace MameTools.Net48.Machines.Drivers;

public partial class Driver
{
    public DriverStatusKind Status { get; set; } = DriverStatusKind.unknown;
    public static DriverStatusKind ParseStatus(string? value) => value.ToEnum(DriverStatusKind.unknown, DriverStatusKind.unknown);
    public EmulationKind Emulation { get; set; } = EmulationKind.unknown;
    public static EmulationKind ParseEmulation(string? value) => value.ToEnum(EmulationKind.unknown, EmulationKind.unknown);
    public CocktailKind Cocktail { get; set; } = CocktailKind.unknown;
    public static CocktailKind ParseCocktail(string? value) => value.ToEnum(CocktailKind.unknown, CocktailKind.unknown);
    public SaveStateKind SaveState { get; set; } = SaveStateKind.unknown;
    public static SaveStateKind ParseSaveState(string? value) => value.ToEnum(SaveStateKind.unknown, SaveStateKind.unknown);
    public bool RequiresArtwork { get; set; }
    public bool Unofficial { get; set; }
    public bool NoSoundHardware { get; set; }
    public bool Incomplete { get; set; }
    /// <summary>
    /// WARNING: Legacy release, up to 0.100
    /// </summary>
    public int PaletteSize { get; set; }
}
