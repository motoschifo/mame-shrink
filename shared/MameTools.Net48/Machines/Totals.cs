#nullable enable
using System.Collections.Generic;
using MameTools.Net48.Common;
using MameTools.Net48.Machines.Disks;

namespace MameTools.Net48.Machines;

public class Totals
{
    public MameCounter Items { get; } = new("total items");
    public MameCounterWithDelta Machines { get; } = new("machines");
    public MameCounterWithDelta Parents { get; } = new("parents");
    public MameCounterWithDelta Clones { get; } = new("clones");
    public MameCounter Bioses { get; } = new("BIOSes");
    public MameCounterWithDelta Devices { get; } = new("devices");
    public MameCounterWithDelta Drivers { get; } = new("drivers");
    public List<string> DriverNames { get; private set; } = [];
    public List<Disk> Disks { get; private set; } = [];
    public MameCounterWithDelta TotalDisks { get; } = new("CHDs");
    public MameCounterWithDelta RequiresDisks { get; } = new("requires CHDs");
    public MameCounterWithDelta UseSamples { get; } = new("use samples");
    public MameCounterWithDelta SampleFiles { get; } = new("sample files");
    public MameCounterWithDelta SamplePacks { get; } = new("sample packs");
    public MameCounterWithDelta AudioMono { get; } = new("audio mono");
    public MameCounterWithDelta AudioStereo { get; } = new("audio stereo");
    public MameCounterWithDelta NoAudio { get; } = new("no audio");
    public MameCounterWithDelta AudioMultiChannel { get; } = new("audio multichannel");
    public MameCounterWithDelta Working { get; } = new("working");
    public MameCounterWithDelta NotWorking { get; } = new("not working");
    public MameCounterWithDelta Mechanicals { get; } = new("mechanicals");
    public MameCounterWithDelta NotMechanicals { get; } = new("not mechanicals");
    public MameCounterWithDelta SaveSupported { get; } = new("save supported");
    public MameCounterWithDelta SaveUnsupported { get; } = new("save unsupported");
    public MameCounterWithDelta HorizontalScreen { get; } = new("horizontal screen");
    public MameCounterWithDelta VerticalScreen { get; } = new("vertical screen");
    public MameCounterWithDelta RasterGraphics { get; } = new("raster graphics");
    public MameCounterWithDelta VectorGraphics { get; } = new("vector graphics");
    public MameCounterWithDelta LCDGraphics { get; } = new("lcd graphics");
    public MameCounterWithDelta SVGGraphics { get; } = new("svg graphics");
    public MameCounterWithDelta Screenless { get; } = new("screenless");
    public MameCounterWithDelta TotalRoms { get; } = new("total roms");
    public MameCounterWithDelta MachineRoms { get; } = new("machines roms");
    public MameCounterWithDelta DevicesRoms { get; } = new("devices roms");
    public MameCounterWithDelta BiosRoms { get; } = new("BIOSes roms");
    public MameCounterWithDelta GoodDumpsRoms { get; } = new("good dumps");
    public MameCounterWithDelta NoDumpsRoms { get; } = new("no dumps");
    public MameCounterWithDelta BadDumpsRoms { get; } = new("bad dumps");
}
