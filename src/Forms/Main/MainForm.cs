#nullable enable
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArcadeDatabaseSdk.Net48.Mame;
using ArcadeDatabaseSdk.Net48.Services;
using MAME_Shrink.Common.Cache;
using MAME_Shrink.Common.Filters;
using MAME_Shrink.Extensions;
using MAME_Shrink.Forms.Main;
using MAME_Shrink.Resources;
using MAME_Shrink.Settings;
using MAME_Shrink.Utilities;
using MameTools.Machine;
using MameTools.Net48;
using MameTools.Net48.Config;
using MameTools.Net48.Exports;
using MameTools.Net48.Helpers;
using MameTools.Net48.Imports;
using NLog;
using static MAME_Shrink.Settings.UserPreferences;
using static MAME_Shrink.Settings.UserPreferences.GridColumnDefinition;
using static MameTools.Net48.Machines.Disks.Disk;
using static MameTools.Net48.Machines.Displays.Display;
using static MameTools.Net48.Machines.Drivers.Driver;
using static MameTools.Net48.Machines.Feature.Feature;

namespace MAME_Shrink.Forms;

public partial class MainForm : Form
{
    private UserPreferences _userPreferences = new();
    private readonly Mame _mame = new();
    private MameConfiguration _mameConfig = new();
    private string _applicationPath = string.Empty;
    private string _applicationName = string.Empty;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    private CancellationToken PageCancellationToken => _pageCancellationTokenSource.Token;
    private CancellationTokenSource _pageCancellationTokenSource = new();

    private readonly List<RomFile> _files = [];
    private Dictionary<int, GamesGridItem> _gridItems = [];
    private readonly List<string> _selectedItems = [];
    private enum FilterOperation
    {
        AddToSelected,
        RemoveFromSelected,
        ToggleSelected,
    }
    private FilterOperation _filterOperation;

    private enum ShowType
    {
        AllGames,
        ExistingFiles,
        Selected,
        NotSelected,
    }
    private ShowType _showType = ShowType.ExistingFiles;


    private GridColumnKind _sortColumn = GridColumnKind.Description;
    private bool _sortAsc = true;
    private string _filterPrec = string.Empty;
    private GamesGridItem? _currentSelectedItem = null;
    private readonly string _percorsoMame = string.Empty;
    private bool? _online;

    private readonly FilterMenuCollection _filters = [];
    private readonly Dictionary<FilterKind, Func<MameMachine, bool>> _menuActions = [];

    public MainForm()
    {
        InitializeComponent();
        _userPreferences = UserPreferencesManager.Get() ?? new();
        InitializeMenuActions();
        _filters.BuildMenuItems(MenuFilters.Items, MenuFiltersItem_Click, _menuActions);
        CheckMenuActions();
    }

