#nullable enable
using System.Collections.Generic;
using ArcadeDatabaseSdk.Net48.Common;
using Newtonsoft.Json;

namespace ArcadeDatabaseSdk.Net48.Services.Mame;
public class ReleasesResult : IApiResult
{
    [JsonProperty("release")]
    public int Release { get; set; }

    [JsonProperty("result")]
    public List<string>? Result { get; set; }
}
