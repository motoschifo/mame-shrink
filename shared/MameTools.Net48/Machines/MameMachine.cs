#nullable enable
using System;
using System.Linq;
using MameTools.Net48.Common;
using MameTools.Net48.Machines;
using MameTools.Net48.Machines.Adjusters;
using MameTools.Net48.Machines.BiosSets;
using MameTools.Net48.Machines.Chips;
using MameTools.Net48.Machines.Configurations;
using MameTools.Net48.Machines.DeviceRefs;
using MameTools.Net48.Machines.Devices;
using MameTools.Net48.Machines.DipSwitches;
using MameTools.Net48.Machines.Disks;
using MameTools.Net48.Machines.Displays;
using MameTools.Net48.Machines.Drivers;
using MameTools.Net48.Machines.Feature;
using MameTools.Net48.Machines.Ports;
using MameTools.Net48.Machines.RamOptions;
using MameTools.Net48.Machines.Roms;
using MameTools.Net48.Machines.Samples;
using MameTools.Net48.Machines.Slots;
using MameTools.Net48.Machines.SoftwareList;
using MameTools.Net48.Machines.Sounds;
using static MameTools.Net48.Machines.Disks.Disk;
using static MameTools.Net48.Machines.Feature.Feature;
using static MameTools.Net48.Machines.Roms.Rom;

namespace MameTools.Machine;

/// <summary>
/// Singolo gioco (nodo machine)
/// </summary>

public class MameMachine
{
    public decimal ReleaseSequence { get; set; }    // 0.100u4 --> 100.04m
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? SourceFile { get; set; }
    public string? DriverName { get; set; }
    public static string? RetrieveDriverNameFromSourceFile(bool isDevice, string? sourceFile)
    {
        if (isDevice || string.IsNullOrEmpty(sourceFile)) return null;
        var pos = sourceFile!.LastIndexOf("/");
        return pos == -1 ? sourceFile : sourceFile.Substring(pos + 1);
    }
    public string? Year { get; set; }
    public bool IsBios { get; set; }
    public bool IsMachine => !IsBios && !IsDevice;
    public bool IsDevice { get; set; }
    public bool IsMechanical { get; set; }
    public bool IsRunnable { get; set; } = true;
    public string? RomOf { get; set; }
    public string? CloneOf { get; set; }
    public string? SampleOf { get; set; }
    public bool UseSample => !string.IsNullOrEmpty(SampleOf);
    public MameCollection<Sample> Samples { get; } = [];
    public string? Manufacturer { get; set; }
    //public string? ControlType { get; set; }
    //public string? ControlWays { get; set; }
    public MameCollection<Display> Displays { get; } = [];
    public bool Screenless => Displays.Count == 0;
    public Display? GetMainDisplay()
    {
        if (Displays.Count == 0)
            return null;
        var display = Displays.FirstOrDefault(x => "screen".Equals(x.Tag, StringComparison.OrdinalIgnoreCase));
        return display is not null ? display : Displays.First();
    }
    public Driver Driver { get; set; } = new();
    public Sound Sound { get; set; } = new();
    public MameCollection<Rom> Roms { get; private set; } = [];
    public bool IsParentMachine => string.IsNullOrEmpty(CloneOf) && !IsDevice && !IsBios;
    public bool IsCloneMachine => !string.IsNullOrEmpty(CloneOf) && !IsDevice && !IsBios;
    public MameCollection<Feature> Features { get; set; } = [];
    public Feature? FeatureOfType(FeatureKind kind) => Features.FirstOrDefault(x => x.Type == kind);

    public override string ToString()
    {
        return $"{Name} - {Description} - " +
            (IsBios ? "BIOS" : string.Empty) +
            (IsParentMachine ? " PARENT" : string.Empty) +
            (IsCloneMachine ? " CLONE" : string.Empty) +
            (IsDevice ? " DEVICE" : string.Empty) +
            (IsRunnable ? " RUNNABLE" : string.Empty);
    }

    public bool RequiresDisks { get; set; }
    public MameCollection<Disk> Disks { get; private set; } = [];


    /// <summary>
    /// Il default è "good" ma gli stati sono tenuti per ciascun disk
    /// Se ho almeno un disk "nodump" il gioco diventa "nodump"
    /// Se ho almeno un disk "baddump" ma nessuna "nodump" il gioco diventa "baddump"
    /// In tutti gli altri casi rimane il default: "good"
    /// </summary>
    public DiskStatusKind DiskOverallStatus
    {
        get
        {
            return Disks is null || Disks.Count == 0
                ? DiskStatusKind.good
                : Disks.Any(x => x.Status == DiskStatusKind.baddump)
                ? DiskStatusKind.baddump
                : Disks.Count(x => x.Status == DiskStatusKind.nodump) == Disks.Count ? DiskStatusKind.nodump : DiskStatusKind.good;
        }
    }

    public int NoDumpRoms => Roms.Count(x => x.Status == RomStatusKind.nodump);
    public int NoDumpDisks => Disks.Count(x => x.Status == DiskStatusKind.nodump);
    public int BadDumpRoms => Roms.Count(x => x.Status == RomStatusKind.baddump);
    public int BadDumpDisks => Disks.Count(x => x.Status == DiskStatusKind.baddump);
    public int GoodDumpRoms => Roms.Count(x => x.Status == RomStatusKind.good);
    public int GoodDumpDisks => Disks.Count(x => x.Status == DiskStatusKind.good);
    public Net48.Machines.Inputs.Input Input { get; set; } = new();
    public MameCollection<BiosSet> BiosSets { get; private set; } = [];
    public MameCollection<DeviceRef> DeviceRefs { get; private set; } = [];
    public SoftwareList SoftwareList { get; set; } = new();
    public MameCollection<Chip> Chips { get; private set; } = [];
    public MameCollection<Device> Devices { get; private set; } = [];
    public MameCollection<RamOption> RamOptions { get; private set; } = [];
    public MameCollection<DipSwitch> DipSwitches { get; private set; } = [];
    public MameCollection<Configuration> Configurations { get; private set; } = [];
    public MameCollection<Port> Ports { get; private set; } = [];
    public MameCollection<Adjuster> Adjusters { get; private set; } = [];
    public MameCollection<Slot> Slots { get; private set; } = [];
    public MameMachineExtra Extra = new();
}
