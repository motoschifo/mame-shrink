#nullable enable
namespace MameTools.Net48.Machines.Feature;

public partial class Feature
{
    public enum FeatureKind
    {
        unknown,
        protection,
        timing,
        graphics,
        palette,
        sound,
        capture,
        camera,
        microphone,
        controls,
        keyboard,
        mouse,
        media,
        disk,
        printer,
        tape,
        punch,
        drum,
        rom,
        comms,
        lan,
        wan
    }
}