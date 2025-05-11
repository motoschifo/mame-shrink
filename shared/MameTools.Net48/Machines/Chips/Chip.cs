#nullable enable
using MameTools.Net48.Extensions;

namespace MameTools.Net48.Machines.Chips;

public partial class Chip
{
    public string Name { get; set; } = default!;
    public string? Tag { get; set; }
    public int Clock { get; set; }
    public ChipKind Type { get; set; } = ChipKind.unknown;
    public static ChipKind ParseType(string? value) => value.ToEnum(ChipKind.unknown, ChipKind.unknown);
    /// <summary>
    /// WARNING: Legacy release, up to 0.100
    /// </summary>
    public bool SoundOnly { get; set; }
}

