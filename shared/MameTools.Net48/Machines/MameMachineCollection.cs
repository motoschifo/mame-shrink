#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MameTools.Net48.Machines;
using static MameTools.Machine.MameMachine;
using static MameTools.Net48.Machines.Disks.Disk;
using static MameTools.Net48.Machines.Displays.Display;
using static MameTools.Net48.Machines.Drivers.Driver;
using static MameTools.Net48.Machines.Roms.Rom;

namespace MameTools.Machine;

public class MameMachineCollection : ICollection<MameMachine>
{
    private readonly List<MameMachine> _machines = [];
    public Totals Totals { get; private set; } = new();

    public int Count => _machines.Count;

    public bool IsReadOnly => false;

    public void Add(MameMachine item)
    {
        // TODO
        // Fix in base alla release
        //if (item.ReleaseSequence > 0)
        //{
        //    // Fino alla versione 0.117u1 l'attributo "isbios" non è presente
        //    // Dalla versione 0.34 alla 0.84u6 si contano le occorrenze isbios="yes" (e le relative rom).
        //    // Dalla versione 0.69b alla 0.117u1 si contano, per ogni versione, quante ricorrenze ci sono di runnable="no" (e relative rom).
        //    //var release34 = GetSequenceFromRelease("0.34");
        //    //var release84u6 = GetSequenceFromRelease("0.84u6");
        //    if (item.ReleaseSequence >= ReleaseSequence69b && item.ReleaseSequence <= ReleaseSequence117u1)
        //    {
        //        if (!item.IsRunnable)
        //        {
        //            item.IsBios = true;
        //        }
        //    }
        //    // Dalla versione 0.69b alla 0.84u6 il nodo driver non ha l'attributo "Emulator" ma si utilizza "Status"
        //    if (item.ReleaseSequence >= ReleaseSequence69b && item.ReleaseSequence <= ReleaseSequence84u6)
        //    {
        //        item.DriverEmulation = item.DriverStatus;
        //    }
        //}

        Totals.Items.IncrementCount(item.Name);

        if (item.IsDevice)
        {
            Totals.Devices.IncrementCount(item.Name);
            Totals.DevicesRoms.IncrementCount([.. item.Roms.Select(x => x.Name)]);
        }
        if (item.IsBios)
        {
            Totals.Bioses.IncrementCount(item.Name);
            Totals.BiosRoms.IncrementCount([.. item.Roms.Select(x => x.Name)]);
        }
        if (item.IsMachine)
        {
            Totals.Machines.IncrementCount(item.Name);
            Totals.MachineRoms.IncrementCount([.. item.Roms.Select(x => x.Name)]);
        }
        // NOTA: Il Mame considera orizzontale ciò che non è verticale
        var mainDisplay = item.GetMainDisplay();
        if (mainDisplay is not null && item.IsMachine)
        {
            if (mainDisplay.Orientation == DisplayOrientationKind.vertical)
                Totals.VerticalScreen.IncrementCount(item.Name);
            else if (mainDisplay.Orientation == DisplayOrientationKind.horizontal)
                Totals.HorizontalScreen.IncrementCount(item.Name);
        }
        if (item.IsParentMachine && !item.IsBios)
            Totals.Parents.IncrementCount(item.Name);
        if (item.IsCloneMachine)
            Totals.Clones.IncrementCount(item.Name);
        if (item.RequiresDisks)
            Totals.RequiresDisks.IncrementCount(item.Name);
        if (item.UseSample)
            Totals.UseSamples.IncrementCount(item.Name);

        if (item.IsMachine)
        {
            if (item.Driver.Emulation is EmulationKind.good or EmulationKind.imperfect or EmulationKind.unknown)
                Totals.Working.IncrementCount(item.Name);
            else if (item.Driver.Emulation is EmulationKind.preliminary)
                Totals.NotWorking.IncrementCount(item.Name);
            if (item.IsMechanical)
                Totals.Mechanicals.IncrementCount(item.Name);
            else
                Totals.NotMechanicals.IncrementCount(item.Name);
            if (item.Driver.SaveState == SaveStateKind.supported)
                Totals.SaveSupported.IncrementCount(item.Name);
            else if (item.Driver.SaveState == SaveStateKind.unsupported)
                Totals.SaveUnsupported.IncrementCount(item.Name);
        }

        Totals.TotalRoms.IncrementCount([.. item.Roms.Select(x => x.Name)]);
        Totals.Disks.AddRange(item.Disks);
        Totals.TotalDisks.IncrementCount([.. item.Disks.Select(x => x.Name)]);

        Totals.GoodDumpsRoms.IncrementCount([.. item.Roms.Where(x => x.Status == RomStatusKind.good).Select(x => $"{item.Name};rom;{x.Name}")]);
        Totals.GoodDumpsRoms.IncrementCount([.. item.Disks.Where(x => x.Status == DiskStatusKind.good).Select(x => $"{item.Name};disk;{x.Name}")]);
        Totals.NoDumpsRoms.IncrementCount([.. item.Roms.Where(x => x.Status == RomStatusKind.nodump).Select(x => $"{item.Name};rom;{x.Name}")]);
        Totals.NoDumpsRoms.IncrementCount([.. item.Disks.Where(x => x.Status == DiskStatusKind.nodump).Select(x => $"{item.Name};disk;{x.Name}")]);
        Totals.BadDumpsRoms.IncrementCount([.. item.Roms.Where(x => x.Status == RomStatusKind.baddump).Select(x => $"{item.Name};rom;{x.Name}")]);
        Totals.BadDumpsRoms.IncrementCount([.. item.Disks.Where(x => x.Status == DiskStatusKind.baddump).Select(x => $"{item.Name};disk;{x.Name}")]);
        //Totals.BugsFixed.IncrementCount();  // TODO

        item.DriverName = RetrieveDriverNameFromSourceFile(item.IsDevice, item.SourceFile);
        if (item.IsMachine && !string.IsNullOrEmpty(item.SourceFile) && !Totals.DriverNames.Exists(x => x == item.SourceFile))
        {
            Totals.DriverNames.Add(item.SourceFile!);
            Totals.Drivers.IncrementCount(item.Name);
        }
        if (item.IsMachine)
        {
            if (item.Sound.Channels == 0)
                Totals.NoAudio.IncrementCount(item.Name);
            else if (item.Sound.Channels == 1)
                Totals.AudioMono.IncrementCount(item.Name);
            else if (item.Sound.Channels == 2)
                Totals.AudioStereo.IncrementCount(item.Name);
            else
                Totals.AudioMultiChannel.IncrementCount(item.Name);
            if (!item.Displays.Any())
                Totals.Screenless.IncrementCount(item.Name);
            else
            {
                if (mainDisplay is not null)
                {
                    if (mainDisplay.Type is DisplayKind.raster)
                        Totals.RasterGraphics.IncrementCount(item.Name);
                    else if (mainDisplay.Type is DisplayKind.vector)
                        Totals.VectorGraphics.IncrementCount(item.Name);
                    else if (mainDisplay.Type is DisplayKind.lcd)
                        Totals.LCDGraphics.IncrementCount(item.Name);
                    else if (mainDisplay.Type is DisplayKind.svg)
                        Totals.SVGGraphics.IncrementCount(item.Name);
                }
            }
        }
        _machines.Add(item);
    }

