#nullable enable
using MameTools.Net48.Extensions;

namespace MameTools.Net48.Machines.Displays;

public partial class Display
{
    //<display tag = "lscreen" type="raster" rotate="0" width="352" height="240" refresh="59.940060" pixclock="27000000" htotal="858" hbend="0" hbstart="352" vtotal="525" vbend="0" vbstart="240" />
    //<display tag = "mscreen" type="raster" rotate="0" width="352" height="240" refresh="59.940060" pixclock="27000000" htotal="858" hbend="0" hbstart="352" vtotal="525" vbend="0" vbstart="240" />
    //<display tag = "rscreen" type="raster" rotate="0" width="352" height="240" refresh="59.940060" pixclock="27000000" htotal="858" hbend="0" hbstart="352" vtotal="525" vbend="0" vbstart="240" />
    public string? Tag { get; set; }
    public int Rotate { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public decimal Refresh { get; set; }
    public DisplayOrientationKind Orientation { get; set; } = DisplayOrientationKind.unknown;
    public static DisplayOrientationKind ParseOrientation(string? value) => value.ToEnum(DisplayOrientationKind.unknown, DisplayOrientationKind.horizontal);
    public DisplayKind Type { get; set; } = DisplayKind.unknown;
    public static DisplayKind ParseType(string? value) => value.ToEnum(DisplayKind.unknown, DisplayKind.unknown);
    public bool FlipX { get; set; }
    public decimal PixClock { get; set; }
    public int HTotal { get; set; }
    public int HBend { get; set; }
    public int HBStart { get; set; }
    public int VTotal { get; set; }
    public int VBEnd { get; set; }
    public int VBStart { get; set; }
    /// <summary>
    /// WARNING: Legacy release, up to 0.100
    /// </summary>
    public int AspectX { get; set; }
    /// <summary>
    /// WARNING: Legacy release, up to 0.100
    /// </summary>
    public int AspectY { get; set; }
}
