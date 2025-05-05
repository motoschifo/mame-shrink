#nullable enable
using MameTools.Net48.Common;
using MameTools.Net48.Software.Parts.DataAreas;
using MameTools.Net48.Software.Parts.DipSwitches;
using MameTools.Net48.Software.Parts.DiskAreas;
using MameTools.Net48.Software.Parts.Features;

namespace MameTools.Net48.Software.Parts;

public class Part
{
    public string Name { get; set; } = default!;
    public string? Interface { get; set; }
    public MameCollection<Feature> Features { get; private set; } = [];
    public MameCollection<DataArea> DataAreas { get; private set; } = [];
    public MameCollection<DiskArea> DiskAreas { get; private set; } = [];
    public MameCollection<DipSwitch> DipSwitches { get; private set; } = [];
}
