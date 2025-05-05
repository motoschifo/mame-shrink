#nullable enable
using System;
namespace MAME_Shrink.Common.Cache;

public class SnapshotCacheItem
{
    public DateTime DateLastUpdate { get; set; }
    public string FilePath { get; set; } = string.Empty;
}
