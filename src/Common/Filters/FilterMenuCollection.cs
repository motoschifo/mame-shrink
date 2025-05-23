﻿#nullable enable
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using MAME_Shrink.Extensions;
using MameTools.Net48.Machine;

namespace MAME_Shrink.Common.Filters;
internal class FilterMenuCollection : Collection<FilterMenuItem>
{
    public FilterMenuCollection()
    {
        FilterMenuDefinition.Initialize(this);
    }

    public new FilterMenuItem this[int index] => _filterKindMap[(FilterKind)index];

    public void BuildMenuItems(ToolStripItemCollection target, EventHandler clickHandler, Dictionary<FilterKind, Func<MameMachine, bool>> actions)
    {
        target.Clear();
        _filterKindMap.Clear();
        BuildMenuItems([.. this], target, clickHandler, actions, 0);
    }

    public List<FilterMenuItem> ToList() => [.. Items];

    private readonly Dictionary<FilterKind, FilterMenuItem> _filterKindMap = [];

    public void BuildMenuItems(List<FilterMenuItem> items, ToolStripItemCollection target,
        EventHandler clickHandler, Dictionary<FilterKind, Func<MameMachine, bool>> actions, int level)
    {
        if (level > 99)
            throw new Exception("Recursive search, too many levels. Please check filter declaration to avoid infinite loops");
        foreach (var item in items)
        {
            if (item.IsSeparator)
            {
                target.Add(new ToolStripSeparator());
                continue;
            }

            var menuItem = new ToolStripMenuItem(item.Text)
            {
                Tag = item.Kind,
                Enabled = item.Enabled
            };
            if (item.Kind is not null)
            {
                _filterKindMap[item.Kind.Value] = item;
                menuItem.Click += clickHandler;
                item.MenuItem = menuItem;
                item.Action = actions.TryGetValue(item.Kind.Value, out var action) ? action : null;
            }
            else if (item.Children.Any())
            {
                BuildMenuItems(item.Children, menuItem.DropDownItems, clickHandler, actions, level++);
            }
            target.Add(menuItem);
        }
    }

    public void UpdateFilterMenuCounters(Dictionary<string, MameMachine> machines)
    {
        foreach (var filter in _filterKindMap.Values)
        {
            var menu = filter.MenuItem!;
            if (!filter.Enabled || filter.NotImplemented || filter.Action is null)
            {
                menu.Enabled = false;
                continue;
            }
            menu.Enabled = true;
            if (filter.UpdateCounter)
            {
                var count = machines.Count(x => filter.Action.Invoke(x.Value));
                if (count > 0)
                {
                    menu.Enabled = true;
                    menu.ShortcutKeyDisplayString = count.ToFormattedString();
                }
                else
                {
                    menu.ShortcutKeyDisplayString = "-";
                }
            }
        }
    }

    public void UpdateFilterMenuHandlers()
    {
        foreach (var filter in _filterKindMap.Values.Where(x => x.MenuItem is not null))
        {
            var menu = filter.MenuItem!;
            if (filter.NotImplemented)
            {
                menu.Enabled = false;
                continue;
            }
            if (menu.Enabled != filter.Enabled)
                menu.Enabled = filter.Enabled;
        }
    }
}
