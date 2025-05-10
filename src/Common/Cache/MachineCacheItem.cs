#nullable enable
namespace MAME_Shrink.Common.Cache;

public class MachineCacheItem
{
    public string? Genre { get; set; }
    public string? Category { get; set; }
    public string? Serie { get; set; }
    public string? Release { get; set; }
    public bool MameCab { get; set; }
}
