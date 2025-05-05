#nullable enable
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MameTools.Machine;
using MameTools.Net48.Config;

namespace MameTools.Net48.Helpers;

public static class MameFiles
{

    public static List<MameFileLocation> GetAllMameMachineFiles(string mameFolder, MameConfiguration config, MameMachine machine,
        string? overrideRomPath = null)
    {
        var ret = new List<MameFileLocation>();
        var folders = new Dictionary<string, string>(){
            { "roms", overrideRomPath ?? config.RomPath },
            { "artwork", config.ArtworkPath },
            { "cabinets", config.CabinetPath },
            { "cfg", config.ConfigDirectory },
            { "cpanel", config.ControlPanelPath },
            { "flyers", config.FlyerPath },
            { "hi", config.HiScorePath },
            { "ini", config.IniPath },
            { "icons", config.IconPath },
            { "inp", config.InputPlaybackDirectory },
            { "marquees", config.MarqueePath },
            { "nvram", config.NvramDirectory },
            { "pcb", config.PcbPath },
            { "snap", config.SnapshotDirectory },
            { "sta", config.StateDirectory },
            { "titles", config.TitlePath },
            { "cheat", config.CheatPath }
        };
        foreach (var folder in folders)
        {
            foreach (var subfolder in MameConfiguration.SplitPath(folder.Value))
            {
                if (subfolder == ".")
                    continue;   // evito di cancellare i file nella cartella principale del Mame
                var path = Path.Combine(mameFolder, config.HomePath, subfolder);
                if (!Directory.Exists(path))
                    continue;
                var files = Directory.GetFiles(path, $"{machine.Name}.*");
                if (files.Length == 0)
                    continue;
                foreach (var file in files)
                {
                    if (ret.Exists(x => x.Filename == file))
                        continue;
                    ret.Add(new MameFileLocation
                    {
                        Filename = file,
                        RelativeFolder = folder.Key
                    });
                }
            }
        }
        return ret;
    }

    public static void DeleteMameFiles(string mamePath, MameMachine machine, MameConfiguration config, string? overrideRomPath = null, bool useRecycleBin = false)
    {
        var files = MameFiles.GetAllMameMachineFiles(mamePath, config, machine, overrideRomPath);
        if (useRecycleBin)
        {
            _ = RecycleBinHelper.RecycleFiles([.. files.Select(x => x.Filename)]);
        }
        else
        {
            foreach (var file in files)
            {
                File.Delete(file.Filename);
            }
        }
    }

}
