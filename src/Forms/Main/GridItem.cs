#nullable enable
using System.Collections.Generic;
using System.Linq;
using MameTools.Machine;
using static MameTools.Net48.Machines.Displays.Display;
using static MameTools.Net48.Machines.Drivers.Driver;

namespace MAME_Shrink.Forms.Main;
internal class GamesGridItem
{
    public int Index { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? RomOf { get; set; }
    public string? CloneOf { get; set; }
    public string? GameYear { get; set; }
    public string? Manufacturer { get; set; }
    public string? Genre { get; set; }
    public string? Category { get; set; }
    public bool IsBios { get; set; }
    public bool IsDevice { get; set; }
    public string? Display { get; set; }
    public string? DriverStatus { get; set; }
    public int InputButtons { get; set; }
    public int InputPlayers { get; set; }
    public string? FirstEmulatorRelease { get; set; }
    public bool CanBeSelected { get; set; }
    public IReadOnlyCollection<RomFile> Files => _files.AsReadOnly();
    private readonly List<RomFile> _files = [];
    public bool HasFiles { get; private set; }
    public long TotalFilesSize { get; private set; }
    public void AddFile(RomFile file)
    {
        _files.Add(file);
        HasFiles = true;
        TotalFilesSize += file.Size;
    }
    public MameMachine? Machine { get; private set; }


    public GamesGridItem()
    {
        //
    }

    public static GamesGridItem Create(MameMachine machine)
    {
        var display = machine.MainDisplay;
        var displayStr = "Nessuno";
        if (display is not null)
        {
            if (display.Type == DisplayKind.raster)
                displayStr = "Raster";
            else if (display.Type == DisplayKind.vector)
                displayStr = "Vettoriale";
            else if (display.Type == DisplayKind.lcd)
                displayStr = "LCD";
            else if (display.Type == DisplayKind.svg)
                displayStr = "SVG";
            else
                displayStr = "Sconosciuto";
            if (display.Type != DisplayKind.unknown)
            {
                if (display.Orientation == DisplayOrientationKind.horizontal)
                    displayStr += "/Orizzontale";
                else if (display.Orientation == DisplayOrientationKind.vertical)
                    displayStr += "/Verticale";
            }
        }
        var driverStatusStr = "Sconosciuto";
        if (machine.Driver.Status == DriverStatusKind.good)
            driverStatusStr = "Funzionante";
        else if (machine.Driver.Status == DriverStatusKind.imperfect)
            driverStatusStr = "Imperfetto";
        else if (machine.Driver.Status == DriverStatusKind.preliminary)
            driverStatusStr = "Preliminare";

        var item = new GamesGridItem()
        {
            Index = 0,
            Machine = machine,
            Name = machine.Name,
            Description = string.IsNullOrEmpty(machine.Description) ? "-" : machine.Description,
            RomOf = string.IsNullOrEmpty(machine.RomOf) ? "-" : machine.RomOf,
            CloneOf = string.IsNullOrEmpty(machine.CloneOf) ? "-" : machine.CloneOf,
            GameYear = string.IsNullOrEmpty(machine.Year) ? "-" : machine.Year,
            Manufacturer = string.IsNullOrEmpty(machine.Manufacturer) ? "-" : machine.Manufacturer,
            Genre = string.IsNullOrEmpty(machine.Extra.Genre) ? "-" : machine.Extra.Genre,
            Category = string.IsNullOrEmpty(machine.Extra.Category) ? "-" : machine.Extra.Category,
            IsBios = machine.IsBios,
            IsDevice = machine.IsDevice,
            Display = displayStr,
            DriverStatus = driverStatusStr,
            InputButtons = machine.Input.Controls.FirstOrDefault()?.Buttons ?? 0,
            InputPlayers = machine.Input.Players,
            FirstEmulatorRelease = string.IsNullOrEmpty(machine.Extra.FirstEmulatorRelease) ? "-" : machine.Extra.FirstEmulatorRelease,
            CanBeSelected = false
        };
        return item;
    }
}
