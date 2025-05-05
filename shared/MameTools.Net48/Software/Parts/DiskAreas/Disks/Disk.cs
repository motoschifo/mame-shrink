#nullable enable
using MameTools.Net48.Extensions;
namespace MameTools.Net48.Software.Parts.Disks;

public partial class Disk
{
    public string Name { get; set; } = default!;
    public string? SHA1 { get; set; }
    public DiskStatusKind Status { get; set; } = DiskStatusKind.good;
    public static DiskStatusKind ParseStatus(string? value) => value.ToEnum(DiskStatusKind.unknown, DiskStatusKind.good);
    public bool Writeable { get; set; }
}
