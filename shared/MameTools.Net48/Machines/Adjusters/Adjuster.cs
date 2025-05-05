#nullable enable
using MameTools.Net48.Machines.Shared;
namespace MameTools.Net48.Machines.Adjusters;

public class Adjuster
{
    public string Name { get; set; } = default!;
    public int Default { get; set; }
    public Condition? Condition { get; set; }
}