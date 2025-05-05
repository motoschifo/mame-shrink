#nullable enable
using MameTools.Net48.Common;
using MameTools.Net48.Software.Parts.Disks;

namespace MameTools.Net48.Software.Parts.DiskAreas;

public class DiskArea
{
    public string Name { get; set; } = default!;
    public MameCollection<Disk> Disks { get; private set; } = [];
}
