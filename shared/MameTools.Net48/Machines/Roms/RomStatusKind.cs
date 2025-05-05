#nullable enable
namespace MameTools.Net48.Machines.Roms;

public partial class Rom
{
    public enum RomStatusKind
    {
        unknown,
        good,
        baddump,
        nodump
    }
}