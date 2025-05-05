#nullable enable
namespace MameTools.Net48.Machines.Disks;

public partial class Disk
{
    public enum DiskStatusKind
    {
        unknown,
        good,
        baddump,
        nodump
    }
}