    private void InitializeMenuActions()
    {
        _menuActions.Clear();
        _menuActions.Add(FilterKind.All, (machine) => true);
        _menuActions.Add(FilterKind.IsParentMachine, (machine) => machine.IsParentMachine);
        _menuActions.Add(FilterKind.IsCloneMachine, (machine) => machine.IsCloneMachine);
        _menuActions.Add(FilterKind.IsMamecab, (machine) => machine.Extra.IsMameCab);
        _menuActions.Add(FilterKind.IsMachine, (machine) => machine.IsMachine);
        _menuActions.Add(FilterKind.IsBios, (machine) => machine.IsBios);
        _menuActions.Add(FilterKind.IsDevice, (machine) => machine.IsDevice);
        _menuActions.Add(FilterKind.IsMechanical, (machine) => machine.IsMechanical);
        _menuActions.Add(FilterKind.AudioUnsupported, (machine) => machine.Sound.HasAudio);
        _menuActions.Add(FilterKind.AudioChannelMono, (machine) => machine.Sound.IsMono);
        _menuActions.Add(FilterKind.AudioChannelStereo, (machine) => machine.Sound.IsStereo);
        _menuActions.Add(FilterKind.AudioMultichannel, (machine) => machine.Sound.IsMultiChannel);
        _menuActions.Add(FilterKind.SoundEmulated, (machine) => machine.FeatureOfType(FeatureKind.sound) is null);
        _menuActions.Add(FilterKind.SoundImperfect, (machine) => machine.FeatureOfType(FeatureKind.sound)?.Imperfect == true);
        _menuActions.Add(FilterKind.SoundUnemulated, (machine) => machine.FeatureOfType(FeatureKind.sound)?.Unemulated == true);
        _menuActions.Add(FilterKind.DisplayTypeRaster, (machine) =>
        {
            var display = machine.GetMainDisplay();
            return display is not null && display.Type == DisplayKind.raster;
        });
        _menuActions.Add(FilterKind.DisplayTypeVector, (machine) =>
        {
            var display = machine.GetMainDisplay();
            return display is not null && display.Type == DisplayKind.vector;
        });
        _menuActions.Add(FilterKind.DisplayTypeLCD, (machine) =>
        {
            var display = machine.GetMainDisplay();
            return display is not null && display.Type == DisplayKind.lcd;
        });
        _menuActions.Add(FilterKind.DisplayTypeSVG, (machine) =>
        {
            var display = machine.GetMainDisplay();
            return display is not null && display.Type == DisplayKind.svg;
        });
        _menuActions.Add(FilterKind.DisplayTypeUnknown, (machine) =>
        {
            var display = machine.GetMainDisplay();
            return display is not null && display.Type == DisplayKind.unknown;
        });
        _menuActions.Add(FilterKind.Screenless, (machine) => machine.Screenless);
        _menuActions.Add(FilterKind.ScreensOne, (machine) => machine.Displays.Count == 1);
        _menuActions.Add(FilterKind.ScreensOneOrMore, (machine) => machine.Displays.Count >= 1);
        _menuActions.Add(FilterKind.ScreensTwo, (machine) => machine.Displays.Count == 2);
        _menuActions.Add(FilterKind.ScreensTwoOrMore, (machine) => machine.Displays.Count >= 2);
        _menuActions.Add(FilterKind.ScreensThree, (machine) => machine.Displays.Count == 3);
        _menuActions.Add(FilterKind.ScreensThreeOrMore, (machine) => machine.Displays.Count >= 3);
        _menuActions.Add(FilterKind.ScreensFour, (machine) => machine.Displays.Count == 4);
        _menuActions.Add(FilterKind.ScreensFourOrMore, (machine) => machine.Displays.Count >= 4);
        _menuActions.Add(FilterKind.ScreensFiveOrMore, (machine) => machine.Displays.Count >= 5);
        _menuActions.Add(FilterKind.HorizontalScreen, (machine) =>
        {
            var display = machine.GetMainDisplay();
            if (display is null) return false;
            return display.Orientation == DisplayOrientationKind.horizontal;
        });
        _menuActions.Add(FilterKind.VerticalScreen, (machine) =>
        {
            var display = machine.GetMainDisplay();
            if (display is null) return false;
            return display.Orientation == DisplayOrientationKind.vertical;
        });
        _menuActions.Add(FilterKind.ScreenRotated0, (machine) =>
        {
            var display = machine.GetMainDisplay();
            if (display is null) return false;
            return display.Rotate == 0;
        });
        _menuActions.Add(FilterKind.ScreenRotated90, (machine) =>
        {
            var display = machine.GetMainDisplay();
            if (display is null) return false;
            return display.Rotate == 90;
        });
        _menuActions.Add(FilterKind.ScreenRotated180, (machine) =>
        {
            var display = machine.GetMainDisplay();
            if (display is null) return false;
            return display.Rotate == 180;
        });
        _menuActions.Add(FilterKind.ScreenRotated270, (machine) =>
        {
            var display = machine.GetMainDisplay();
            if (display is null) return false;
            return display.Rotate == 270;
        });
        _menuActions.Add(FilterKind.GraphicEmulated, (machine) => machine.FeatureOfType(FeatureKind.graphics) is null);
        _menuActions.Add(FilterKind.GraphicImperfect, (machine) => machine.FeatureOfType(FeatureKind.graphics)?.Imperfect == true);
        _menuActions.Add(FilterKind.GraphicNotEmulated, (machine) => machine.FeatureOfType(FeatureKind.graphics)?.Unemulated == true);
        _menuActions.Add(FilterKind.ProtectionEmulated, (machine) => machine.FeatureOfType(FeatureKind.protection) is null);
        _menuActions.Add(FilterKind.ProtectionImperfect, (machine) => machine.FeatureOfType(FeatureKind.protection)?.Imperfect == true);
        _menuActions.Add(FilterKind.ProtectionUnemulated, (machine) => machine.FeatureOfType(FeatureKind.protection)?.Unemulated == true);
        _menuActions.Add(FilterKind.ColorEmulated, (machine) => machine.FeatureOfType(FeatureKind.palette) is null);
        _menuActions.Add(FilterKind.ColorImperfect, (machine) => machine.FeatureOfType(FeatureKind.palette)?.Imperfect == true);
        _menuActions.Add(FilterKind.ColorUnemulated, (machine) => machine.FeatureOfType(FeatureKind.palette)?.Unemulated == true);
        _menuActions.Add(FilterKind.DriverWorking, (machine) => machine.Driver.Status == DriverStatusKind.good);
        _menuActions.Add(FilterKind.DriverImperfect, (machine) => machine.Driver.Status == DriverStatusKind.imperfect);
        _menuActions.Add(FilterKind.DriverNotWorking, (machine) => machine.Driver.Status == DriverStatusKind.preliminary);
        _menuActions.Add(FilterKind.DriverUnknown, (machine) => machine.Driver.Status == DriverStatusKind.unknown);
        _menuActions.Add(FilterKind.CocktailGood, (machine) => machine.Driver.Cocktail == CocktailKind.good);
        _menuActions.Add(FilterKind.CocktailImperfect, (machine) => machine.Driver.Cocktail == CocktailKind.imperfect);
        _menuActions.Add(FilterKind.CocktailPreliminary, (machine) => machine.Driver.Cocktail == CocktailKind.preliminary);
        _menuActions.Add(FilterKind.CocktailUnknown, (machine) => machine.Driver.Cocktail == CocktailKind.unknown);
        _menuActions.Add(FilterKind.SaveStateSupported, (machine) => machine.Driver.SaveState == SaveStateKind.supported);
        _menuActions.Add(FilterKind.SaveStateUnsupported, (machine) => machine.Driver.SaveState == SaveStateKind.unsupported);
        _menuActions.Add(FilterKind.SaveStateUnknown, (machine) => machine.Driver.SaveState == SaveStateKind.unknown);
        _menuActions.Add(FilterKind.RequiresDisk, (machine) => machine.RequiresDisks);
        _menuActions.Add(FilterKind.DoNotRequiresDisk, (machine) => !machine.RequiresDisks);
        _menuActions.Add(FilterKind.DiskStatusGood, (machine) => machine.RequiresDisks && machine.Disks.Any(x => x.Status == DiskStatusKind.good));
        _menuActions.Add(FilterKind.DiskStatusBadDump, (machine) => machine.RequiresDisks && machine.Disks.Any(x => x.Status == DiskStatusKind.baddump));
        _menuActions.Add(FilterKind.DiskStatusNoDump, (machine) => machine.RequiresDisks && machine.Disks.Any(x => x.Status == DiskStatusKind.nodump));
        _menuActions.Add(FilterKind.EmulationGood, (machine) => machine.Driver.Emulation == EmulationKind.good);
        _menuActions.Add(FilterKind.EmulationImperfect, (machine) => machine.Driver.Emulation == EmulationKind.imperfect);
        _menuActions.Add(FilterKind.EmulationPreliminary, (machine) => machine.Driver.Emulation == EmulationKind.preliminary);
        _menuActions.Add(FilterKind.EmulationUnknown, (machine) => machine.Driver.Emulation == EmulationKind.unknown);
        _menuActions.Add(FilterKind.ArtworkRequired, (machine) => machine.Driver.RequiresArtwork);
        _menuActions.Add(FilterKind.ArtworkNotRequired, (machine) => !machine.Driver.RequiresArtwork);
        _menuActions.Add(FilterKind.DriverOfficial, (machine) => !machine.Driver.Unofficial);
        _menuActions.Add(FilterKind.DriverUnofficial, (machine) => machine.Driver.Unofficial);
        _menuActions.Add(FilterKind.SoundHardwareYes, (machine) => !machine.Driver.NoSoundHardware);
        _menuActions.Add(FilterKind.SoundHardwareNo, (machine) => machine.Driver.NoSoundHardware);
        _menuActions.Add(FilterKind.DriverComplete, (machine) => !machine.Driver.Incomplete);
        _menuActions.Add(FilterKind.DriverIncomplete, (machine) => machine.Driver.Incomplete);
        _menuActions.Add(FilterKind.UseSample, (machine) => machine.UseSample);
        _menuActions.Add(FilterKind.DoNotUseSample, (machine) => !machine.UseSample);
        _menuActions.Add(FilterKind.NoGenre, (machine) => string.IsNullOrEmpty(machine.Extra.Genre));
        _menuActions.Add(FilterKind.Genre, (machine) =>
        {
            return !string.IsNullOrEmpty(machine.Extra.Genre) && _selectedGenres.Contains(machine.Extra.Genre!);
        });
        _menuActions.Add(FilterKind.NoCategory, (machine) => string.IsNullOrEmpty(machine.Extra.Category));
        _menuActions.Add(FilterKind.Category, (machine) =>
        {
            return !string.IsNullOrEmpty(machine.Extra.Category) && _selectedGenres.Contains(machine.Extra.Category!);
        });
        _menuActions.Add(FilterKind.NoSerie, (machine) => string.IsNullOrEmpty(machine.Extra.Serie));
        _menuActions.Add(FilterKind.Serie, (machine) =>
        {
            return !string.IsNullOrEmpty(machine.Extra.Serie) && _selectedGenres.Contains(machine.Extra.Serie!);
        });
        _menuActions.Add(FilterKind.Release, (machine) => false);    // TODO
    }


    private void CheckMenuActions()
    {
        if (!Debugger.IsAttached)
            return;
        var errors = new List<string>();
        foreach (FilterKind filter in Enum.GetValues(typeof(FilterKind)))
        {
            if (!_menuActions.TryGetValue(filter, out var action))
                errors.Add(filter.ToString());
        }
        if (errors.Count > 0)
            Dialogs.ShowErrorDialog("Not implemented filters actions:\n\n" + string.Join("\n", errors));
    }

    private readonly HashSet<string> _selectedGenres = [];
    private readonly HashSet<string> _selectedCategories = [];
    private readonly HashSet<string> _selectedSeries = [];

    ~MainForm()
    {
        _pageCancellationTokenSource.Dispose();
    }

