#nullable enable
namespace MameTools.Net48.Machines.Samples;

public class SampleRom
{
    public string Name { get; set; } = default!;
    public int Size { get; set; }
    public string? CRC { get; set; }
    public string? SHA1 { get; set; }
}
