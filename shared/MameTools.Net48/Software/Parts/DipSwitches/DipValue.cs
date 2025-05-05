#nullable enable
namespace MameTools.Net48.Software.Parts.DipSwitches;

public class DipValue
{
    public string Name { get; set; } = default!;
    public string? Value { get; set; }
    public bool Default { get; set; }
}
