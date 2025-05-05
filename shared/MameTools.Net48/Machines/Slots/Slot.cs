#nullable enable
using MameTools.Net48.Common;

namespace MameTools.Net48.Machines.Slots;

public class Slot
{
    public string Name { get; set; } = default!;
    public MameCollection<SlotOption> SlotOptions { get; set; } = [];
}