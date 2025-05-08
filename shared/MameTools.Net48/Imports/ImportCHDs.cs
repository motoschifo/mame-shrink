#nullable enable
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using MameTools.Net48.Resources;
namespace MameTools.Net48.Imports;

public static class ImportCHDs
{
    public static async Task LoadFromFile(Mame mame, string filename, bool loadHeaderOnly = false,
        Action<string?>? progressUpdate = null, string? prefix = "", CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (string.IsNullOrEmpty(filename) || !File.Exists(filename)) return;
        if (string.IsNullOrEmpty(prefix) && !string.IsNullOrEmpty(mame.ReleaseNumber)) prefix = $"[{mame.ReleaseNumber}] ";

        progressUpdate?.Invoke($"{prefix}{Strings.ChdXmlLoading}");

        foreach (var m in mame.Machines)
        {
            m.RequiresDisks = false;
        }
        mame.Machines.Totals.RequiresDisks.ResetCount();
        //mame.Machines.Totals.AvailableDisks.Clear();
        //mame.Machines.Totals.RequiresAvailableDisks = 0;

        var i = 0;
        using XmlTextReader xml = new(filename)
        {
            WhitespaceHandling = WhitespaceHandling.None,
        };
        _ = xml.MoveToContent();

        var ok = false;
        if (xml.NodeType == XmlNodeType.Element && "mame".Equals(xml.LocalName, StringComparison.InvariantCultureIgnoreCase))
        {
            var build = xml.GetAttribute("build");
            progressUpdate?.Invoke($"{prefix}{string.Format(Strings.DetectedReleaseBuild, mame.ReleaseNumber, build)}");
            ok = true;
            if (loadHeaderOnly) return;
        }
        else if (xml.NodeType == XmlNodeType.Element && "datafile".Equals(xml.LocalName, StringComparison.InvariantCultureIgnoreCase))
        {
            while (xml.Read())
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (xml.NodeType == XmlNodeType.EndElement && "header".Equals(xml.LocalName, StringComparison.InvariantCultureIgnoreCase)) break;
                if (xml.NodeType == XmlNodeType.Element && "description".Equals(xml.LocalName, StringComparison.InvariantCultureIgnoreCase))
                {
                    _ = xml.Read();
                    var build = xml.Value ?? string.Empty;
                    progressUpdate?.Invoke($"{prefix}{string.Format(Strings.DetectedReleaseBuild, mame.ReleaseNumber, build)}");
                    ok = true;
                }
            }
            if (loadHeaderOnly) return;
        }
        if (!ok) throw new Exception(string.Format(Strings.MissingRootNode, filename, "mame/datafile"));
        cancellationToken.ThrowIfCancellationRequested();
        Machine.MameMachine? machine = null;
        while (xml.Read())
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (xml.NodeType is not XmlNodeType.Element) continue;
            if ("game".Equals(xml.LocalName, StringComparison.InvariantCultureIgnoreCase) ||
                "machine".Equals(xml.LocalName, StringComparison.InvariantCultureIgnoreCase))
            {
                // Inizio di un nodo "game" o "machine"
                i++;
                if (i % 1000 == 0)
                    progressUpdate?.Invoke(prefix + Strings.ChdXmlLoading + $" [{i:#,##0}] - {machine?.Description}");

                var name = xml.GetAttribute("name");
                if (string.IsNullOrEmpty(name)) continue;
                machine = mame.Machines.FirstOrDefault(x => x.Name == name);
                if (machine is null) throw new Exception($"{string.Format(Strings.MameMachineNotFound, name)} ({filename})");
                //if (machine.RequiresDisks) continue;
                machine.RequiresDisks = true;
                mame.Machines.Totals.RequiresDisks.IncrementCount(name);
            }
            //else if (xml.LocalName == "rom")
            //{

            //    if (machine is null) throw new Exception("XML non valido: nodo machine/game richiesto sopra al nodo 'disk'");
            //    // Inizio di un nodo "disk"
            //    // <disk name="mda-c0004a_revb_lindyellow_v2.4.20_mvl31a_boot_2.01" merge="mda-c0004a_revb_lindyellow_v2.4.20_mvl31a_boot_2.01" sha1="e13da5f827df852e742b594729ee3f933b387410" region="cf" index="0" writable="no"/>
            //    //machine.RequiresCHD = true;   // Se esiste un disco, significa che utilizza dei chd

            //    MameMachineDisk disk = new()
            //    {
            //        Name = xml.GetAttribute("name"),
            //        SHA1 = xml.GetAttribute("sha1"),
            //        Merge = xml.GetAttribute("marge"),
            //        Region = xml.GetAttribute("region"),
            //        Index = xml.GetAttribute("index"),
            //        Writable = xml.GetAttribute("writable") == "yes",
            //        Optional = xml.GetAttribute("optional") == "yes"
            //    };
            //    s = xml.GetAttribute("status")?.Trim()?.ToLower();    // default: good
            //    if (s is not null)
            //        disk.Status = s == "nodump" ? EDiskStatus.nodump : s == "baddump" ? EDiskStatus.baddump : EDiskStatus.good;
            //    machine.AvailableDisks.Add(disk);
            //    mame.Machines.Totals.AvailableDisks.Add(disk);
            //}
        }
        cancellationToken.ThrowIfCancellationRequested();
        xml.Close();

        //// Aggiorno i totali
        //foreach (var m in mame.Machines.Where(x => x.AvailableDisks.Any()))
        //{
        //    mame.Machines.Totals.RequiresAvailableDisks++;
        //    mame.Machines.Totals.AvailableDisks.AddRange(m.AvailableDisks);
        //}
        await Task.CompletedTask;
    }
}
