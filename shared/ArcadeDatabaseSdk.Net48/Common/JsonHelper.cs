using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ArcadeDatabaseSdk.Net48.Common;

public class JsonHelper
{
    //public static async Task<T> DeserializeJsonFileAsync<T>(string filePath)
    //{
    //    if (!File.Exists(filePath))
    //        throw new FileNotFoundException($"File not found: {filePath}");
    //    //string jsonContent = File.ReadAllText(filePath);
    //    // Usa StreamReader per leggere il contenuto in modo asincrono
    //    using var reader = new StreamReader(filePath, Encoding.UTF8);
    //    string jsonContent = await reader.ReadToEndAsync();
    //    return JsonConvert.DeserializeObject<T>(jsonContent);
    //}

    public static T DeserializeJsonFile<T>(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"File not found: {filePath}");

        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: false);
        using var streamReader = new StreamReader(stream, Encoding.UTF8);
        using var jsonReader = new JsonTextReader(streamReader);

        var serializer = new JsonSerializer();
        return serializer.Deserialize<T>(jsonReader) ?? default!;
    }

    public static T DeserializeJsonFileExact<T>(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"File not found: {filePath}");

        try
        {
            var settings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Error,
                NullValueHandling = NullValueHandling.Ignore,
            };

            using var stream = new FileStream(
                path: filePath,
                mode: FileMode.Open,
                access: FileAccess.Read,
                share: FileShare.Read,
                bufferSize: 4096,
                useAsync: false
            );
            using var streamReader = new StreamReader(stream, Encoding.UTF8);
            using var jsonReader = new JsonTextReader(streamReader);
            var serializer = JsonSerializer.Create(settings);
            return serializer.Deserialize<T>(jsonReader) ?? default!;
        }
        catch (Exception ex)
        {
            throw new Exception($"JSON deserialization failed: {ex.Message}", ex);
        }
    }

    public static async Task SerializeJsonFileAsync<T>(string filePath, T data)
    {
        var jsonContent = JsonConvert.SerializeObject(data, Formatting.Indented);
        using var writer = new StreamWriter(filePath, false, Encoding.UTF8);
        await writer.WriteAsync(jsonContent);
    }

    public static void SerializeJsonFile<T>(string filePath, T data)
    {
        var jsonContent = JsonConvert.SerializeObject(data, Formatting.Indented);
        using var writer = new StreamWriter(filePath, false, Encoding.UTF8);
        writer.Write(jsonContent);
    }
}
