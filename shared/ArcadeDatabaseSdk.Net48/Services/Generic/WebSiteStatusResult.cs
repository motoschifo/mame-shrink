#nullable enable
using ArcadeDatabaseSdk.Net48.Common;
using MameTools.Net48.Extensions;
using Newtonsoft.Json;

namespace ArcadeDatabaseSdk.Net48.Services.Generic;
public class WebSiteStatusResult : IApiResult
{
    [JsonProperty("release")]
    public int Release { get; set; }

    [JsonProperty("result")]
    public ResultDto? Result { get; set; }

    public class ResultDto
    {
        [JsonProperty("status")]
        public string? Status { get; set; }

        public bool IsOnline() => "ONLINE".EqualsIgnoreCase(Status);
        public bool IsOffline() => "OFFLINE".EqualsIgnoreCase(Status);
    }
}

