#nullable enable
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MAME_Shrink.Forms.Main;
internal class WarningRomsetCollection : Collection<WarningRomsetItem>
{
    public WarningRomsetCollection() : base()
    {
    }

    public WarningRomsetCollection(IList<WarningRomsetItem> list) : base(list)
    {
    }

    public void Add(string romset, List<string> optionalRomsets, List<string> missingRomsets)
    {
        Add(new WarningRomsetItem(romset, optionalRomsets, missingRomsets));
    }

    public void AddToOptionalRomsetList(string romset, string optionalRomset)
    {
        var wr = this.FirstOrDefault(wr => wr.Romset == romset);
        if (wr == null)
        {
            Add(new WarningRomsetItem(romset, [optionalRomset], []));
        }
        else
        {
            wr.OptionalRomsets.Add(optionalRomset);
        }
    }

    public void AddToMissingRomsetList(string romset, string missingRomset)
    {
        var wr = this.FirstOrDefault(wr => wr.Romset == romset);
        if (wr == null)
        {
            Add(new WarningRomsetItem(romset, [], [missingRomset]));
        }
        else
        {
            wr.MissingRomsets.Add(missingRomset);
        }
    }
}
