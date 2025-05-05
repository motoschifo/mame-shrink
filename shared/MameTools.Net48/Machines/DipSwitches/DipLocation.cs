#nullable enable
namespace MameTools.Net48.Machines.DipSwitches;

public class DipLocation
{
    public string Name { get; set; } = default!;
    public int Number { get; set; }
    public bool Inverted { get; set; }
}
