#nullable enable
using MameTools.Net48.Common;

namespace MameTools.Net48.Software.Parts.DipSwitches;

public class DipSwitch
{
    public string Name { get; set; } = default!;
    public string? Tag { get; set; }
    public string? Mask { get; set; }
    public MameCollection<DipValue> DipValues { get; set; } = [];
}
