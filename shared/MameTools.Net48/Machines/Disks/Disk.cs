#nullable enable
using MameTools.Net48.Extensions;
namespace MameTools.Net48.Machines.Disks;

public partial class Disk
{
    public string Name { get; set; } = default!;
    /// <summary>
    /// WARNING: Legacy release, up to 0.100
    /// </summary>
    public string? MD5 { get; set; }
    public string? SHA1 { get; set; }
    public string? Merge { get; set; }
    public string? Region { get; set; }
    public string? Index { get; set; }
    public bool Writable { get; set; }
    public bool Optional { get; set; }
    public DiskStatusKind Status { get; set; } = DiskStatusKind.good;
    public static DiskStatusKind ParseStatus(string? value) => value.ToEnum(DiskStatusKind.unknown, DiskStatusKind.good);
}
