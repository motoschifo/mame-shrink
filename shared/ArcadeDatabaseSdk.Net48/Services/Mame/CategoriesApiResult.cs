#nullable enable
using Newtonsoft.Json;
namespace ArcadeDatabaseSdk.Net48.Services.Mame;

public class CategoriesApiResult
{
    [JsonProperty("name")]
    public string Name { get; set; } = default!;

    [JsonProperty("genre")]
    public string? Genre { get; set; }

    [JsonProperty("category")]
    public string? Category { get; set; }

    [JsonProperty("serie")]
    public string? Serie { get; set; }

    [JsonProperty("release")]
    public string? Release { get; set; }

    [JsonProperty("is_mamecab")]
    public bool IsMameCab { get; set; }
}
