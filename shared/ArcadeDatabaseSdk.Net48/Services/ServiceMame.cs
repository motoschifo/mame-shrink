#nullable enable
using System.Collections.Generic;
using System.Threading.Tasks;
using ArcadeDatabaseSdk.Net48.Common;
using ArcadeDatabaseSdk.Net48.Services.Mame;

namespace ArcadeDatabaseSdk.Net48.Mame;
public static class ServiceMame
{
    public static async Task<ApiResponse<string>> Releases()
    {
        return await HttpClientReader.GetServiceMame<string>("releases");
    }

    public static async Task<ApiResponse<CategoriesApiResult>> Categories(List<string>? names = null)
    {
        var parameters = names is null || names.Count == 0 ? null : new Dictionary<string, string?> {
            { "name", string.Join(";", names) }
        };
        return await HttpClientReader.GetServiceMame<CategoriesApiResult>("categories", parameters);
    }

    public static string GetRomsetUrl(string romset) => $"{Constants.LegacyApiUrl}/?mame={romset}";
}
