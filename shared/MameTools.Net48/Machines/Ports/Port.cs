#nullable enable
using MameTools.Net48.Common;

namespace MameTools.Net48.Machines.Ports;

public class Port
{
    public string Tag { get; set; } = default!;
    public MameCollection<Analog> Analogs { get; set; } = [];
}