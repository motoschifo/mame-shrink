#nullable enable
using MameTools.Net48.Common;

namespace MameTools.Net48.Machines.Inputs;

public class Input
{
    public bool Service { get; set; }
    public bool Tilt { get; set; }
    public int Players { get; set; }
    public int Coins { get; set; }
    public MameCollection<Control> Controls { get; private set; } = [];
}
