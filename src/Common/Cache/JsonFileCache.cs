#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using MAME_Shrink.Extensions;
using Newtonsoft.Json;
namespace MAME_Shrink.Common.Cache;

public class JsonFileCache<T> where T : class
{
    private string? _filePath;
    [JsonRequired] public string? ApplicationName { get; private set; }
    [JsonRequired] public string? Release { get; private set; }
    [JsonRequired] public Dictionary<string, T> Items { get; } = [];

    public void Initialize(string applicationName, string filePath)
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
                var cat = JsonHelper.DeserializeJsonFileExact<JsonFileCache<T>>(_filePath);
                if (cat is not null)
                {
                    Release = cat.Release;
                    ApplicationName = applicationName;
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
        Release = null;
        Items.Clear();
    }

    public void Add(string key, T item)
    {
        Items[key] = item;
    }

    public void Remove(string key)
    {
        Items.Remove(key);
    }

    public T? GetByKey(string key) => Items.TryGetValue(key, out T? item) ? item : null;

    public void Store(string applicationName, string? release)
    {
        if (string.IsNullOrEmpty(_filePath))
            throw new Exception("Missing file path");
        ApplicationName = applicationName;
        Release = release;
        JsonHelper.SerializeJsonFile(_filePath!, this);
    }

    public bool IsValid(string applicationName, string? release)
    {
        return applicationName == ApplicationName && release == Release && Items.Count > 0;
    }
}
