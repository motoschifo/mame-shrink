#nullable enable
using System.Collections.Generic;
using ArcadeDatabaseSdk.Net48.Common;
using Newtonsoft.Json;
namespace ArcadeDatabaseSdk.Net48.Services.Scraper;

public class QueryMameDataResult : IApiResult
{
    [JsonProperty("release")]
    public int Release { get; set; }

    [JsonProperty("result")]
    public ResultDto? Result { get; set; }

    public class ResultDto
    {
        [JsonProperty("mame_release")]
        public string? MameRelease { get; set; }

        [JsonProperty("machines")]
        public List<MachineResult> Machines { get; set; } = [];
    }

    public class MachineResult
    {

        [JsonProperty("game_name")]
        public string GameName { get; set; } = default!;

        [JsonProperty("genre")]
        public string? Genre { get; set; }

        [JsonProperty("category")]
        public string? Category { get; set; }
        [JsonProperty("serie")]
        public string? Serie { get; set; }

        [JsonProperty("release")]
        public string? Release { get; set; }

        [JsonProperty("mamecab")]
        public bool MameCab { get; set; }
    }

}
