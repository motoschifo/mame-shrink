#nullable enable
using MameTools.Net48.Common;
using MameTools.Net48.Machines.Shared;
namespace MameTools.Net48.Machines.Configurations;

public class Configuration
{
    public string Name { get; set; } = default!;
    public string Tag { get; set; } = default!;
    public string Mask { get; set; } = default!;
    public Condition? Condition { get; set; }
    public MameCollection<ConfLocation> ConfLocations { get; set; } = [];
    public MameCollection<ConfSetting> ConfSettings { get; set; } = [];
}