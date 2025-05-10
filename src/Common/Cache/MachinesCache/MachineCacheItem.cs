#nullable enable
using Newtonsoft.Json;
namespace MAME_Shrink.Common.Cache;

public class MachineCacheItem
{
    [JsonRequired] public string? Genre { get; set; }
    [JsonRequired] public string? Category { get; set; }
    [JsonRequired] public string? Serie { get; set; }
    [JsonRequired] public string? Release { get; set; }
    [JsonRequired] public bool MameCab { get; set; }
}