    public void Clear()
    {
        _machines.Clear();
        Totals = new();
    }

    public bool Contains(MameMachine item) => _machines.Contains(item);
    public void CopyTo(MameMachine[] array, int arrayIndex) => _machines.CopyTo(array, arrayIndex);
    public IEnumerator<MameMachine> GetEnumerator() => _machines.GetEnumerator();
    public bool Remove(MameMachine item)
    {
        //_machines.Remove(item);
        // ATTENZIONE
        // Per poter rimuovere un elemento occorrerebbe fare tutti i calcoli a ritroso
        // e ripristinare così i totali.
        // Per il momento evito e restituisco un errore in fase di rimozione
        throw new NotImplementedException();
    }
    IEnumerator IEnumerable.GetEnumerator() => _machines.GetEnumerator();


    public MameMachine? GetMachineByName(string? name) => string.IsNullOrEmpty(name) ? null : _machines.FirstOrDefault(x => x.Name == name);

    public MameMachine? GetParentMachineOf(string name)
    {
        var cloneMachine = GetMachineByName(name);
        if (cloneMachine is null || !cloneMachine.IsCloneMachine)
            return null;
        return _machines.FirstOrDefault(x => x.Name == cloneMachine.CloneOf);
    }

    public MameMachine? GetParentMachineOf(MameMachine machine)
    {
        if (!machine.IsCloneMachine)
            return null;
        return _machines.FirstOrDefault(x => x.Name == machine.CloneOf);
    }

