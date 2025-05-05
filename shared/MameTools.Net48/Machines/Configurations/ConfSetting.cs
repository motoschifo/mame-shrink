#nullable enable
using MameTools.Net48.Machines.Shared;
namespace MameTools.Net48.Machines.Configurations;

public class ConfSetting
{
    public string Name { get; set; } = default!;
    public string Value { get; set; } = default!;
    public bool Default { get; set; }
    public Condition? Condition { get; set; }
}