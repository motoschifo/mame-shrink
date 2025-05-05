#nullable enable
namespace MameTools.Net48.Software.Parts.DataAreas.Roms;

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