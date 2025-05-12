#nullable enable
using Newtonsoft.Json;

namespace ArcadeDatabaseSdk.Net48.Services.Base;
public class StatusApiResult
{
    [JsonProperty("is_website_online")]
    public bool WebSiteOnline { get; set; }

    [JsonProperty("is_api_online")]
    public bool ApiOnline { get; set; }
}

