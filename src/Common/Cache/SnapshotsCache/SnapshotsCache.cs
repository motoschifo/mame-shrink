#nullable enable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace MAME_Shrink.Common.Cache.SnapshotCache;

public class SnapshotsCache
{
    public Dictionary<string, SnapshotCacheItem> Items { get; } = [];
    private string? _baseFilePath;
    private const int _retentionDays = 7;
    private const string _extension = "png";

    public void SetFilePath(string filePath)
    {
        _baseFilePath = filePath;
        if (!Directory.Exists(_baseFilePath))
        {
            Directory.CreateDirectory(_baseFilePath);
        }
        else
        {
            var files = Directory.GetFiles(_baseFilePath, $"*.{_extension}", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                var dateLastUpdate = File.GetLastWriteTime(file);
                if (dateLastUpdate < DateTime.Now.AddDays(-_retentionDays))
                {
                    File.Delete(file);
                    continue;
                }
                string key = Path.GetFileNameWithoutExtension(file);
                Items[key] = new()
                {
                    DateLastUpdate = dateLastUpdate,
                    FilePath = file
                };
            }
        }
    }

    public void Clear()
    {
        Items.Clear();
    }

    public void Add(string key, string filePath)
    {
        Items[key] = new SnapshotCacheItem
        {
            DateLastUpdate = DateTime.Now,
            FilePath = filePath
        };
    }

    public void Remove(string key)
    {
        Items.Remove(key);
    }

    public SnapshotCacheItem? GetByKey(string key)
    {
        if (!Items.TryGetValue(key, out SnapshotCacheItem? item))
            return null;
        if (item.DateLastUpdate > DateTime.Now.AddDays(-_retentionDays) && File.Exists(item.FilePath))
            return item;
        return null;
    }

    public void Add(string key, Image image)
    {
        if (string.IsNullOrEmpty(_baseFilePath))
            throw new Exception("File path not set");
        var filePath = Path.Combine(_baseFilePath, $"{key}.{_extension}");
        image.Save(filePath, ImageFormat.Png);  // PNG only
        Items[key] = new SnapshotCacheItem
        {
            DateLastUpdate = DateTime.Now,
            FilePath = filePath
        };
    }


}
