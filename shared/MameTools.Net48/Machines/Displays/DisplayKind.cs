#nullable enable
namespace MameTools.Net48.Machines.Displays;

public partial class Display
{
    public enum DisplayKind
    {
        unknown,
        raster,
        vector,
        lcd,
        svg
    }
}