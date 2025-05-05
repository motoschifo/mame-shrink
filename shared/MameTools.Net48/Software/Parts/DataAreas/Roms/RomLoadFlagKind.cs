#nullable enable
namespace MameTools.Net48.Software.Parts.DataAreas.Roms;

public partial class Rom
{
    public enum RomLoadFlagKind
    {
        unknown,
        load16_byte,
        load16_word,
        load16_word_swap,
        load32_byte,
        load32_word,
        load32_word_swap,
        load32_dword,
        load64_word,
        load64_word_swap,
        reload,
        fill,
        @continue,
        reload_plain
    }
}