#nullable enable
using MameTools.Net48.Extensions;
namespace MameTools.Net48.Software.Parts.DataAreas.Roms;

public partial class Rom
{
    public string Name { get; set; } = default!;
    public int Size { get; set; }
    public int Length { get; set; }
    public string? CRC { get; set; }
    public string? SHA1 { get; set; }
    public string? Offset { get; set; }
    public string? Value { get; set; }
    public RomStatusKind Status { get; set; } = RomStatusKind.good;
    public static RomStatusKind ParseStatus(string? value) => value.ToEnum(RomStatusKind.unknown, RomStatusKind.good);
    public RomLoadFlagKind LoadFlag { get; set; } = RomLoadFlagKind.unknown;
    public static RomLoadFlagKind ParseLoadFlag(string? value) => value.ToEnum(RomLoadFlagKind.unknown, RomLoadFlagKind.unknown);
}
