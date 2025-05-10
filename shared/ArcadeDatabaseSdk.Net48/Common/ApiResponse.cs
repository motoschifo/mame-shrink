#nullable enable
using System.Collections.Generic;
using Newtonsoft.Json;
using static ArcadeDatabaseSdk.Net48.Common.ApiResponse;

namespace ArcadeDatabaseSdk.Net48.Common;

public class ApiResponse<T>
{
    [JsonProperty("status")]
    public ResponseStatus Status { get; set; } = ResponseStatus.Error;

    [JsonProperty("version")]
    public int Version { get; set; } = 1;

    [JsonProperty("message")]
    public string? Message { get; set; }

    [JsonProperty("data")]
    public List<T> Data { get; set; } = [];
}