    private void GamesListView_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Return)
        {
            GamesListView_DoubleClick(sender, e);
            e.Handled = true;
        }
        else if (e.KeyCode == Keys.Space)
        {
            if (_currentSelectedItem is not null)
            {
                var name = GetSelectedGameName();
                if (!string.IsNullOrEmpty(name))
                {
                    ToggleSelection(name!);
                    UpdateSelectionInfo();
                }
            }
        }
    }

    public void UpdateInfo(string text = "") => Dialogs.ProgressUpdate(lblInfo, text);

    public void MouseWait() => Cursor = Cursors.WaitCursor;

    public void MouseDefault() => Cursor = Cursors.Default;

    private void GamesListView_DoubleClick(object sender, EventArgs e)
    {
        Dialogs.DoSomethingSafe(() =>
        {
            if (_currentSelectedItem is null)
                return;
            var machine = _mame.Machines.GetMachineByName(_currentSelectedItem.Name);
            if (machine is null)
                return;
            var proc = new Process();
            proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(_userPreferences.Mame.ExecutableFilePath);
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = _userPreferences.Mame.ExecutableFilePath;
            proc.StartInfo.Arguments = machine.Name;
            proc.Start();
        });
    }


    //private void AddToSelectedItems(string name)
    //{
    //    var item = _gridItems.Values.FirstOrDefault(x => x.Name == name);
    //    if (item is null || !item.CanBeSelected || !item.HasFiles || _selectedItems.Contains(item.Name))
    //        return;
    //    _selectedItems.Add(item.Name);
    //}

    //private void RemoveFromSelectedItems(string name)
    //{
    //    var item = _gridItems.Values.FirstOrDefault(x => x.Name == name);
    //    if (item is null || !item.CanBeSelected || !item.HasFiles || !_selectedItems.Contains(item.Name))
    //        return;
    //    _selectedItems.Remove(item.Name);
    //}

    public void SelectGame(string name)
    {
        if (_selectedItems.Contains(name))
            return;
        var machine = _mame.Machines.GetMachineByName(name);
        if (machine is null)
            return;
        var item = _gridItems.Values.FirstOrDefault(x => x.Name == name);
        if (!item.CanBeSelected || !item.HasFiles)
            return;
        _selectedItems.Add(item.Name);

        //if (_config.Mame.MameSet == MameSection.MameSetKind.Auto)
        //{
        //    // Parent and clone are linked by XML data
        //    var requiredMachines = _mame.Machines.GetAllDependantMachinesOf(machine);
        //    foreach (var reqMachine in requiredMachines)
        //    {
        //        AddToSelectedItems(reqMachine.Name);
        //    }
        //}
        //else if (_config.Mame.MameSet == MameSection.MameSetKind.Splitted)
        //{
        //    // Parent and clone are linked
        //    if (machine.IsClone)
        //    {
        //        var parent = _mame.Machines.GetParentMachineOf(machine.Name);
        //        if (parent is not null)
        //            AddToSelectedItems(parent.Name);
        //    }
        //}
        //else if (_config.Mame.MameSet == MameSection.MameSetKind.Merged)
        //{
        //    // Parent and clone are stored together
        //    if (machine.IsClone)
        //    {
        //        var parent = _mame.Machines.GetParentMachineOf(machine.Name);
        //        if (parent is not null)
        //        {
        //            AddToSelectedItems(parent.Name);
        //            foreach (var clone in _mame.Machines.GetCloneMachinesOf(parent.Name))
        //            {
        //                AddToSelectedItems(clone.Name);
        //            }
        //        }
        //    }
        //    else if (machine.IsParent)
        //    {
        //        foreach (var clone in _mame.Machines.GetCloneMachinesOf(machine.Name))
        //        {
        //            AddToSelectedItems(clone.Name);
        //        }
        //    }
        //}
        //else if (_config.Mame.MameSet == MameSection.MameSetKind.NonMerged)
        //{
        //    // Parent and clone are in diffetent files
        //}
        GamesListView.Invalidate();
    }

    public void DeselectGame(string name)
    {
        if (!_selectedItems.Contains(name))
            return;
        var machine = _mame.Machines.GetMachineByName(name);
        if (machine is null)
            return;
        var item = _gridItems.Values.FirstOrDefault(x => x.Name == name);
        if (!item.CanBeSelected || !item.HasFiles)
            return;
        _selectedItems.Remove(item.Name);

        //if (_config.Mame.MameSet == MameSection.MameSetKind.Auto)
        //{
        //    // Parent and clone are linked by XML data
        //    var requiredMachines = _mame.Machines.GetAllParentDependantMachinesOf(machine);
        //    foreach (var reqMachine in requiredMachines)
        //    {
        //        RemoveFromSelectedItems(reqMachine.Name);
        //    }
        //    //foreach (var romOf in _mame.Machines.GetAllMachinesWithRomOf(machine))
        //    //{
        //    //    RemoveFromSelectedItems(romOf.Name);
        //    //}
        //}
        //else if (_config.Mame.MameSet == MameSection.MameSetKind.Splitted)
        //{
        //    // Parent and clone are linked
        //    if (machine.IsParent)
        //    {
        //        foreach (var clone in _mame.Machines.GetCloneMachinesOf(machine.Name))
        //        {
        //            RemoveFromSelectedItems(clone.Name);
        //        }
        //    }
        //}
        //else if (_config.Mame.MameSet == MameSection.MameSetKind.Merged)
        //{
        //    // Parent and clone are stored together
        //    if (machine.IsClone)
        //    {
        //        var parent = _mame.Machines.GetParentMachineOf(machine.Name);
        //        if (parent is not null)
        //        {
        //            RemoveFromSelectedItems(parent.Name);
        //            foreach (var clone in _mame.Machines.GetCloneMachinesOf(parent.Name))
        //            {
        //                RemoveFromSelectedItems(clone.Name);
        //            }
        //        }
        //    }
        //    else if (machine.IsParent)
        //    {
        //        foreach (var clone in _mame.Machines.GetCloneMachinesOf(machine.Name))
        //        {
        //            RemoveFromSelectedItems(clone.Name);
        //        }
        //    }
        //}
        //else if (_config.Mame.MameSet == MameSection.MameSetKind.NonMerged)
        //{
        //    // Parent and clone are in diffetent files
        //}
        GamesListView.Invalidate();
    }

    public void UpdateSelectionInfo()
    {
        UpdateInfo("...");
        List<string> parts = [];
        var text = string.Empty;
        if (_selectedItems.Count > 0)
        {
            var totalSize = _gridItems.Values.Where(x => _selectedItems.Contains(x.Name)).Sum(x => x.TotalFilesSize);
            parts.Add(string.Format(Strings.SelectedGames, _selectedItems.Count.ToFormattedString()));
            parts.Add(string.Format(Strings.DiskSpace, totalSize.ToFileSizeString()));
        }
        else
        {
            parts.Add(Strings.NoRomSelected);
        }
        parts.Add(string.Format(Strings.TotalGames, _mame.Machines.Count.ToFormattedString()));
        StartClean.Visible = _selectedItems.Count > 0;
        ValidateRomset.Visible = StartClean.Visible;
        UpdateInfo(string.Join(", ", parts));
    }

    private void GamesListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
    {
        if (e.ItemIndex >= _gridItems.Count)
        {
            e.Item = new();
            return;
        }

        var g = _gridItems[e.ItemIndex];
        if (g is null)
        {
            e.Item = new();
            return;
        }

        var li = new ListViewItem
        {
            Name = g.Name,
            Text = string.Empty,
            Tag = g.Name
        };

        foreach (var column in _userPreferences.Grid.Columns.Where(x => x.Visible).OrderBy(x => x.Position))
        {
            if (column.Kind is GridColumnKind.Id) continue;
            var text = column.Kind switch
            {
                GridColumnKind.Id => string.Empty,
                GridColumnKind.Romset => g.Name,
                GridColumnKind.Description => g.Description,
                GridColumnKind.GameYear => g.GameYear,
                GridColumnKind.Manufacturer => g.Manufacturer,
                GridColumnKind.CloneOf => g.CloneOf,
                GridColumnKind.DriverStatus => g.DriverStatus,
                GridColumnKind.Genre => g.Genre,
                GridColumnKind.Category => g.Category,
                GridColumnKind.Release => g.FirstEmulatorRelease,
                GridColumnKind.Players => g.InputPlayers > 0 ? g.InputPlayers.ToString("0") : "-",
                GridColumnKind.Buttons => g.InputButtons > 0 ? g.InputButtons.ToString("0") : "-",
                GridColumnKind.Display => g.Display,
                GridColumnKind.Size => g.HasFiles ? g.TotalFilesSize.ToFileSizeString() : "-",
                _ => "-"
            };
            _ = li.SubItems.Add(text);
        }

        // Items selectable are black, otherwise gray
        li.ForeColor = _files.Exists(x => x.Name == g.Name) ? Color.Black : Color.Gray;
        e.Item = li;
    }

    private void GamesListView_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        e.DrawDefault = true;
        var romset = e.Item.Tag.ToString();
        var selected = _selectedItems.Contains(romset);
        var item = _gridItems[e.ItemIndex];
        if (item.CanBeSelected)
        {
            CheckBoxRenderer.DrawCheckBox(e.Graphics,
                        new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                        selected ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                        System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
        }
    }

    private void GamesListView_MouseClick(object sender, MouseEventArgs e)
    {
        if (sender is not ListView lv)
            return;
        var lvi = lv.GetItemAt(e.X, e.Y);
        if (lvi is not null)
        {
            if (e.X < (lvi.Bounds.Left + 24))
            {
                var romset = lvi.Tag.ToString();
                ToggleSelection(romset);
                UpdateSelectionInfo();
            }
        }
    }

    private void GamesListView_ColumnClick(object sender, ColumnClickEventArgs e)
    {
        if (e.Column == 0)
        {
            if (!bool.TryParse(GamesListView.Columns[e.Column].Tag?.ToString(), out var value))
                return;
            GamesListView.Columns[e.Column].Tag = !value;
            _selectedItems.Clear();
            if (value)
                _selectedItems.AddRange(_gridItems.Values.Select(x => x.Name));
            GamesListView.Invalidate();
        }
        else
        {

            if (e.Column == 0)
                return;
            var ch = GamesListView.Columns[e.Column];
            if (Enum.TryParse<GridColumnKind>(ch.Tag.ToString(), out var newColumn))
            {
                _sortAsc = newColumn != _sortColumn || !_sortAsc;
                _sortColumn = newColumn;
            }
            else
            {
                _sortAsc = true;
                _sortColumn = GridColumnKind.Description;
            }
            UpdateGridItems();
        }
    }

    public void UpdateGridItems()
    {
        ToolbarMenuGrid.Enabled = false;
        try
        {
            GamesListView.BeginUpdate();
            _filterPrec = GridTextFilter.Text;
            var s = _filterPrec.Trim();
            List<MameMachine> list;
            if (string.IsNullOrEmpty(s))
            {
                list = [.. _mame.Machines];
            }
            else
            {
                list = [.. _mame.Machines.Where(x =>
                    x.Description?.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    x.Name.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0)];
            }

            var tmpGridItems = new List<GamesGridItem>();
            foreach (var item in list)
            {
                if (_showType is ShowType.Selected && !_selectedItems.Contains(item.Name))
                    continue;
                else if (_showType is ShowType.NotSelected && _selectedItems.Contains(item.Name))
                    continue;
                var gridItem = GamesGridItem.Create(item);
                var file = _files.FirstOrDefault(x => x.Name == item.Name);
                if (file is not null)
                {
                    gridItem.AddFile(file);
                    gridItem.CanBeSelected = true;
                }
                if (_showType == ShowType.ExistingFiles && !gridItem.HasFiles)
                    continue;
                tmpGridItems.Add(gridItem);
            }
            Func<GamesGridItem, object?> orderByPredicate = _sortColumn switch
            {
                GridColumnKind.Id => item => item.Description,
                GridColumnKind.Romset => item => item.Name,
                GridColumnKind.Description => item => item.Description,
                GridColumnKind.GameYear => item => item.GameYear,
                GridColumnKind.Manufacturer => item => item.Manufacturer,
                GridColumnKind.CloneOf => item => item.CloneOf,
                GridColumnKind.DriverStatus => item => item.DriverStatus,
                GridColumnKind.Genre => item => item.Genre,
                GridColumnKind.Category => item => item.Category,
                GridColumnKind.Release => item => item.FirstEmulatorRelease,
                GridColumnKind.Players => item => item.InputPlayers,
                GridColumnKind.Buttons => item => item.InputButtons,
                GridColumnKind.Display => item => item.Display,
                GridColumnKind.Size => item => item.TotalFilesSize,
                _ => item => item.Description
            };
            var orderedList = _sortAsc
                ? tmpGridItems.OrderBy(orderByPredicate)
                : tmpGridItems.OrderByDescending(orderByPredicate);

            _gridItems = orderedList
                .Select((item, index) =>
                {
                    item.Index = index;
                    return new { index, item };
                })
                .ToDictionary(x => x.index, x => x.item);

            GamesListView.VirtualListSize = _gridItems.Count();
        }
        catch (Exception ex)
        {
            // Ignore
            _logger.Error(ex, $"Failed to update grid items: {ex.Message}");
        }
        finally
        {
            GamesListView.EndUpdate();
            GamesListView.Invalidate();
            ToolbarMenuGrid.Enabled = true;
        }
    }

    private void GamesListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        // TODO
        e.DrawDefault = true;
    }

    public void EnableControls(bool enable)
    {
        GridTextFilter.Enabled = enable;
        GamesListView.Enabled = enable;
    }

    private void GridTextFilter_TextChanged(object sender, EventArgs e)
    {
        GridTextFilterTimer.Stop();
        GridTextFilterTimer.Enabled = true;
        GridTextFilterTimer.Interval = 500;
        GridTextFilterTimer.Start();
    }

    private void GridTextFilterTimer_Tick(object sender, EventArgs e)
    {
        GridTextFilterTimer.Stop();
        if (GridTextFilter.Text != _filterPrec)
            UpdateGridItems();
    }

    private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        Dialogs.DoSomethingSafe(() =>
        {
            try
            {
                var changed = false;
                _userPreferences.CleanOptions.ValidateBeforeCleaning = ValidateRomset.Checked;
                foreach (ColumnHeader ch in GamesListView.Columns)
                {
                    var key = ParseGridColumn(ch.Tag?.ToString());
                    var column = _userPreferences.Grid.Columns.FirstOrDefault(x => x.Kind == key);
                    if (column is null)
                        continue;
                    column.Width = ch.Width;
                    changed = true;
                }
                if (changed)
                    UserPreferencesManager.Set(_userPreferences);
            }
            catch (Exception ex)
            {
                // Ignore
                _logger.Error(ex, $"Failed to store user settings: {ex.Message}");
            }
            UserPreferencesManager.Set(_userPreferences);
        });
    }

    private void AddColumnsToGrid()
    {
        GamesListView.Columns.Clear();
        foreach (var column in _userPreferences.Grid.Columns.Where(x => x.Visible).OrderBy(x => x.Position))
        {
            ColumnHeader ch = GamesListView.Columns.Add(
                key: column.Kind.ToString(),
                text: column.Title,
                width: column.Width,
                textAlign: column.RightAlignment ? HorizontalAlignment.Right : HorizontalAlignment.Left,
                imageKey: null
            );
            ch.Tag = column.Kind.ToString();
        }
    }

    private void FrmMain_Load(object sender, EventArgs e)
    {
        _applicationPath = ApplicationHelper.GetApplicationPath(Assembly.GetEntryAssembly());
        _applicationName = ApplicationHelper.GetApplicationTitle(Assembly.GetExecutingAssembly());
        Text = _applicationName;
        ShowUpdatedSetting();

        // Columns selection menu
        MenuColumnItems.Items.Clear();
        foreach (GridColumnKind key in Enum.GetValues(typeof(GridColumnKind)))
        {
            if (key is GridColumnKind.Id) continue;
            var column = _userPreferences.Grid.Columns.FirstOrDefault(x => x.Kind == key);
            if (column is null)
                continue;
            var item = new ToolStripMenuItem(column.Title)
            {
                Tag = column.Kind,
                Width = column.Width,
                Checked = column.Visible || key is GridColumnKind.Romset,
                Enabled = key is not GridColumnKind.Romset,
                CheckOnClick = true,
            };
            item.Click += (s, e) =>
            {
                var menuItem = (ToolStripMenuItem)s;
                var key = GridColumnDefinition.ParseGridColumn(menuItem.Tag?.ToString());
                if (key == GridColumnKind.Unknown)
                    return;
                var column = _userPreferences.Grid.Columns.FirstOrDefault(x => x.Kind == key);
                if (column is null)
                    return;
                column.Visible = menuItem.Checked;
                AddColumnsToGrid();
            };
            MenuColumnItems.Items.Add(item);
        }

        ValidateRomset.Checked = _userPreferences.CleanOptions.ValidateBeforeCleaning;

        // Cache
        _mameCache.Initialize(_applicationName, Path.Combine(_applicationPath, "local-cache", "mame-cache.json"));
        _snapshotsCache.SetFilePath(Path.Combine(_applicationPath, "local-cache", "snapshots"));

        EnableControls(false);
    }

    private void ShowUpdatedSetting()
    {
        LabelManueExe.Text = _userPreferences.Mame.ExecutableFilePath;
        LabelGamelistXml.Text = _userPreferences.Mame.GameListFilePath;
        LabelRomsPath.Text = _userPreferences.Mame.AutoDetectRomPaths ? Strings.ByMameConfiguration : string.Join(";", _userPreferences.Mame.RomPaths);
    }

    private void ChangeOptions_Click(object sender, EventArgs e)
    {
        Dialogs.DoSomethingSafe(() =>
        {
            using var form = new OptionsForm();
            var result = form.ShowDialog();
            var newPreferences = UserPreferencesManager.Get();
            if (newPreferences is null)
            {
                Dialogs.ShowErrorDialog(Strings.UserPreferencesLoadingFailure);
                _userPreferences = new();
            }
            else
            {
                _userPreferences = newPreferences;
            }
            _online = null;     // Retry connection, if enabled
            ShowUpdatedSetting();
        });
    }

    private async void LoadGames_Click(object sender, EventArgs e)
    {
        MouseWait();
        EnableControls(false);

        try
        {
            ResetPageCancellationToken();
            LoadGames.Hide();
            CancelCurrentProcess.Show();
            CancelCurrentProcess.Enabled = true;
            ChangeOptions.Enabled = false;

            var fileXml = _userPreferences.Mame.GameListFilePath;
            if (_userPreferences.Mame.GenerateGameListFromExecutable && !string.IsNullOrWhiteSpace(_userPreferences.Mame.ExecutableFilePath))
            {
                var name = Path.GetFileNameWithoutExtension(_userPreferences.Mame.ExecutableFilePath);
                var path = Path.GetDirectoryName(_userPreferences.Mame.ExecutableFilePath);
                fileXml = Path.Combine(path, $"{name}-gamelist.xml");
                var errors = string.Empty;
                if (!File.Exists(fileXml) || _userPreferences.Mame.ForceGameListGeneration)
                {
                    // Gamelist creation
                    errors = await FileFactory.GenerateGamelistXml(
                        executableFilePath: _userPreferences.Mame.ExecutableFilePath!,
                        outputFile: fileXml,
                        cancellationToken: PageCancellationToken,
                        prefix: null,
                        progressUpdate: (text) => Dialogs.ProgressUpdate(lblInfo, text)
                    );
                    PageCancellationToken.ThrowIfCancellationRequested();
                }
                if (!File.Exists(fileXml) || !string.IsNullOrEmpty(errors))
                {
                    throw new Exception(
                        string.Format(Strings.CouldNotReadFile, fileXml) +
                        "\n\n" +
                        errors +
                        "\n\n" +
                        Strings.TryGamelistCreationCommandMessage +
                        "\n" +
                        $"{_userPreferences.Mame.ExecutableFilePath} -listxml > {fileXml}"
                    );
                }
                if (_userPreferences.Mame.AutoDetectRomPaths)
                {
                    _mameConfig = await Mame.LoadMameConfiguration(_userPreferences.Mame.ExecutableFilePath!);
                    _userPreferences.Mame.RomPaths = _mameConfig.RomPath;
                }
            }
            PageCancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(fileXml))
                throw new Exception(Strings.MissingXmlFile);

            await ImportMachines.LoadFromFile(
                mame: _mame,
                filename: fileXml!,
                cancellationToken: PageCancellationToken,
                loadHeaderOnly: false,
                progressUpdate: (text) => Dialogs.ProgressUpdate(lblInfo, text)
            );

            if (string.IsNullOrEmpty(_userPreferences.Mame.RomPaths))
                _userPreferences.Mame.RomPaths = "roms";
            LoadRomsFiles(
                progressUpdate: (text) => Dialogs.ProgressUpdate(lblInfo, text)
            );
            await LoadFromArcadeDatabaseOrCache(
                progressUpdate: (text) => Dialogs.ProgressUpdate(lblInfo, text)
            );

            UpdateInfo(Strings.AddingDataToGrid);
            GamesListView.BeginUpdate();

            // Grid setup
            _selectedItems.Clear();
            GamesListView.Items.Clear();
            GamesListView.FullRowSelect = true;
            GamesListView.CheckBoxes = true;
            GamesListView.OwnerDraw = true;
            GamesListView.GridLines = false;
            GamesListView.MultiSelect = false;
            GamesListView.View = View.Details;
            _sortColumn = GridColumnKind.Description;
            _sortAsc = true;
            _filterPrec = GridTextFilter.Text;
            GamesListView.VirtualMode = true;
            GamesListView.VirtualListSize = _gridItems.Count();

            UpdateInfo(Strings.GridUpdate);
            AddColumnsToGrid();
            UpdateGridItems();
            UpdateInfo("Aggiornamento filtri...");
            var machines = _gridItems.Select(x => x.Value).Where(x => x.CanBeSelected && x.Machine is not null).Select(x => x.Machine).ToDictionary(x => x!.Name, x => x);
            _filters.UpdateFilterMenuCounters(machines!);
            UpdateSelectionInfo();
        }
        catch (Exception ex)
        {
            Dialogs.ShowErrorDialog(ex);
        }
        finally
        {
            EnableControls(true);
            MouseDefault();
            LoadGames.Show();
            CancelCurrentProcess.Hide();
            ChangeOptions.Enabled = true;
            GamesListView.EndUpdate();
        }
    }

    private void ResetPageCancellationToken()
    {
        _pageCancellationTokenSource.Dispose();
        _pageCancellationTokenSource = new();
        Application.DoEvents();
    }

    private void CancelCurrentProcess_Click(object sender, EventArgs e)
    {
        CancelCurrentProcess.Enabled = false;
        _pageCancellationTokenSource.Cancel();
    }

    private void LoadRomsFiles(Action<string> progressUpdate)
    {
        Dialogs.DoSomethingSafe(() =>
        {
            progressUpdate(Strings.ReadingRoms);
            _files.Clear();
            var exePath = (string.IsNullOrEmpty(_userPreferences.Mame.ExecutableFilePath) || !File.Exists(_userPreferences.Mame.ExecutableFilePath)) ? string.Empty : Path.GetDirectoryName(_userPreferences.Mame.ExecutableFilePath);
            foreach (var path in _userPreferences.Mame.RomPathList)
            {
                progressUpdate($"{Strings.Reading} {path}");
                foreach (var ext in "zip,7z".Split(','))
                {
                    var i = 0;
                    foreach (var file in Directory.GetFiles(Path.Combine(exePath, path), $"*.{ext}", SearchOption.TopDirectoryOnly))
                    {
                        i++;
                        if (i % 100 == 0)
                            progressUpdate(string.Format(Strings.ReadingRomFolderFiles, i));
                        var romset = file.Substring(file.LastIndexOf(@"\") + 1);
                        _files.Add(new RomFile()
                        {
                            Name = romset.Substring(0, romset.Length - ext.Length - 1),
                            FilePath = file,
                            Size = new FileInfo(file).Length
                        });
                    }
                }
            }
        });
    }

    private void ToggleSelection(string name)
    {
        Dialogs.DoSomethingSafe(() =>
        {
            if (_selectedItems.Contains(name))
                DeselectGame(name);
            else
                SelectGame(name);
        });
    }


    private void ApplyFilters(Func<MameMachine, bool> func)
    {
        Dialogs.DoSomethingSafe(() =>
        {
            var changed = false;
            foreach (var item in _gridItems.Values.Where(x => x.HasFiles))
            {
                var machine = _mame.Machines.GetMachineByName(item.Name);
                if (machine is null) continue;
                if (!func.Invoke(machine)) continue;

                if (_filterOperation == FilterOperation.AddToSelected)
                {
                    if (_selectedItems.Contains(machine.Name))
                        continue;
                    _selectedItems.Add(machine.Name);
                    //SelectGame(machine.Name);
                    changed = true;
                }
                else if (_filterOperation == FilterOperation.RemoveFromSelected)
                {
                    if (!_selectedItems.Contains(machine.Name))
                        continue;
                    _selectedItems.Remove(machine.Name);
                    //DeselectGame(machine.Name);
                    changed = true;
                }
                else if (_filterOperation == FilterOperation.ToggleSelected)
                {
                    if (_selectedItems.Contains(machine.Name))
                    {
                        _selectedItems.Remove(machine.Name);
                        //DeselectGame(machine.Name);
                    }
                    else
                    {
                        _selectedItems.Add(machine.Name);
                        //SelectGame(machine.Name);
                    }
                    changed = true;
                }
            }

            if (changed)
            {
                UpdateGridItems();
                UpdateSelectionInfo();
            }
        });
    }

    private void MenuAddToSelectedGames_Click(object sender, EventArgs e)
    {
        _filterOperation = FilterOperation.AddToSelected;
        ShowMenu(MenuFilters, MenuAddToSelectedGames);
    }

    private void MenuRemoveFromSelectedGames_Click(object sender, EventArgs e)
    {
        _filterOperation = FilterOperation.RemoveFromSelected;
        ShowMenu(MenuFilters, MenuRemoveFromSelectedGames);
    }

    private void MenuToggleSelectedGames_Click(object sender, EventArgs e)
    {
        _filterOperation = FilterOperation.ToggleSelected;
        ShowMenu(MenuFilters, MenuToggleSelectedGames);
    }

    private void MenuColumns_Click(object sender, EventArgs e)
    {
        ShowMenu(MenuColumnItems, MenuColumns);
    }

    private void ShowMenu(ContextMenuStrip menu, ToolStripMenuItem parentMenu)
    {
        if (parentMenu is not ToolStripMenuItem menuItem)
            return;
        if (menuItem.Owner is ToolStripDropDown dropDown)
        {
            var menuPosition = dropDown.PointToScreen(Point.Empty);
            var itemIndex = menuItem.Owner.Items.IndexOf(menuItem);
            var yOffset = 0;
            for (var i = 0; i < itemIndex; i++)
            {
                yOffset += menuItem.Owner.Items[i].GetPreferredSize(Size.Empty).Height;
            }

            menu.Show(menuPosition.X, menuPosition.Y + yOffset + menuItem.Height);
            return;
        }
        else if (menuItem.Owner is MenuStrip menuStrip)
        {
            var menuPosition = menuStrip.PointToScreen(menuItem.Bounds.Location);
            menu.Show(menuPosition.X, menuPosition.Y + menuItem.Bounds.Height);
        }
    }

    private void MenuShowType_Click(object sender, EventArgs e)
    {
        if (sender is not ToolStripMenuItem menuItem || string.IsNullOrEmpty(menuItem.Tag?.ToString()))
            return;
        if (!Enum.TryParse(menuItem.Tag?.ToString(), out ShowType showType))
            return;
        if (_showType == showType)
            return;
        foreach (ToolStripMenuItem item in MenuShow.DropDownItems)
        {
            item.Checked = item.Tag == menuItem.Tag;
        }
        _showType = showType;
        UpdateGridItems();
    }

    private void StartClean_Click(object sender, EventArgs e)
    {
        try
        {
            StartClean.Enabled = false;
            ValidateRomset.Enabled = StartClean.Enabled;
            if (_selectedItems.Count == 0)
                throw new Exception(Strings.NoGameSelected);

            if (ValidateRomset.Checked)
            {
                if (!ValidateSelectedItems())
                    return;
            }

            if (_userPreferences.CleanOptions.CleanMethod == CleanMethodKind.DeleteFiles)
            {
                var dr = MessageBox.Show(
                    text: string.Format(Strings.GamesRemovalConfirmationMessage, _selectedItems.Count.ToFormattedString()),
                    caption: Strings.CleanConfirmation,
                    buttons: MessageBoxButtons.YesNo,
                    icon: MessageBoxIcon.Warning,
                    defaultButton: MessageBoxDefaultButton.Button2
                );

                if (dr is not DialogResult.Yes)
                    return;

                dr = MessageBox.Show(
                    text: string.Format(Strings.GamesRemoval2ndConfirmationMessage, _selectedItems.Count.ToFormattedString()),
                    caption: Strings.CleanConfirmation,
                    buttons: MessageBoxButtons.YesNo,
                    icon: MessageBoxIcon.Error,
                    defaultButton: MessageBoxDefaultButton.Button2
                );
                if (dr is not DialogResult.Yes)
                    return;
                MouseWait();
                var mamePath = Path.GetDirectoryName(_userPreferences.Mame.ExecutableFilePath);
                foreach (var romset in _selectedItems)
                {
                    var machine = _mame.Machines.GetMachineByName(romset);
                    if (machine is null)
                        continue;
                    UpdateInfo(string.Format(Strings.RomsetCleaning, machine.Name, machine.Description));
                    MameFiles.DeleteMameFiles(mamePath, machine, _mameConfig, _userPreferences.Mame.RomPaths, false);
                }
            }
            else if (_userPreferences.CleanOptions.CleanMethod == CleanMethodKind.MoveFilesToRecycleBin)
            {
                var destinationPath = Path.Combine(Path.GetDirectoryName(_userPreferences.Mame.ExecutableFilePath), $"0-removed {DateTime.Now:yyyy-MM-dd HH-mm-ss}");
                var dr = MessageBox.Show(
                    text: string.Format(Strings.GamesRemovalTrashConfirmationMessage, _selectedItems.Count.ToFormattedString()),
                    caption: Strings.CleanConfirmation,
                    buttons: MessageBoxButtons.YesNo,
                    icon: MessageBoxIcon.Warning,
                    defaultButton: MessageBoxDefaultButton.Button2
                );
                if (dr is not DialogResult.Yes)
                    return;
                MouseWait();
                var mamePath = Path.GetDirectoryName(_userPreferences.Mame.ExecutableFilePath);
                foreach (var romset in _selectedItems)
                {
                    var machine = _mame.Machines.GetMachineByName(romset);
                    if (machine is null)
                        continue;
                    UpdateInfo(string.Format(Strings.RomsetCleaning, machine.Name, machine.Description));
                    MameFiles.DeleteMameFiles(mamePath, machine, _mameConfig, _userPreferences.Mame.RomPaths, true);
                }
            }
            else if (_userPreferences.CleanOptions.CleanMethod == CleanMethodKind.MoveFilesToFolder)
            {
                var destinationPath = Path.Combine(_userPreferences.CleanOptions.RemovedFilesFolder, $"{DateTime.Now:yyyy-MM-dd HH.mm.ss}");
                var dr = MessageBox.Show(
                    text: string.Format(Strings.GamesRemovalMoveConfirmationMessage, _selectedItems.Count.ToFormattedString(), destinationPath),
                    caption: Strings.CleanConfirmation,
                    buttons: MessageBoxButtons.YesNo,
                    icon: MessageBoxIcon.Warning,
                    defaultButton: MessageBoxDefaultButton.Button2
                );
                if (dr is not DialogResult.Yes)
                    return;
                MouseWait();
                foreach (var romset in _selectedItems)
                {
                    var machine = _mame.Machines.GetMachineByName(romset);
                    if (machine is null)
                        continue;
                    UpdateInfo(string.Format(Strings.RomsetCleaning, machine.Name, machine.Description));
                    MoveMameFiles(machine, destinationPath);
                }
            }
            else
            {
                throw new NotImplementedException(Strings.ProcessingTypeNotSupported);
            }

            LoadRomsFiles(
                progressUpdate: (text) => Dialogs.ProgressUpdate(lblInfo, text)
            );
            UpdateGridItems();
            Dialogs.ShowInfoDialog(Strings.OperationCompleted);
        }
        catch (Exception ex)
        {
            Dialogs.ShowErrorDialog(ex);
        }
        finally
        {
            MouseDefault();
            StartClean.Enabled = true;
            ValidateRomset.Enabled = StartClean.Enabled;
            UpdateSelectionInfo();
        }
    }

    private readonly WarningRomsetCollection _warningRoms = [];
    private bool ValidateSelectedItems()
    {
        try
        {
            /*
             * Verifiche romset:
             * - tutte le rom selezionate che sono richieste da rom esistenti
             * - opz. tutte le rom non selezionate che non sono più richieste da rom esistenti
             */

            //var selectedItemsHashSet = _selectedItems.ToHashSet();
            _warningRoms.Clear();
            UpdateInfo(Strings.CheckingRomset);
            if (_userPreferences.Mame.MameSetType == MameSection.MameSetKind.Auto)
            {
                // Parent and clone are linked by XML data
                var index = 0;
                var total = _selectedItems.Count;
                foreach (var romset in _selectedItems.OrderBy(x => x))
                {
                    index++;
                    var machine = _mame.Machines.GetMachineByName(romset);
                    if (machine is null)
                        continue;
                    UpdateInfo(string.Format(Strings.Checking, index, total, machine.Name, machine.Description));

                    //var requiredMachines = _mame.Machines.GetAllDependantMachinesOf(machine);
                    //foreach (var reqMachine in requiredMachines)
                    //{
                    //    AddOptionalRomsetToWarningList(machine.Name, reqMachine.Name);
                    //}

                    //var requiredMachines = _mame.Machines.GetAllDependantMachinesOf(machine);
                    var requiredMachines = _mame.Machines.GetAllParentDependantMachinesOf(machine);
                    foreach (var reqMachine in requiredMachines)
                    {
                        AddMissingRomsetToWarningList(machine.Name, reqMachine.Name);
                    }

                    var romOfs = _mame.Machines.GetAllMachinesWithRomOf(machine);
                    foreach (var romOf in romOfs)
                    {
                        AddMissingRomsetToWarningList(machine.Name, romOf.Name);
                    }
                }
            }
            else if (_userPreferences.Mame.MameSetType == MameSection.MameSetKind.Splitted)
            {
                // Parent and clone are linked
                //    if (machine.IsClone)
                //    {
                //        var parent = _mame.Machines.GetParentMachineOf(machine.Name);
                //        if (parent is not null)
                //            AddToSelectedItems(parent.Name);
                //    }
            }
            else if (_userPreferences.Mame.MameSetType == MameSection.MameSetKind.Merged)
            {
                // Parent and clone are stored together
                //    if (machine.IsClone)
                //    {
                //        var parent = _mame.Machines.GetParentMachineOf(machine.Name);
                //        if (parent is not null)
                //        {
                //            AddToSelectedItems(parent.Name);
                //            foreach (var clone in _mame.Machines.GetCloneMachinesOf(parent.Name))
                //            {
                //                AddToSelectedItems(clone.Name);
                //            }
                //        }
                //    }
                //    else if (machine.IsParent)
                //    {
                //        foreach (var clone in _mame.Machines.GetCloneMachinesOf(machine.Name))
                //        {
                //            AddToSelectedItems(clone.Name);
                //        }
                //    }
            }
            else if (_userPreferences.Mame.MameSetType == MameSection.MameSetKind.NonMerged)
            {
                // Parent and clone are in diffetent files
            }
            if (_warningRoms.Count > 0)
            {
                var sb = new StringBuilder();
                foreach (var wr in _warningRoms)
                {
                    if (wr.MissingRomsets.Any())
                    {
                        sb
                            .Append(wr.Romset)
                            .Append(" ")
                            .Append(Strings.RequiredBy)
                            .Append(" ")
                            .Append(string.Join(",", wr.MissingRomsets.Distinct().OrderBy(x => x)))
                            .AppendLine();
                    }
                    if (wr.OptionalRomsets.Any())
                    {
                        sb
                            .Append(wr.Romset)
                            .Append(" ")
                            .Append(Strings.NotUsedAnymoreBy)
                            .Append(" ")
                            .Append(string.Join(",", wr.OptionalRomsets.Distinct().OrderBy(x => x)))
                            .AppendLine();
                    }
                }
                Dialogs.ShowInfoDialog(Strings.CheckingResults + "\n\n" + sb.ToString());
            }
            UpdateInfo();
            return true;
        }
        catch (Exception ex)
        {
            Dialogs.ShowErrorDialog(new Exception(Strings.RomsetValidationFailed, ex));
            return false;
        }
    }

    private void AddOptionalRomsetToWarningList(string machineName, string requiredMachineName)
    {
        if (_selectedItems.Contains(requiredMachineName))
            return;
        if (_files.FirstOrDefault(x => x.Name == requiredMachineName) is null)
            return;
        _warningRoms.AddToOptionalRomsetList(machineName, requiredMachineName);
    }

    private void AddMissingRomsetToWarningList(string machineName, string requiredMachineName)
    {
        if (_selectedItems.Contains(requiredMachineName))
            return;
        if (_files.FirstOrDefault(x => x.Name == requiredMachineName) is null)
            return;
        _warningRoms.AddToMissingRomsetList(machineName, requiredMachineName);
    }

    private void MoveMameFiles(MameMachine machine, string destinationPath)
    {
        _ = Directory.CreateDirectory(destinationPath);
        var mamePath = Path.GetDirectoryName(_userPreferences.Mame.ExecutableFilePath);
        var files = MameFiles.GetAllMameMachineFiles(mamePath, _mameConfig, machine, _userPreferences.Mame.RomPaths);
        foreach (var file in files)
        {
            var fi = new FileInfo(file.Filename);
            var destFolder = Path.Combine(destinationPath, file.RelativeFolder);
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            var destFile = Path.Combine(destFolder, fi.Name);
            if (File.Exists(destFile))
            {
                // If already exists, find a new unique name
                var index = 0;
                while (index < 999)
                {
                    index++;
                    var name = Path.GetFileNameWithoutExtension(fi.Name);
                    var ext = fi.Extension;
                    destFile = Path.Combine(destFolder, $"{name} ({index + 1}){ext}");
                    if (!File.Exists(destFile))
                        break;
                }
            }
            File.Move(file.Filename, destFile);
        }
    }

    private readonly MachinesCache _mameCache = new();
    private readonly SnapshotsCache _snapshotsCache = new();

    void SetOnlineFiltersEnabled(bool enabled)
    {
        // TODO: rifare il menu o seguire la definizione per poi disabilitare le voci diverse
        //var onlineFilters = new[]
        //{
        //    MenuFilterTypeMamecab,
        //    MenuFilterClassificationsGenre,
        //    MenuFilterClassificationsCategories,
        //    MenuFilterRelease,
        //};

        ////var changed = false;
        //foreach (var item in onlineFilters)
        //{
        //    if (item.Enabled == enabled)
        //        continue;
        //    item.Enabled = enabled;
        //    //changed = true;
        //}
    }

    private async Task LoadFromArcadeDatabaseOrCache(Action<string> progressUpdate)
    {
        SetOnlineFiltersEnabled(false);

        // Verifica online
        if (_online != false)
        {
            if (await ArcadeDatabaseIsOnline())
            {
                try
                {
                    progressUpdate($"{Strings.LoadingArcadeItalia} ({Strings.Release})");
                    // Check release
                    var adbRelease = await ServiceMame.Releases();
                    var mameRelease = string.Join(",", adbRelease.Result);

                    progressUpdate($"{Strings.LoadingArcadeItalia} ({Strings.Games})");
                    if (!_mameCache.IsValid(_applicationName, mameRelease))
                    {
                        // Download categories and machine extra info
                        // http://adb.arcadeitalia.net/service_scraper.php?ajax=query_categories&game_name=mslug;atetris;100lions;mslug3;mslug5
                        var adbMameCache = await ServiceScraper.QueryCategories();
                        _mameCache.Clear();
                        if (adbMameCache.Result is not null && adbMameCache.Result.Machines.Any())
                        {
                            foreach (var machine in adbMameCache.Result.Machines)
                            {
                                _mameCache.Add(
                                    key: machine.GameName,
                                    genre: machine.Genre,
                                    serie: machine.Serie,
                                    category: machine.Category,
                                    release: machine.Release,
                                    mameCab: machine.MameCab
                                );
                            }
                            _mameCache.Store(_applicationName, mameRelease);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.ShowErrorDialog($"{Strings.ErrorLoadingArcadeItalia}\n\n{ex.Message}");
                }
            }
        }

        if (_mameCache.Items.Any())
        {
            foreach (var machine in _mame.Machines)
            {
                var item = _mameCache.GetByKey(machine.Name);
                if (item is null)
                    continue;
                machine.Extra.Genre = item.Genre;
                machine.Extra.Category = item.Category;
                machine.Extra.FirstEmulatorRelease = item.Release;
                machine.Extra.IsMameCab = item.MameCab;
            }
            SetOnlineFiltersEnabled(true);
        }
        progressUpdate.Invoke(string.Empty);
    }

    private async Task<bool> ArcadeDatabaseIsOnline()
    {
        if (_online == false)
            return _online.Value;
        if (_userPreferences.ArcadeDatabase.ConnectionOption == ArcadeDatabaseSection.ConnectionOptionKind.Offline)
        {
            _online = false;
            return _online.Value;
        }
        if (_online is null)
        {
            try
            {
                var adbStatus = await ServiceGeneric.WebSiteStatus();
                if (adbStatus.Result?.IsOnline() != true)
                    throw new Exception(Strings.WebSiteUnderMaintenance);
                _online = true;
            }
            catch (Exception ex)
            {
                _online = false;
                Dialogs.ShowInfoDialog($"{Strings.ErrorLoadingArcadeItaliaVerbose}\n\n{ex.Message}");
            }
        }
        return _online.Value;
    }

    private string? GetSelectedGameName() => _currentSelectedItem?.Name;

    private MameMachine? GetSelectedMachine() => string.IsNullOrEmpty(_currentSelectedItem?.Name) ? null : _mame.Machines.GetMachineByName(_currentSelectedItem!.Name!);

    private void UpdateCurrentRomsetInfo()
    {
        var machine = GetSelectedMachine();
        if (machine is null)
        {
            pnlRomset.Hide();
            SelectedRomsetName.Hide();
            OpenRomsetWebPage.Hide();
            ClearSnapshot();
            return;
        }
        try
        {
            var item = _gridItems.Values.FirstOrDefault(x => x.Name == machine.Name)
                ?? throw new Exception();
            SelectedRomsetName.Text = machine.Name.ToUpper();
            OpenRomsetWebPage.Tag = ServiceMame.GetRomsetUrl(machine.Name);
            SelectedRomsetName.Show();
            OpenRomsetWebPage.Show();

            var tipo = "-";
            if (machine.IsBios)
                tipo = Strings.Bios;
            else if (machine.IsDevice)
                tipo = Strings.Device;
            else if (machine.IsParentMachine)
                tipo = Strings.Parent;
            else if (machine.IsCloneMachine)
                tipo = Strings.Clone;
            else if (machine.IsMechanical)
                tipo = Strings.Mechanical;
            var dati = new Dictionary<string, string?>
            {
                [Strings.Title] = item.Description,
                [Strings.Manufacturer] = item.Manufacturer,
                [Strings.Status] = item.DriverStatus,
                [Strings.Year] = machine.Year,
                [Strings.Genre] = item.Genre,
                [Strings.Category] = item.Category,
                [Strings.Release] = item.FirstEmulatorRelease,
                [Strings.Clone] = item.CloneOf,
                [Strings.UseRomOf] = item.RomOf,
                [Strings.Type] = tipo,
                [Strings.Screen] = item.Display,
                [Strings.File] = item.HasFiles ? item.TotalFilesSize.ToFileSizeString() : "-"
            };

            KeyValueRomset.SetData(dati);

            pnlRomset.Show();
        }
        catch
        {
            pnlRomset.Hide();
            SelectedRomsetName.Hide();
            OpenRomsetWebPage.Hide();
        }
        LoadSnapshot(machine.Name);
    }

    private CancellationTokenSource _snapshotCts = new();
    private void ClearSnapshot()
    {
        // Cancel current process
        _snapshotCts.Cancel();
        _snapshotCts.Dispose();
        _snapshotCts = new();
        var token = _snapshotCts.Token;

        // Remove progress bar
        Snapshot.Controls.OfType<ProgressBar>().ToList().ForEach(pb => Snapshot.Controls.Remove(pb));
        Snapshot.Image = SnapshotPlaceholder.Image;
    }

    private async void LoadSnapshot(string romset)
    {
        ClearSnapshot();

        // Create a progress bar
        var progressBar = new ProgressBar
        {
            Style = ProgressBarStyle.Marquee,
            MarqueeAnimationSpeed = 15,
            Dock = DockStyle.Bottom,
            Height = 5
        };
        Snapshot.Controls.Add(progressBar);
        Snapshot.Refresh(); // Screen update required

        try
        {
            _snapshotCts.Token.ThrowIfCancellationRequested();
            // Jon work in background
            var image = await Task.Run(() => GetGameSnapshotImage(romset, _snapshotCts.Token));
            _snapshotCts.Token.ThrowIfCancellationRequested();
            Snapshot.Image = image;
        }
        catch (OperationCanceledException)
        {
            // Ignore
        }
        catch
        {
            // If error, use a placeholder
            Snapshot.Image = SnapshotPlaceholder.Image;
        }
        finally
        {
            Snapshot.Controls.Remove(progressBar);
        }
    }

    private async Task<Image> GetGameSnapshotImage(string? romset, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(romset))
        {
            cancellationToken.ThrowIfCancellationRequested();
            return SnapshotPlaceholder.Image;
        }
        foreach (var path in _mameConfig.GetMameMachineFilenames(romset, _mameConfig.SnapshotDirectory))
        {
            cancellationToken.ThrowIfCancellationRequested();
            foreach (var ext in "png,jpg".Split(','))
            {
                var filename = $"{path}.{ext}";
                if (File.Exists(filename))
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return Image.FromFile(filename);
                }
            }
        }

        // Tento con i dati in cache
        var file = _snapshotsCache.GetByKey(romset!);
        if (file is not null)
            return Image.FromFile(file.FilePath);


        // If not found, try online resources
        if (await ArcadeDatabaseIsOnline())
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                var imageStream = await Servicedownload.GetCurrentIngameFile(romset!, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
                var image = ImageHelper.ConvertStreamToImage(imageStream);
                _snapshotsCache.Add(romset!, image);
                return image;
            }
            catch
            {
                // Ignore
            }
        }
        cancellationToken.ThrowIfCancellationRequested();
        return SnapshotPlaceholder.Image;
    }

    private void OpenRomsetWebPage_Click(object sender, EventArgs e)
    {
        var url = OpenRomsetWebPage.Tag?.ToString();
        if (string.IsNullOrEmpty(url))
            return;
        Dialogs.OpenUrl(url!);
    }

    private void GamesListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        var oldValue = _currentSelectedItem;
        if (GamesListView.SelectedIndices.Count > 0 && _gridItems.TryGetValue(GamesListView.SelectedIndices[0], out var value))
            _currentSelectedItem = value;
        else
            _currentSelectedItem = null;
        if (oldValue != _currentSelectedItem)
            UpdateCurrentRomsetInfo();
    }

    private void GamesListView_MouseDown(object sender, MouseEventArgs e)
    {
        var info = GamesListView.HitTest(e.Location);
        if (info.Item == null && _currentSelectedItem != null)
        {
            _currentSelectedItem = null;
            GamesListView.SelectedIndices.Clear();
            UpdateCurrentRomsetInfo();
        }
    }


    private void MenuFiltersItem_Click(object sender, EventArgs e)
    {
        if (sender is not ToolStripItem menuItem)
            return;
        if (!menuItem.Enabled)
            return;
        if (!Enum.TryParse(menuItem.Tag?.ToString() ?? string.Empty, true, out FilterKind filter) || !_menuActions.ContainsKey(filter))
            Dialogs.ShowErrorDialog($"Unsupported filter type {menuItem.Tag?.ToString()}");
        ApplyFilters(_menuActions[filter]);
    }
}
