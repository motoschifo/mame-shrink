#nullable enable
using MameTools.Net48.Common;

namespace MameTools.Net48.SoftwareList;

public class MameSoftwareList
{
    public MameSoftwareList()
    {
        //
    }

    public MameSoftwareList(string name)
    {
        Name = name;
    }

    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public MameCollection<Software.MameSoftware> Software { get; private set; } = [];

    public bool ContainsCloneSoftware { get; set; }
    public bool ContainsParentSoftware { get; set; }
    public bool ContainsSupportedSoftware { get; set; }
    public bool ContainsUnsupportedSoftware { get; set; }
    public bool ContainsPartiallySupportedSoftware { get; set; }
}
