#nullable enable
namespace MameTools.Net48.Software.Parts.Disks;

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