#nullable enable
using MameTools.Net48.Common;
using MameTools.Net48.Machines.Shared;
namespace MameTools.Net48.Machines.DipSwitches;

public class DipSwitch
{
    public string Name { get; set; } = default!;
    public string Tag { get; set; } = default!;
    public string Mask { get; set; } = default!;
    public Condition? Condition { get; set; }
    public MameCollection<DipLocation> DipLocations { get; set; } = [];
    public MameCollection<DipValue> DipValues { get; set; } = [];
}