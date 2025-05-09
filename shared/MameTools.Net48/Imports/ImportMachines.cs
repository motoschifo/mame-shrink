#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using MameTools.Machine;
using MameTools.Net48.Extensions;
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
using MameTools.Net48.Machines.Inputs;
using MameTools.Net48.Machines.Legacy;
using MameTools.Net48.Machines.Ports;
using MameTools.Net48.Machines.RamOptions;
using MameTools.Net48.Machines.Roms;
using MameTools.Net48.Machines.Samples;
using MameTools.Net48.Machines.Shared;
using MameTools.Net48.Machines.Slots;
using MameTools.Net48.Machines.Sounds;
using MameTools.Net48.Resources;
using NLog;
using static MameTools.Net48.Machines.Displays.Display;
namespace MameTools.Net48.Imports;

public static class ImportMachines
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public static async Task LoadFromFile(Mame mame, string filename, bool loadHeaderOnly = false, Action<string?>? progressUpdate = null,
        string? prefix = "", int loadNodes = MameMachineNodes.Defaults, CancellationToken cancellationToken = default)
    {
        mame.Machines.Clear();
        cancellationToken.ThrowIfCancellationRequested();
        if (string.IsNullOrEmpty(filename) || !File.Exists(filename)) return;
        if (string.IsNullOrEmpty(prefix) && !string.IsNullOrEmpty(mame.ReleaseNumber)) prefix = $"[{mame.ReleaseNumber}] ";

        var i = 0;
        //CacheManager<MameMachineCollection>? cache = null;
        //if (useCache)
        //{
        //    progressUpdate?.Invoke($"{prefix} Lettura file xml giochi dalla cache");
        //    cache = new(cachePath!);
        //    var machines = cache.GetCachedFile(cacheType!, new FileInfo(filename).Name);
        //    if (machines is not null && machines.Any())
        //    {
        //        //mame.Machines.Replace(machines);
        //        mame.Machines.Clear();
        //        foreach (var m in machines)
        //        {
        //            i++;
        //            if (i % 1000 == 0)
        //                progressUpdate?.Invoke(prefix + string.Format("Lettura file xml giochi [{0}] - {1}", i.ToString("#,##0"), m?.Description));
        //            mame.Machines.Add(m);
        //        }
        //        return;
        //    }
        //}

        progressUpdate?.Invoke($"{prefix}{Strings.MachinesFileLoading}");

        using XmlTextReader xml = new(filename)
        {
            WhitespaceHandling = WhitespaceHandling.None,
        };
        _ = xml.MoveToContent();

        var isOfficialMame = false;
        var isPsDataFile = false;
        if (xml.NodeType == XmlNodeType.Element && "mame".EqualsIgnoreCase(xml.LocalName))
        {
            mame.Build = xml.GetAttribute("build");
            mame.Debug = "yes".EqualsIgnoreCase(xml.GetAttribute("debug"));
            mame.MameConfig = xml.GetAttribute("mameconfig");
            progressUpdate?.Invoke(string.Format(Strings.DetectedReleaseBuild, mame.ReleaseNumber, mame.Build));
            isOfficialMame = true;
            if (loadHeaderOnly) return;
        }
        else if (xml.NodeType == XmlNodeType.Element && "datafile".EqualsIgnoreCase(xml.LocalName))
        {
            while (xml.Read())
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (xml.NodeType == XmlNodeType.EndElement && "header".EqualsIgnoreCase(xml.LocalName)) break;
                if (xml.NodeType == XmlNodeType.Element && "description".EqualsIgnoreCase(xml.LocalName))
                {
                    _ = xml.Read();
                    mame.Build = xml.Value ?? string.Empty;
                    progressUpdate?.Invoke(string.Format(Strings.DetectedReleaseBuild, mame.ReleaseNumber, mame.Build));
                    isPsDataFile = true;
                }
            }
            if (loadHeaderOnly) return;
        }

        cancellationToken.ThrowIfCancellationRequested();
        MameMachine? machine = null;
        //var stopwatch = Stopwatch.StartNew();

        if (!xml.IsEmptyElement)
        {
            while (xml.Read())
            {
                if (!xml.IsStartElement())
                    continue;
                cancellationToken.ThrowIfCancellationRequested();
                if ("game".EqualsIgnoreCase(xml.LocalName) || "machine".EqualsIgnoreCase(xml.LocalName))
                {
                    // Inizio di un nodo "game" o "machine"
                    i++;
                    if (i % 1000 == 0)
                        progressUpdate?.Invoke($"{prefix}{Strings.MachinesFileLoading} [{i:#,##0}] - {machine?.Description}");

                    machine = ProcessNodeMachine(xml, mame.ReleaseSequence, loadNodes);
                    mame.Machines.Add(machine);
                    continue;
                }
            }
        }
        cancellationToken.ThrowIfCancellationRequested();
        xml.Close();
        //stopwatch.Stop();
        //Console.WriteLine($"{mame.Machines.Count} nodes read ({stopwatch.ElapsedMilliseconds} ms)");

        //// Se una macchina ha dischi, anche il bios/romof viene segnata come requires CHD
        //foreach (var m in mame.Machines.Where(x => x.RequiresCHD))
        //{
        //    if (string.IsNullOrEmpty(m.RomOf)) continue;
        //    var romof = mame.Machines.FirstOrDefault(x => x.Name == m.RomOf);
        //    if (romof is null || !romof.IsBios) continue;
        //    romof.RequiresCHD = true;
        //}

        //if (useCache)
        //{
        //    progressUpdate?.Invoke($"{prefix} Scrittura file xml giochi nella cache");
        //    cache!.SetCacheFile(cacheType!, new FileInfo(filename).Name, mame.Machines);
        //}
        await Task.CompletedTask;
    }

    private static MameMachine ProcessNodeMachine(XmlReader xml, decimal releaseSequence, int loadNodes)
    {
        var nodeName = xml.LocalName;
        var machine = new MameMachine
        {
            ReleaseSequence = releaseSequence,
            Name = xml.GetAttribute("name"),
            SourceFile = xml.GetAttribute("sourcefile"),
            IsBios = "yes".EqualsIgnoreCase(xml.GetAttribute("isbios")),
            IsDevice = "yes".EqualsIgnoreCase(xml.GetAttribute("isdevice")),
            IsMechanical = "yes".EqualsIgnoreCase(xml.GetAttribute("ismechanical")),
            IsRunnable = !"no".EqualsIgnoreCase(xml.GetAttribute("runnable")),
            CloneOf = xml.GetAttribute("cloneof"),
            RomOf = xml.GetAttribute("romof"),
            SampleOf = xml.GetAttribute("sampleof")
        };
        if (machine.IsMechanical)
            machine.Extra.Genre = Strings.Mechanical;
        else if (machine.IsDevice)
            machine.Extra.Genre = Strings.DetectedReleaseBuild;
        else if (machine.IsBios)
            machine.Extra.Genre = Strings.Bios;

        if (!xml.IsEmptyElement)
        {
            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.EndElement && nodeName.EqualsIgnoreCase(xml.LocalName))
                    break;
                if (!xml.IsStartElement())
                    continue;

                if ("description".EqualsIgnoreCase(xml.LocalName))
                {
                    _ = xml.Read();
                    machine.Description = xml.Value;
                }
                else if ("year".EqualsIgnoreCase(xml.LocalName))
                {
                    _ = xml.Read();
                    machine.Year = xml.Value;
                }
                else if ("manufacturer".EqualsIgnoreCase(xml.LocalName))
                {
                    _ = xml.Read();
                    machine.Manufacturer = xml.Value;
                }
                else if ("history".EqualsIgnoreCase(xml.LocalName))
                {
                    _ = xml.Read();
                    machine.History = xml.Value;
                }
                else if ("biosset".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.BiosSet) == 0)
                        continue;
                    machine.BiosSets.Add(ProcessNodeBiosSet(xml));
                }
                else if ("rom".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.Rom) == 0)
                        continue;
                    machine.Roms.Add(ProcessNodeRom(xml));
                }
                else if ("disk".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.Disk) == 0)
                        continue;
                    machine.Disks.Add(ProcessNodeDisk(xml));
                    machine.RequiresDisks = true;
                }
                else if ("device_ref".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.DeviceRef) == 0)
                        continue;
                    machine.DeviceRefs.Add(ProcessNodeDeviceRef(xml));
                }
                else if ("sample".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.Sample) == 0)
                        continue;
                    machine.Samples.Add(ProcessNodeSample(xml));
                }
                else if ("chip".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.Chip) == 0)
                        continue;
                    machine.Chips.Add(ProcessNodeChip(xml));
                }
                else if ("display".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.Display) == 0)
                        continue;
                    machine.Displays.Add(ProcessNodeDisplay(xml));
                }
                else if ("sound".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.Sound) == 0)
                        continue;
                    machine.Sound = ProcessNodeSound(xml);
                }
                else if ("input".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.Input) == 0)
                        continue;
                    machine.Input = ProcessNodeInput(xml, out var legacyValues);
                    machine.LegacyValues.AddRange(legacyValues);
                }
                else if ("dipswitch".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.DipSwitch) == 0)
                        continue;
                    machine.DipSwitches.Add(ProcessNodeDipSwitch(xml));
                }
                else if ("configuration".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.Configuration) == 0)
                        continue;
                    machine.Configurations.Add(ProcessNodeConfiguration(xml));
                }
                else if ("port".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.Port) == 0)
                        continue;
                    machine.Ports.Add(ProcessNodePort(xml));
                }
                else if ("adjuster".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.Adjuster) == 0)
                        continue;
                    machine.Adjusters.Add(ProcessNodeAdjuster(xml));
                }
                else if ("driver".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.Driver) == 0)
                        continue;
                    machine.Driver = ProcessNodeDriver(xml, out var legacyValues);
                    machine.LegacyValues.AddRange(legacyValues);
                }
                else if ("feature".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.Feature) == 0)
                        continue;
                    machine.Features.Add(ProcessNodeFeature(xml));
                }
                else if ("device".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.Device) == 0)
                        continue;
                    machine.Devices.Add(ProcessNodeDevice(xml));
                }
                else if ("slot".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.Slot) == 0)
                        continue;
                    machine.Slots.Add(ProcessNodeSlot(xml));
                }
                else if ("softwarelist".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.SoftwareList) == 0)
                        continue;
                    machine.SoftwareList = ProcessNodeSoftwareList(xml);
                }
                else if ("ramoption".EqualsIgnoreCase(xml.LocalName))
                {
                    if ((loadNodes & MameMachineNodes.RamOption) == 0)
                        continue;
                    machine.RamOptions.Add(ProcessNodeRamOption(xml));
                }
                else if ("video".EqualsIgnoreCase(xml.LocalName))
                {
                    // Nodo deprecato
                    if ((loadNodes & MameMachineNodes.Display) == 0)
                        continue;
                    machine.Displays.Add(ProcessNodeVideo(xml));
                }
            }
        }

        FixLegacyValues(machine);
        return machine;
    }

    private static Configuration ProcessNodeConfiguration(XmlReader xml)
    {
        var nodeName = xml.LocalName;
        var config = new Configuration
        {
            Name = xml.GetAttribute("name"),
            Tag = xml.GetAttribute("tag"),
            Mask = xml.GetAttribute("mask")
        };

        if (!xml.IsEmptyElement)
        {
            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.EndElement && nodeName.EqualsIgnoreCase(xml.LocalName))
                    break;

                if (!xml.IsStartElement()) continue;

                if ("condition".EqualsIgnoreCase(xml.LocalName))
                {
                    config.Condition = new Condition
                    {
                        Tag = xml.GetAttribute("tag"),
                        Mask = xml.GetAttribute("mask"),
                        Relation = Condition.ParseRelation(xml.GetAttribute("relation")),
                        Value = xml.GetAttribute("value")
                    };
                }
                else if ("conflocation".EqualsIgnoreCase(xml.LocalName))
                {
                    config.ConfLocations.Add(new ConfLocation
                    {
                        Name = xml.GetAttribute("name"),
                        Number = xml.GetAttribute<int>("number") ?? 0,
                        Inverted = "yes".EqualsIgnoreCase(xml.GetAttribute("inverted"))
                    });
                }
                else if ("confsetting".EqualsIgnoreCase(xml.LocalName))
                {
                    var setting = new ConfSetting
                    {
                        Name = xml.GetAttribute("name"),
                        Value = xml.GetAttribute("value"),
                        Default = "yes".EqualsIgnoreCase(xml.GetAttribute("default"))
                    };
                    config.ConfSettings.Add(setting);
                }
            }
        }
        return config;
    }

    private static Port ProcessNodePort(XmlReader xml)
    {
        var nodeName = xml.LocalName;
        var port = new Port
        {
            Tag = xml.GetAttribute("tag")
        };

        if (!xml.IsEmptyElement)
        {
            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.EndElement && nodeName.EqualsIgnoreCase(xml.LocalName))
                    break;
                if (!xml.IsStartElement()) continue;
                if ("analog".EqualsIgnoreCase(xml.LocalName))
                {
                    port.Analogs.Add(new Analog
                    {
                        Mask = xml.GetAttribute("mask")
                    });
                }
            }
        }
        return port;
    }

    private static Slot ProcessNodeSlot(XmlReader xml)
    {
        var nodeName = xml.LocalName;
        var slot = new Slot
        {
            Name = xml.GetAttribute("name")
        };

        if (!xml.IsEmptyElement)
        {
            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.EndElement && nodeName.EqualsIgnoreCase(xml.LocalName))
                    break;

                if (!xml.IsStartElement()) continue;

                if ("slotoption".EqualsIgnoreCase(xml.LocalName))
                {
                    slot.SlotOptions.Add(new SlotOption
                    {
                        Name = xml.GetAttribute("name"),
                        DevName = xml.GetAttribute("devname"),
                        Default = "yes".EqualsIgnoreCase(xml.GetAttribute("default"))
                    });
                }
            }
        }
        return slot;
    }

    private static Rom ProcessNodeRom(XmlReader xml)
    {
        // <rom name="1346b.cpu-u25" size="2048" crc="8e68533e" sha1="a257c556d31691068ed5c991f1fb2b51da4826db" region="maincpu" offset="0" status="nodump"/>
        return new Rom
        {
            Name = xml.GetAttribute("name"),
            Bios = xml.GetAttribute("bios"),
            Size = xml.GetAttribute<int>("size") ?? 0,
            CRC = xml.GetAttribute("crc"),
            MD5 = xml.GetAttribute("md5"),
            SHA1 = xml.GetAttribute("sha1"),
            Merge = xml.GetAttribute("merge"),
            Region = xml.GetAttribute("region"),
            Offset = xml.GetAttribute("offset"),
            Optional = "yes".EqualsIgnoreCase(xml.GetAttribute("optional")),
            Status = Rom.ParseStatus(xml.GetAttribute("status")),
            Dispose = "yes".EqualsIgnoreCase(xml.GetAttribute("dispose")),
            SoundOnly = "yes".EqualsIgnoreCase(xml.GetAttribute("soundonly")),
        };
    }

    private static Adjuster ProcessNodeAdjuster(XmlReader xml)
    {
        var nodeName = xml.LocalName;
        var adjuster = new Adjuster
        {
            Name = xml.GetAttribute("name"),
            Default = xml.GetAttribute<int>("default") ?? 0
        };

        if (!xml.IsEmptyElement)
        {
            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.EndElement && nodeName.EqualsIgnoreCase(xml.LocalName))
                    break;

                if (!xml.IsStartElement()) continue;

                if ("condition".EqualsIgnoreCase(xml.LocalName))
                {
                    adjuster.Condition = new Condition
                    {
                        Tag = xml.GetAttribute("tag"),
                        Mask = xml.GetAttribute("mask"),
                        Relation = Condition.ParseRelation(xml.GetAttribute("relation")),
                        Value = xml.GetAttribute("value")
                    };
                }
            }
        }

        return adjuster;
    }

    private static BiosSet ProcessNodeBiosSet(XmlReader xml)
    {
        return new BiosSet
        {
            Name = xml.GetAttribute("name"),
            Description = xml.GetAttribute("description"),
            Default = "yes".EqualsIgnoreCase(xml.GetAttribute("default")),
        };
    }

    private static DeviceRef ProcessNodeDeviceRef(XmlReader xml)
    {
        return new DeviceRef()
        {
            Name = xml.GetAttribute("name"),
        };
    }

    private static Sample ProcessNodeSample(XmlReader xml)
    {
        // <sample name="explode1"/>
        return new Sample
        {
            Name = xml.GetAttribute("name")
        };
    }

    private static Chip ProcessNodeChip(XmlReader xml)
    {
        //<!ELEMENT chip EMPTY>
        //	<!ATTLIST chip name CDATA #REQUIRED>
        //	<!ATTLIST chip tag CDATA #IMPLIED>
        //	<!ATTLIST chip type (cpu|audio) #REQUIRED>
        //	<!ATTLIST chip clock CDATA #IMPLIED>
        // Es.
        // <chip type="cpu" tag="maincpu" name="Zilog Z80" clock="3867120"/>
        // <chip type="audio" tag="speaker" name="Speaker"/>
        // <chip type="audio" tag="samples" name="Samples"/>
        // <chip type="audio" tag="005" name="Sega 005 Custom Sound"/>
        return new Chip
        {
            Type = Chip.ParseType(xml.GetAttribute("type")),
            Tag = xml.GetAttribute("tag"),
            Name = xml.GetAttribute("name"),
            Clock = xml.GetAttribute<int>("clock") ?? 0,
            SoundOnly = "yes".EqualsIgnoreCase(xml.GetAttribute("soundonly")),
        };
    }

    private static Display ProcessNodeDisplay(XmlReader xml)
    {
        var rotate = xml.GetAttribute<int>("rotate") ?? 0;
        var width = xml.GetAttribute<int>("width") ?? 0;
        var height = xml.GetAttribute<int>("height") ?? 0;
        var ret = new Display
        {
            // Il tag screen ha la precedenza, se indicato, altrimenti considero il primo display elencato
            Tag = xml.GetAttribute("tag"),
            Type = Display.ParseType(xml.GetAttribute("type")),
            FlipX = "yes".EqualsIgnoreCase(xml.GetAttribute("flipx")),
            PixClock = xml.GetAttribute<int>("pixclock") ?? 0,
            HTotal = xml.GetAttribute<int>("htotal") ?? 0,
            HBend = xml.GetAttribute<int>("hbend") ?? 0,
            HBStart = xml.GetAttribute<int>("hbstart") ?? 0,
            VTotal = xml.GetAttribute<int>("vtotal") ?? 0,
            VBEnd = xml.GetAttribute<int>("vbend") ?? 0,
            VBStart = xml.GetAttribute<int>("vbstart") ?? 0,
            Refresh = xml.GetAttribute<decimal>("refresh") ?? 0,
            Rotate = rotate,
            // Orientamento
            //     <display tag="screen" type="raster" rotate="270" width="256" height="224" refresh="60.000000" />
            Orientation = rotate is 90 or 270 ? DisplayOrientationKind.vertical : DisplayOrientationKind.horizontal,
            Width = rotate is 90 or 270 ? height : width,
            Height = rotate is 90 or 270 ? width : height,
        };
        return ret;
    }

    private static Sound ProcessNodeSound(XmlReader xml)
    {
        return new Sound
        {
            Channels = xml.GetAttribute<int>("channels") ?? 0
        };
    }

    private static DipSwitch ProcessNodeDipSwitch(XmlReader xml)
    {
        var nodeName = xml.LocalName;
        var dipSwitch = new DipSwitch
        {
            Name = xml.GetAttribute("name"),
            Tag = xml.GetAttribute("tag"),
            Mask = xml.GetAttribute("mask")
        };

        if (!xml.IsEmptyElement)
        {
            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.EndElement && nodeName.EqualsIgnoreCase(xml.LocalName))
                    break;

                if (!xml.IsStartElement()) continue;

                if ("condition".EqualsIgnoreCase(xml.LocalName))
                {
                    dipSwitch.Condition = new Condition
                    {
                        Tag = xml.GetAttribute("tag"),
                        Mask = xml.GetAttribute("mask"),
                        Relation = Condition.ParseRelation(xml.GetAttribute("relation")),
                        Value = xml.GetAttribute("value")
                    };
                }
                else if ("diplocation".EqualsIgnoreCase(xml.LocalName))
                {
                    dipSwitch.DipLocations.Add(new DipLocation
                    {
                        Name = xml.GetAttribute("name"),
                        Number = xml.GetAttribute<int>("number") ?? 0,
                        Inverted = "yes".EqualsIgnoreCase(xml.GetAttribute("inverted"))
                    });
                }
                else if ("dipvalue".EqualsIgnoreCase(xml.LocalName))
                {
                    var dipValue = new DipValue
                    {
                        Name = xml.GetAttribute("name"),
                        Value = xml.GetAttribute("value"),
                        Default = "yes".EqualsIgnoreCase(xml.GetAttribute("default"))
                    };

                    if (!xml.IsEmptyElement)
                    {
                        while (xml.Read())
                        {
                            if (xml.NodeType == XmlNodeType.EndElement && "dipvalue".EqualsIgnoreCase(xml.LocalName))
                                break;
                            if (!xml.IsStartElement()) continue;
                            if ("condition".EqualsIgnoreCase(xml.LocalName))
                            {
                                dipValue.Condition = new Condition
                                {
                                    Tag = xml.GetAttribute("tag"),
                                    Mask = xml.GetAttribute("mask"),
                                    Relation = Condition.ParseRelation(xml.GetAttribute("relation")),
                                    Value = xml.GetAttribute("value")
                                };
                            }
                        }
                    }
                    dipSwitch.DipValues.Add(dipValue);
                }
            }
        }
        return dipSwitch;
    }

    private static Driver ProcessNodeDriver(XmlReader xml, out List<LegacyValue>? legacyValues)
    {
        legacyValues = null;
        var driver = new Driver
        {
            Status = Driver.ParseStatus(xml.GetAttribute("status")),
            Emulation = Driver.ParseEmulation(xml.GetAttribute("emulation")),
            SaveState = Driver.ParseSaveState(xml.GetAttribute("savestate")),
            RequiresArtwork = "yes".EqualsIgnoreCase(xml.GetAttribute("requiresartwork")),
            Unofficial = "yes".EqualsIgnoreCase(xml.GetAttribute("unofficial")),
            NoSoundHardware = "yes".EqualsIgnoreCase(xml.GetAttribute("nosoundhardware")),
            Incomplete = "yes".EqualsIgnoreCase(xml.GetAttribute("incomplete")),
            PaletteSize = xml.GetAttribute<int>("palettesize") ?? 0,
        };
        var legacyColor = xml.GetAttribute("color");
        if (!string.IsNullOrEmpty(legacyColor))
        {
            legacyValues =
            [
                new LegacyValue
                {
                    ParentNode = "driver",
                    Node = "color",
                    Value = legacyColor
                },
            ];
        }
        return driver;
    }

    private static Device ProcessNodeDevice(XmlReader xml)
    {
        var nodeName = xml.LocalName;
        //<!ELEMENT device (instance?, extension*)>
        //	<!ATTLIST device type CDATA #REQUIRED>
        //	<!ATTLIST device tag CDATA #IMPLIED>
        //	<!ATTLIST device fixed_image CDATA #IMPLIED>
        //	<!ATTLIST device mandatory CDATA #IMPLIED>
        //	<!ATTLIST device interface CDATA #IMPLIED>
        //	<!ELEMENT instance EMPTY>
        //		<!ATTLIST instance name CDATA #REQUIRED>
        //		<!ATTLIST instance briefname CDATA #REQUIRED>
        //	<!ELEMENT extension EMPTY>
        //		<!ATTLIST extension name CDATA #REQUIRED>
        // Es.
        // <device type="memcard" tag="memcard">
        // 	 <instance name="memcard" briefname="memc"/>
        // 	 <extension name="neo"/>
        // </device>

        var device = new Device
        {
            Type = xml.GetAttribute("type"),
            Tag = xml.GetAttribute("tag"),
            FixedImage = "1".EqualsIgnoreCase(xml.GetAttribute("fixed_image")),
            Mandatory = "1".EqualsIgnoreCase(xml.GetAttribute("mandatory")),
            Interface = xml.GetAttribute("interface")
        };

        // Devo leggere i due sottonodi "instance" ed "extension":
        //<!ELEMENT device (instance?, extension*)>
        // <!ATTLIST device type CDATA #REQUIRED>
        // <!ATTLIST device tag CDATA #IMPLIED>
        // <!ATTLIST device fixed_image CDATA #IMPLIED>
        // <!ATTLIST device mandatory CDATA #IMPLIED>
        // <!ATTLIST device interface CDATA #IMPLIED>
        // <!ELEMENT instance EMPTY>
        //  <!ATTLIST instance name CDATA #REQUIRED>
        //  <!ATTLIST instance briefname CDATA #REQUIRED>
        // <!ELEMENT extension EMPTY>
        //  <!ATTLIST extension name CDATA #REQUIRED>

        // Legge i nodi figli di <device> finché non arriva alla fine del nodo device
        if (!xml.IsEmptyElement)
        {
            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.EndElement && nodeName.EqualsIgnoreCase(xml.LocalName))
                    break;
                if (!xml.IsStartElement())
                    continue;
                if ("instance".EqualsIgnoreCase(xml.LocalName))
                {
                    device.Instance = new Instance
                    {
                        Name = xml.GetAttribute("name"),
                        BriefName = xml.GetAttribute("briefname")
                    };
                }
                else if ("extension".EqualsIgnoreCase(xml.LocalName))
                {
                    device.Extensions.Add(new()
                    {
                        Name = xml.GetAttribute("name")
                    });
                }
            }
        }
        return device;
    }

    private static Machines.SoftwareList.SoftwareList ProcessNodeSoftwareList(XmlReader xml)
    {
        // <softwarelist tag="cart_list" name="vc4000" status="original"/>
        //<!ELEMENT softwarelist EMPTY>
        //	<!ATTLIST softwarelist tag CDATA #REQUIRED>
        //	<!ATTLIST softwarelist name CDATA #REQUIRED>
        //	<!ATTLIST softwarelist status (original|compatible) #REQUIRED>
        //	<!ATTLIST softwarelist filter CDATA #IMPLIED>
        return new Machines.SoftwareList.SoftwareList
        {
            Tag = xml.GetAttribute("tag"),
            Name = xml.GetAttribute("name"),
            Status = Machines.SoftwareList.SoftwareList.ParseStatus(xml.GetAttribute("status")),
            Filter = xml.GetAttribute("filter")
        };
    }

    private static RamOption ProcessNodeRamOption(XmlReader xml)
    {
        //<!ELEMENT ramoption (#PCDATA)>
        //	<!ATTLIST ramoption name CDATA #REQUIRED>
        //	<!ATTLIST ramoption default CDATA #IMPLIED>
        // Es.
        // <ramoption name="16K">16384</ramoption>
        // <ramoption name="32K">32768</ramoption>
        // <ramoption name="8K" default="yes">8192</ramoption>
        return new RamOption()
        {
            Name = xml.GetAttribute("name"),
            Default = "yes".EqualsIgnoreCase(xml.GetAttribute("default")),
        };
    }

    private static Feature ProcessNodeFeature(XmlReader xml)
    {
        //<!ELEMENT feature EMPTY>
        //    <!ATTLIST feature type (protection|timing|graphics|palette|sound|capture|camera|microphone|controls|keyboard|mouse|media|disk|printer|tape|punch|drum|rom|comms|lan|wan) #REQUIRED>
        //    <!ATTLIST feature status (unemulated|imperfect) #IMPLIED>
        //    <!ATTLIST feature overall (unemulated|imperfect) #IMPLIED>
        return new Feature
        {
            Type = Feature.Parse(xml.GetAttribute("type")),
            Status = Feature.ParseStatus(xml.GetAttribute("status")),
            Overall = Feature.ParseOverall(xml.GetAttribute("overall")),
        };
    }

    private static Display ProcessNodeVideo(XmlReader xml)
    {
        // Fino alla versione 0.106u9 horizontal e vertical non sono calcolate correttamente (vengono tutte conteggiate
        // come "horizontal"). Dalla versione 0.100 alla 0.106u9 esiste l'attributo "orientation", che può essere "vertical"
        // oppure "horizontal".sempre prendendo come esempio la versione 0.100 abbiamo 4.079 "horizontal screen",
        // 1.699 "vertical screen"(5.803 + 25 bios = 5.803 items totali).Dalla versione 0.106u9 alla 0.106u11 non
        // vengonono calcolati correttamente, dalla versione 0.107 in poi i conteggi sono corretti).
        // Dalla versione 0.106u12 il calcolo ￨ corretto.

        //<!ELEMENT video EMPTY>
        //	<!ATTLIST video screen (raster|vector) #REQUIRED>
        //	<!ATTLIST video orientation (vertical|horizontal) #REQUIRED>
        //	<!ATTLIST video width CDATA #IMPLIED>
        //	<!ATTLIST video height CDATA #IMPLIED>
        //	<!ATTLIST video aspectx CDATA #IMPLIED>
        //	<!ATTLIST video aspecty CDATA #IMPLIED>
        //	<!ATTLIST video refresh CDATA #REQUIRED>
        var width = xml.GetAttribute<int>("width") ?? 0;
        var height = xml.GetAttribute<int>("height") ?? 0;
        var orientation = Display.ParseOrientation(xml.GetAttribute("orientation"));
        var display = new Display()
        {
            Tag = xml.GetAttribute("tag"),
            Type = Display.ParseType(xml.GetAttribute("screen")),
            Orientation = orientation,
            Refresh = xml.GetAttribute<decimal>("refresh") ?? 0,
            Width = orientation == DisplayOrientationKind.vertical ? height : width,
            Height = orientation == DisplayOrientationKind.vertical ? width : height,
            AspectX = xml.GetAttribute<int>("aspectx") ?? 1,
            AspectY = xml.GetAttribute<int>("aspecty") ?? 1,
        };
        return display;
    }

    private static Input ProcessNodeInput(XmlReader xml, out List<LegacyValue>? legacyValues)
    {
        legacyValues = null;
        var nodeName = xml.LocalName;
        #region <!ELEMENT input (control*)>
        //	<!ATTLIST input service (yes|no) "no">
        //	<!ATTLIST input tilt (yes|no) "no">
        //	<!ATTLIST input players CDATA #REQUIRED>
        //	<!ATTLIST input coins CDATA #IMPLIED>
        //	<!ELEMENT control EMPTY>
        //		<!ATTLIST control type CDATA #REQUIRED>
        //		<!ATTLIST control player CDATA #IMPLIED>
        //		<!ATTLIST control buttons CDATA #IMPLIED>
        //		<!ATTLIST control reqbuttons CDATA #IMPLIED>
        //		<!ATTLIST control minimum CDATA #IMPLIED>
        //		<!ATTLIST control maximum CDATA #IMPLIED>
        //		<!ATTLIST control sensitivity CDATA #IMPLIED>
        //		<!ATTLIST control keydelta CDATA #IMPLIED>
        //		<!ATTLIST control reverse (yes|no) "no">
        //		<!ATTLIST control ways CDATA #IMPLIED>
        //		<!ATTLIST control ways2 CDATA #IMPLIED>
        //		<!ATTLIST control ways3 CDATA #IMPLIED>
        //<input players="1" coins="2" service="yes" tilt="yes">
        //	<control type="paddle" buttons="5" minimum="0" maximum="65280" sensitivity="30" keydelta="30"/>
        //	<control type="pedal" minimum="0" maximum="65280" sensitivity="100" keydelta="40"/>
        //</input>
        #endregion
        var input = new Input
        {
            Service = "yes".EqualsIgnoreCase(xml.GetAttribute("service")),
            Tilt = "yes".EqualsIgnoreCase(xml.GetAttribute("tilt")),
            Coins = xml.GetAttribute<int>("coins") ?? 0,
            Players = xml.GetAttribute<int>("players") ?? 0
        };
        var legacyButtons = xml.GetAttribute("buttons");
        if (legacyButtons is not null)
        {
            legacyValues ??= [];
            legacyValues.Add(new LegacyValue
            {
                ParentNode = "input",
                Node = "buttons",
                Value = legacyButtons
            });
        }
        var legacyControl = xml.GetAttribute("control");
        if (!string.IsNullOrEmpty(legacyControl))
        {
            legacyValues ??= [];
            legacyValues.Add(new LegacyValue
            {
                ParentNode = "input",
                Node = "control",
                Value = legacyControl
            });
        }

        if (!xml.IsEmptyElement)
        {
            #region <!ELEMENT input (control*)>
            //	<!ATTLIST input service (yes|no) "no">
            //	<!ATTLIST input tilt (yes|no) "no">
            //	<!ATTLIST input players CDATA #REQUIRED>
            //	<!ATTLIST input coins CDATA #IMPLIED>
            //	<!ELEMENT control EMPTY>
            //		<!ATTLIST control type CDATA #REQUIRED>
            //		<!ATTLIST control player CDATA #IMPLIED>
            //		<!ATTLIST control buttons CDATA #IMPLIED>
            //		<!ATTLIST control reqbuttons CDATA #IMPLIED>
            //		<!ATTLIST control minimum CDATA #IMPLIED>
            //		<!ATTLIST control maximum CDATA #IMPLIED>
            //		<!ATTLIST control sensitivity CDATA #IMPLIED>
            //		<!ATTLIST control keydelta CDATA #IMPLIED>
            //		<!ATTLIST control reverse (yes|no) "no">
            //		<!ATTLIST control ways CDATA #IMPLIED>
            //		<!ATTLIST control ways2 CDATA #IMPLIED>
            //		<!ATTLIST control ways3 CDATA #IMPLIED>
            //<input players="1" coins="2" service="yes" tilt="yes">
            //	<control type="paddle" buttons="5" minimum="0" maximum="65280" sensitivity="30" keydelta="30"/>
            //	<control type="pedal" minimum="0" maximum="65280" sensitivity="100" keydelta="40"/>
            //</input>
            #endregion
            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.EndElement && nodeName.EqualsIgnoreCase(xml.LocalName))
                    break;

                if (!xml.IsStartElement()) continue;

                if ("control".EqualsIgnoreCase(xml.LocalName))
                {
                    var control = new Control
                    {
                        Type = xml.GetAttribute("type"),
                        Player = xml.GetAttribute<int>("player") ?? 0,
                        Buttons = xml.GetAttribute<int>("buttons") ?? 0,
                        RequiredButtons = xml.GetAttribute<int>("reqbuttons") ?? 0,
                        Minimum = xml.GetAttribute<int>("minimum") ?? 0,
                        Maximum = xml.GetAttribute<int>("maximum") ?? 0,
                        Sensitivity = xml.GetAttribute<int>("sensitivity") ?? 0,
                        KeyDelta = xml.GetAttribute<int>("keydelta") ?? 0,
                        Reverse = "yes".EqualsIgnoreCase(xml.GetAttribute("reverse")),
                        Ways = xml.GetAttribute<int>("ways") ?? 0,
                        Ways2 = xml.GetAttribute<int>("ways2") ?? 0,
                        Ways3 = xml.GetAttribute<int>("ways3") ?? 0
                    };
                    input.Controls.Add(control);
                }
            }
        }
        return input;
    }

    private static Disk ProcessNodeDisk(XmlReader xml)
    {
        // <disk name="mda-c0004a_revb_lindyellow_v2.4.20_mvl31a_boot_2.01" merge="mda-c0004a_revb_lindyellow_v2.4.20_mvl31a_boot_2.01" sha1="e13da5f827df852e742b594729ee3f933b387410" region="cf" index="0" writable="no"/>
        return new Disk
        {
            Name = xml.GetAttribute("name"),
            MD5 = xml.GetAttribute("md5"),
            SHA1 = xml.GetAttribute("sha1"),
            Merge = xml.GetAttribute("marge"),
            Region = xml.GetAttribute("region"),
            Index = xml.GetAttribute("index"),
            Writable = "yes".EqualsIgnoreCase(xml.GetAttribute("writable")),
            Optional = "yes".EqualsIgnoreCase(xml.GetAttribute("optional")),
            Status = Disk.ParseStatus(xml.GetAttribute("status"))
        };
    }


    private static readonly Dictionary<string, string> _typeMap = new(StringComparer.OrdinalIgnoreCase)
    {
        ["dial"] = "dial",
        ["lightgun"] = "lightgun",
        ["paddle"] = "paddle",
        ["stick"] = "stick",
        ["trackball"] = "trackball",
        ["doublejoy4way"] = "doublejoy",
        ["doublejoy8way"] = "doublejoy",
        ["joy2way"] = "joy",                // From release 0.101
        ["joy4way"] = "joy",
        ["joy8way"] = "joy",
        ["vjoy2way"] = "joy",               // From release 0.101
        ["vdoublejoy2way"] = "doublejoy",   // From release 0.101
        ["doublejoy2way"] = "doublejoy",    // From release 0.101
    };

    private static readonly Dictionary<string, int> _waysMap = new(StringComparer.OrdinalIgnoreCase)
    {
        ["dial"] = 0,
        ["lightgun"] = 0,
        ["paddle"] = 0,
        ["stick"] = 0,
        ["trackball"] = 0,
        ["doublejoy4way"] = 4,
        ["doublejoy8way"] = 8,
        ["joy2way"] = 2,                    // From release 0.101
        ["joy4way"] = 4,
        ["joy8way"] = 8,
        ["vjoy2way"] = 2,                   // From release 0.101
        ["vdoublejoy2way"] = 2,             // From release 0.101
        ["doublejoy2way"] = 2,              // From release 0.101
    };

    private static void FixLegacyValues(MameMachine machine)
    {
        if (machine.LegacyValues.Count > 0)
        {
            var legacy = machine.LegacyValues.FirstOrDefault(x => x.ParentNode == "driver" && x.Node == "color");
            if (legacy is not null && !"good".EqualsIgnoreCase(legacy.Value) && machine.FeatureOfType(Feature.FeatureKind.palette) is null)
            {
                // good|imperfect|preliminary
                var status = Feature.FeatureStatusKind.unknown;
                var overall = Feature.FeatureOverallKind.unknown;
                if ("imperfect".EqualsIgnoreCase(legacy.Value))
                {
                    status = Feature.FeatureStatusKind.imperfect;
                    overall = Feature.FeatureOverallKind.imperfect;
                }
                else if ("preliminary".EqualsIgnoreCase(legacy.Value))
                {
                    status = Feature.FeatureStatusKind.unemulated;
                    overall = Feature.FeatureOverallKind.unemulated;
                }
                machine.Features.Add(new Feature
                {
                    Type = Feature.FeatureKind.palette,
                    Status = status,
                    Overall = overall
                });
            }

            legacy = machine.LegacyValues.FirstOrDefault(x => x.ParentNode == "input" && x.Node == "control");
            if (legacy is not null)
            {
                var control = machine.Input.Controls.FirstOrDefault();
                if (control is null)
                {
                    control = new();
                    machine.Input.Controls.Add(control);
                }
                if (_typeMap.TryGetValue(legacy.Value, out var typeMap))
                    control.Type = typeMap;
                else
                    _logger.Warn($"Tag 'input' has an invalid value for 'control' ({legacy})");
                if (_waysMap.TryGetValue(legacy.Value, out var waysMap))
                    control.Ways = waysMap;
                else
                    _logger.Warn($"Tag 'input' has an invalid value for 'control' ({legacy})");
            }

            legacy = machine.LegacyValues.FirstOrDefault(x => x.ParentNode == "input" && x.Node == "buttons");
            if (legacy is not null)
            {
                var control = machine.Input.Controls.FirstOrDefault();
                if (control is null)
                {
                    control = new();
                    machine.Input.Controls.Add(control);
                }
                if (int.TryParse(legacy.Value, out var value))
                    control.Buttons = value;
            }

            //<!ATTLIST driver sound (good|imperfect|preliminary) #REQUIRED>
            legacy = machine.LegacyValues.FirstOrDefault(x => x.ParentNode == "driver" && x.Node == "sound");
            if (legacy is not null && !"good".EqualsIgnoreCase(legacy.Value) && machine.FeatureOfType(Feature.FeatureKind.palette) is null)
            {
                // good|imperfect|preliminary
                var status = Feature.FeatureStatusKind.unknown;
                var overall = Feature.FeatureOverallKind.unknown;
                if ("imperfect".EqualsIgnoreCase(legacy.Value))
                {
                    status = Feature.FeatureStatusKind.imperfect;
                    overall = Feature.FeatureOverallKind.imperfect;
                }
                else if ("preliminary".EqualsIgnoreCase(legacy.Value))
                {
                    status = Feature.FeatureStatusKind.unemulated;
                    overall = Feature.FeatureOverallKind.unemulated;
                }
                machine.Features.Add(new Feature
                {
                    Type = Feature.FeatureKind.sound,
                    Status = status,
                    Overall = overall
                });
            }

            //<!ATTLIST driver graphic (good|imperfect|preliminary) #REQUIRED>
            legacy = machine.LegacyValues.FirstOrDefault(x => x.ParentNode == "driver" && x.Node == "graphic");
            if (legacy is not null && !"good".EqualsIgnoreCase(legacy.Value) && machine.FeatureOfType(Feature.FeatureKind.palette) is null)
            {
                // good|imperfect|preliminary
                var status = Feature.FeatureStatusKind.unknown;
                var overall = Feature.FeatureOverallKind.unknown;
                if ("imperfect".EqualsIgnoreCase(legacy.Value))
                {
                    status = Feature.FeatureStatusKind.imperfect;
                    overall = Feature.FeatureOverallKind.imperfect;
                }
                else if ("preliminary".EqualsIgnoreCase(legacy.Value))
                {
                    status = Feature.FeatureStatusKind.unemulated;
                    overall = Feature.FeatureOverallKind.unemulated;
                }
                machine.Features.Add(new Feature
                {
                    Type = Feature.FeatureKind.graphics,
                    Status = status,
                    Overall = overall
                });
            }

            //<!ATTLIST driver protection (good|imperfect|preliminary) #IMPLIED>
            legacy = machine.LegacyValues.FirstOrDefault(x => x.ParentNode == "driver" && x.Node == "protection");
            if (legacy is not null && !"good".EqualsIgnoreCase(legacy.Value) && machine.FeatureOfType(Feature.FeatureKind.palette) is null)
            {
                // good|imperfect|preliminary
                var status = Feature.FeatureStatusKind.unknown;
                var overall = Feature.FeatureOverallKind.unknown;
                if ("imperfect".EqualsIgnoreCase(legacy.Value))
                {
                    status = Feature.FeatureStatusKind.imperfect;
                    overall = Feature.FeatureOverallKind.imperfect;
                }
                else if ("preliminary".EqualsIgnoreCase(legacy.Value))
                {
                    status = Feature.FeatureStatusKind.unemulated;
                    overall = Feature.FeatureOverallKind.unemulated;
                }
                machine.Features.Add(new Feature
                {
                    Type = Feature.FeatureKind.protection,
                    Status = status,
                    Overall = overall
                });
            }
        }
    }

}

