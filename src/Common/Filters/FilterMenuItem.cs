#nullable enable
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MameTools.Machine;

namespace MAME_Shrink.Common.Filters;
internal class FilterMenuItem
{
    public string? Text { get; set; }
    public FilterKind? Kind { get; set; }
    public bool IsSeparator { get; set; } = false;
    public bool Enabled { get; set; } = true;
    public bool UpdateCounter { get; set; } = true;
    public List<FilterMenuItem> Children { get; set; } = [];
    public Func<MameMachine, bool>? Action { get; set; }
    public ToolStripMenuItem? MenuItem { get; set; }
}