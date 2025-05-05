#nullable enable
using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NLog;

namespace MAME_Shrink.Settings;
internal class UserPreferencesManager
{
    private static readonly string _filePath = "user-settings.json";
    public static UserPreferences? Get()
    {
        try
        {
            string json = File.ReadAllText(_filePath);
            var settings = JsonConvert.DeserializeObject<UserPreferences>(json) 
                ?? throw new Exception("Missing configuration");
            foreach (var column in UserPreferences.AllColumnDefinitions)
            {
                var existingColumn = settings.Grid.Columns.FirstOrDefault(c => c.Kind == column.Kind);
                if (existingColumn is null)
                    settings.Grid.Columns.Add(column);
            }
            return settings;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, $"Invalid User settings file {_filePath}");
            return null;
        }
    }

    private static readonly JsonSerializerSettings _jsonSerializerSettings = new()
    {
        Formatting = Formatting.Indented,
        Converters = { new StringEnumConverter() }
    };

    public static bool Set(UserPreferences userPreferences)
    {
        try
        {
            string json = JsonConvert.SerializeObject(userPreferences, _jsonSerializerSettings);
            File.WriteAllText(_filePath, json);
            return true;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, $"Failed to write user settings to {_filePath}");
            return false;
        }
    }

    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

}
