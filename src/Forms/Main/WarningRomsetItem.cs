#nullable enable
using System.Collections.Generic;

namespace MAME_Shrink.Forms.Main;
internal class WarningRomsetItem
{
    public WarningRomsetItem(string romset, List<string> optionalRomsets, List<string> missingRomsets)
    {
        Romset = romset;
        OptionalRomsets = optionalRomsets;
        MissingRomsets = missingRomsets;
    }

    public string Romset { get; private set; } = default!;
    public List<string> OptionalRomsets { get; private set; } = [];
    public List<string> MissingRomsets { get; private set; } = [];
}
