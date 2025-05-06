#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using ArcadeDatabaseSdk.Net48.Common;
using Newtonsoft.Json;
namespace MAME_Shrink.Common.Cache;

public class MachinesCache
{
    private string? _filePath;

    [JsonRequired] public int Release { get; private set; }
    [JsonRequired] public string? MameRelease { get; private set; }
    [JsonRequired] public Dictionary<string, MachineCacheItem> Items { get; } = [];

    public void SetFilePath(string filePath)
    {
        _filePath = filePath;
        var folder = Path.GetDirectoryName(_filePath);
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
        else if (File.Exists(_filePath))
        {
            try
            {
                var cat = JsonHelper.DeserializeJsonFileExact<MachinesCache>(_filePath);
                if (cat is not null)
                {
                    Release = cat.Release;
                    MameRelease = cat.MameRelease;
                    Items.Clear();
                    foreach (var item in cat.Items)
                    {
                        Items[item.Key] = item.Value;
                    }
                }
            }
            catch
            {
                // Ignore
                //_logger.Error($"Invalid categories cache file {filename}");
            }
        }
    }

    public void Clear()
    {
        Release = 0;
        MameRelease = null;
        Items.Clear();
    }

    public void Add(string key, string? genre, string? category, string? release, bool mameCab)
    {
        Items[key] = new MachineCacheItem
        {
            Genre = genre,
            Category = category,
            Release = release,
            MameCab = mameCab
        };
    }

    public void Remove(string key)
    {
        Items.Remove(key);
    }

    public void Store(int release, string mameRelease)
    {
        if (string.IsNullOrEmpty(_filePath))
            throw new Exception("File path not set");
        Release = release;
        MameRelease = mameRelease;
        JsonHelper.SerializeJsonFile(_filePath!, this);
    }

    public MachineCacheItem? GetByKey(string key) => Items.TryGetValue(key, out MachineCacheItem? item) ? item : null;
}
