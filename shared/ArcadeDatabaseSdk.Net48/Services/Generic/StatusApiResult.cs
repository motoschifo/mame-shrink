#nullable enable
using Newtonsoft.Json;

namespace ArcadeDatabaseSdk.Net48.Services.Generic;
public class StatusApiResult
{
    [JsonProperty("website_online")]
    public bool WebSiteOnline { get; set; }

    [JsonProperty("api_online")]
    public bool ApiOnline { get; set; }
}

