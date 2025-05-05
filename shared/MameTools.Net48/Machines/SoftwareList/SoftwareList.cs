#nullable enable
using MameTools.Net48.Extensions;

namespace MameTools.Net48.Machines.SoftwareList;

public partial class SoftwareList
{
    public string Tag { get; set; } = default!;
    public string Name { get; set; } = default!;
    public SoftwareListStatusKind Status { get; set; } = SoftwareListStatusKind.unknown;
    public static SoftwareListStatusKind ParseStatus(string? value) => value.ToEnum(SoftwareListStatusKind.unknown, SoftwareListStatusKind.unknown);
    public string? Filter { get; set; }
}
