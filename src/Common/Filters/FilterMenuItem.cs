#nullable enable
using System.Collections.Generic;

namespace MAME_Shrink.Common.Filters;
internal class FilterMenuItem
{
    public string? Text { get; set; }
    public FilterKind? Kind { get; set; }
    public bool IsSeparator { get; set; } = false;
    public bool Enabled { get; set; } = true;
    public List<FilterMenuItem> Children { get; set; } = [];
}