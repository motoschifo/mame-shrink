#nullable enable
using System.Collections.Generic;
using System.Linq;
using MameTools.Net48.Common;
using MameTools.Net48.Extensions;
using MameTools.Net48.Software.Parts;
using MameTools.Net48.Software.Parts.DataAreas.Roms;
using MameTools.Net48.Software.Parts.Disks;
using MameTools.Net48.Software.SharedFeatures;
using static MameTools.Net48.Software.Parts.Disks.Disk;
namespace MameTools.Net48.Software;

public partial class MameSoftware
{
    public string Name { get; set; } = default!;
    public string? CloneOf { get; set; }
    public SupportedKind Supported { get; set; } = SupportedKind.yes;
    public static SupportedKind ParseSupported(string? value) => value.ToEnum(SupportedKind.unknown, SupportedKind.yes);
    public string? Description { get; set; }
    public string? Year { get; set; }
    public string? Publisher { get; set; }
    public string? Notes { get; set; }
    public MameCollection<Info.Info> Info { get; private set; } = [];
    public MameCollection<SharedFeature> SharedFeatures { get; private set; } = [];
    public MameCollection<Part> Parts { get; private set; } = [];
    public List<Disk> AllDisks => [.. Parts.SelectMany(x => x.DiskAreas).SelectMany(x => x.Disks)];
    public List<Rom> AllRoms => [.. Parts.SelectMany(x => x.DataAreas).SelectMany(x => x.Roms)];

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
            var disks = AllDisks;
            return disks is null || disks.Count == 0
                ? DiskStatusKind.good
                : disks.Any(x => x.Status == DiskStatusKind.baddump)
                ? DiskStatusKind.baddump
                : disks.Count(x => x.Status == DiskStatusKind.nodump) == disks.Count ? DiskStatusKind.nodump : DiskStatusKind.good;
        }
    }

    public bool IsParent => string.IsNullOrEmpty(CloneOf);
    public bool IsClone => !string.IsNullOrEmpty(CloneOf);
}