    public List<MameMachine> GetCloneMachinesOf(string name)
    {
        var parentMachine = GetMachineByName(name);
        if (parentMachine is null || !parentMachine.IsParentMachine)
            return [];
        return [.. _machines.Where(x => x.CloneOf == parentMachine.Name)];
    }

    public List<MameMachine> GetCloneMachinesOf(MameMachine machine)
    {
        if (!machine.IsParentMachine)
            return [];
        return [.. _machines.Where(x => x.CloneOf == machine.Name)];
    }

    public List<MameMachine> GetMachinesWithRomOf(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return [];
        var machine = GetMachineByName(name!);
        if (machine is null)
            return [];
        return [.. _machines.Where(x => x.RomOf == name)];
    }

    public List<MameMachine> GetMachinesWithRomOf(MameMachine machine)
    {
        return [.. _machines.Where(x => x.RomOf == machine.Name)];
    }

    public List<MameMachine> GetAllMachinesWithRomOf(MameMachine machine)
    {
        var ret = new List<MameMachine>();
        foreach (var romOf in _machines.Where(x => x.RomOf == machine.Name))
        {
            ret.Add(romOf);
            ret.AddRange(InternalGetAllMachinesRomOf(romOf, 1));
        }
        return [.. ret.GroupBy(x => x.Name).Select(x => x.First())];
    }

    private List<MameMachine> InternalGetAllMachinesRomOf(MameMachine machine, int level)
    {
        if (level > 99)
            throw new Exception("Recursive search, too many levels. Please check data in XML file to avoid infinite loops");
        var ret = new List<MameMachine>();
        foreach (var romOf in _machines.Where(x => x.RomOf == machine.Name))
        {
            ret.Add(romOf);
            ret.AddRange(InternalGetAllMachinesRomOf(romOf, level + 1));
        }
        return ret;
    }

    public List<MameMachine> GetAllDependantMachinesOf(MameMachine machine)
    {
        var ret = InternalGetAllDependantMachinesOf(machine, 1);
        return [.. ret.GroupBy(x => x.Name).Select(x => x.First())];
    }

    private List<MameMachine> InternalGetAllDependantMachinesOf(MameMachine machine, int level)
    {
        if (level > 99)
            throw new Exception("Recursive search, too many levels. Please check data in XML file to avoid infinite loops");
        var ret = new List<MameMachine>();
        if (level != 1)
            ret.Add(machine);
        foreach (var deviceRef in machine.DeviceRefs)
        {
            var deviceRefMachine = GetMachineByName(deviceRef.Name);
            if (deviceRefMachine is not null)
                ret.Add(deviceRefMachine);
        }
        if (!string.IsNullOrEmpty(machine.RomOf))
        {
            var romOf = GetMachineByName(machine.RomOf);
            if (romOf is not null)
                ret.AddRange(InternalGetAllDependantMachinesOf(romOf, level + 1));
        }
        return ret;
    }

    public List<MameMachine> GetAllParentDependantMachinesOf(MameMachine machine)
    {
        var ret = InternalGetAllParentDependantMachinesOf(machine, 1);
        return [.. ret.GroupBy(x => x.Name).Select(x => x.First())];
    }

    private List<MameMachine> InternalGetAllParentDependantMachinesOf(MameMachine machine, int level)
    {
        if (level > 99)
            throw new Exception("Recursive search, too many levels. Please check data in XML file to avoid infinite loops");
        var ret = new List<MameMachine>();
        if (level != 1)
            ret.Add(machine);
        if (machine.IsDevice)
        {
            foreach (var deviceRef in _machines.Where(x => x.DeviceRefs.Any(x => x.Name == machine.Name)))
            {
                var deviceRefMachine = GetMachineByName(deviceRef.Name);
                if (deviceRefMachine is not null)
                    ret.AddRange(InternalGetAllParentDependantMachinesOf(deviceRefMachine, level + 1));
            }
        }
        foreach (var romOf in _machines.Where(x => x.RomOf == machine.Name))
        {
            ret.AddRange(InternalGetAllParentDependantMachinesOf(romOf, level + 1));
        }
        return ret;
    }

}
