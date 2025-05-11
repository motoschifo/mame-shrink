#nullable enable
namespace MameTools.Net48.Machines.Inputs;

public class Control
{
    public string Type { get; set; } = default!;
    public int Player { get; set; }
    public int Buttons { get; set; }
    public int RequiredButtons { get; set; }
    public int Minimum { get; set; }
    public int Maximum { get; set; }
    public int Sensitivity { get; set; }
    public int KeyDelta { get; set; }
    public bool Reverse { get; set; }
    public int Ways { get; set; }
    /// <summary>
    /// WARNING: Legacy release, up to 0.100
    /// </summary>
    public int Ways2 { get; set; }
    /// <summary>
    /// WARNING: Legacy release, up to 0.100
    /// </summary>
    public int Ways3 { get; set; }
}
