#nullable enable
namespace MAME_Shrink.Forms.Main;
internal class RomFile
{
    public string Name { get; set; } = default!;
    public string FilePath { get; set; } = default!;
    public long Size { get; set; }
}
