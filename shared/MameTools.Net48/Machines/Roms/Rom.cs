#nullable enable
using MameTools.Net48.Extensions;

namespace MameTools.Net48.Machines.Roms;

public partial class Rom
{
    public string Name { get; set; } = default!;
    public string? Bios { get; set; }
    public int Size { get; set; }
    /// <summary>
    /// WARNING: Legacy release, up to 0.100
    /// </summary>
    public string? MD5 { get; set; }
    public string? CRC { get; set; }
    public string? SHA1 { get; set; }
    public string? Merge { get; set; }
    public string? Region { get; set; }
    public string? Offset { get; set; }
    public bool Optional { get; set; }
    public RomStatusKind Status { get; set; } = RomStatusKind.good;
    public static RomStatusKind ParseStatus(string? value) => value.ToEnum(RomStatusKind.unknown, RomStatusKind.good);
    /// <summary>
    /// WARNING: Legacy release, up to 0.100
    /// </summary>
    public bool Dispose { get; set; }
    /// <summary>
    /// WARNING: Legacy release, up to 0.100
    /// </summary>
    public bool SoundOnly { get; set; }
}
