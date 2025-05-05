#nullable enable
namespace MameTools.Net48.Machines.Slots;

public class SlotOption
{
    public string Name { get; set; } = default!;
    public string DevName { get; set; } = default!;
    public bool Default { get; set; }
}