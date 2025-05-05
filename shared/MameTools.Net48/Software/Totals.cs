#nullable enable
using MameTools.Net48.Common;

namespace MameTools.Net48.Software;

public class Totals
{
    public MameCounterWithDelta SoftwareLists { get; } = new("software list", isSoftware: true, trustDatValues: true);
    public MameCounterWithDelta Software { get; } = new("software", isSoftware: true, trustDatValues: true);
    public MameCounterWithDelta Parents { get; } = new("software parents", isSoftware: true, trustDatValues: true);
    public MameCounterWithDelta Clones { get; } = new("software clones", isSoftware: true, trustDatValues: true);
    public MameCounterWithDelta SoftwareRoms { get; } = new("software roms", isSoftware: true, trustDatValues: true);
    public MameCounterWithDelta SoftwareDisks { get; } = new("software CHD", isSoftware: true, trustDatValues: true);
    public MameCounterWithDelta BugFixed { get; } = new("bugs fixed", isSoftware: true, trustDatValues: true);
    public MameCounterWithDelta SupportedSoftware { get; } = new("supported software", isSoftware: true);
    public MameCounterWithDelta PartiallySupportedSoftware { get; } = new("partially supported software", isSoftware: true);
    public MameCounterWithDelta UnsupportedSoftware { get; } = new("unsupported software", isSoftware: true);
}
