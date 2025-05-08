#nullable enable
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using MameTools.Net48.Extensions;
using MameTools.Net48.Machines.Samples;
using MameTools.Net48.Resources;
namespace MameTools.Net48.Imports;

public static class ImportSamples
{
    public static async Task LoadFromFile(Mame mame, string filename, bool loadHeaderOnly = false,
        Action<string?>? progressUpdate = null, string? prefix = "", CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (string.IsNullOrEmpty(filename) || !File.Exists(filename)) return;
        if (string.IsNullOrEmpty(prefix) && !string.IsNullOrEmpty(mame.ReleaseNumber)) prefix = $"[{mame.ReleaseNumber}] ";

        progressUpdate?.Invoke($"{prefix}{Strings.SamplesFileLoading}");

        mame.MachineSamples.Clear();
        mame.Machines.Totals.SampleFiles.ResetCount();
        mame.Machines.Totals.SamplePacks.ResetCount();

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
        Sample? sample = null;
        while (xml.Read())
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (xml.NodeType is not XmlNodeType.Element) continue;
            if ("game".Equals(xml.LocalName, StringComparison.InvariantCultureIgnoreCase) || "machine".Equals(xml.LocalName, StringComparison.InvariantCultureIgnoreCase))
            {
                // Inizio di un nodo "machine"
                i++;
                if (i % 1000 == 0)
                    progressUpdate?.Invoke($"{prefix}{Strings.SamplesFileLoading} [{i:#,##0}] - {sample?.Description}");

                var name = xml.GetAttribute("name");
                if (string.IsNullOrEmpty(name)) continue;
                sample = new Sample()
                {
                    Name = name
                };
                mame.MachineSamples.Add(sample);
                mame.Machines.Totals.SamplePacks.IncrementCount(sample.Name);
            }
            else if ("rom".Equals(xml.LocalName, StringComparison.InvariantCultureIgnoreCase))
            {
                if (sample is null)
                    throw new Exception(string.Format(Strings.InvalidXmlNodeRelation, "machine/game", "disk") + $" ({filename})");
                // Inizio di un nodo "rom"
                // <rom name="vg_voi-3.wav" size="80940" crc="f8040659" sha1="6a5512c23c81a51db60eed65fc8b19c6776daaa8"/>
                var rom = new SampleRom()
                {
                    Name = xml.GetAttribute("name"),
                    Size = xml.GetAttribute<int>("size") ?? 0,
                    CRC = xml.GetAttribute("crc"),
                    SHA1 = xml.GetAttribute("sha1")
                };
                sample.Roms.Add(rom);
                mame.Machines.Totals.SampleFiles.IncrementCount($"{sample.Name};{rom.Name}");
            }
        }
        cancellationToken.ThrowIfCancellationRequested();
        xml.Close();
        await Task.CompletedTask;
    }
}
