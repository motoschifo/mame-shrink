#nullable enable
using MameTools.Net48.Common;

namespace MameTools.Net48.Machines.Samples;

public class Sample
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public MameCollection<SampleRom> Roms { get; private set; } = [];
}
