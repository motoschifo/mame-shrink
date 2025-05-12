#nullable enable
using Newtonsoft.Json;
namespace ArcadeDatabaseSdk.Net48.Services.Categories;

public partial class ClassificationsApiResult
{
    [JsonProperty("code")]
    public string? Code { get; set; } 

    [JsonProperty("title")]
    public string? Title { get; set; }

    [JsonProperty("is_obsolete")]
    public bool IsObsolete { get; set; }
}
