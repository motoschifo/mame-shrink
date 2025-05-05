#nullable enable
using MameTools.Net48.Common;

namespace MameTools.Net48.Machines.Devices;

public class Device
{
    public string Type { get; set; } = default!;
    public string? Tag { get; set; }
    public bool FixedImage { get; set; }
    public bool Mandatory { get; set; }
    public string? Interface { get; set; }
    public Instance Instance { get; set; } = new();
    public MameCollection<Extension> Extensions { get; set; } = [];
}
