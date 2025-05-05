#nullable enable
namespace MameTools.Net48.Machines.Sounds;

public class Sound
{
    public int Channels { get; set; }
    public bool HasAudio => Channels > 0;
    public bool IsMono => Channels == 1;
    public bool IsStereo => Channels == 2;
    public bool IsMultiChannel => Channels > 2;
}
