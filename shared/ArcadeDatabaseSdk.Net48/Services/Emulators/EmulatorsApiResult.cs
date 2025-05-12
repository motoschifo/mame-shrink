#nullable enable
using System;
using Newtonsoft.Json;
namespace ArcadeDatabaseSdk.Net48.Services.Emulators;

public partial class EmulatorsApiResult
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("release")]
    public string? Release { get; set; }

    [JsonProperty("sequence")]
    public int Sequence { get; set; }

    [JsonProperty("release_date")]
    public DateTime ReleaseDate { get; set; }
}
