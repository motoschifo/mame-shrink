#nullable enable
using Extensions.Net48;

namespace MAME_Shrink.Forms.Main;
internal class RomFile
{
    public string Name { get; set; } = default!;
    public string Filename { get; set; } = default!;
    public long Size { get; set; }
    public string SizeStr => Size <= 0 ? "-" : Size.ToFileSizeString();
}
