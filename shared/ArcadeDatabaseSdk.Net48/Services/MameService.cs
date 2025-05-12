#nullable enable
using System.Collections.Generic;
using System.Threading.Tasks;
using ArcadeDatabaseSdk.Net48.Common;
using ArcadeDatabaseSdk.Net48.Services.Mame;
using static ArcadeDatabaseSdk.Net48.Common.ApiResponse;

namespace ArcadeDatabaseSdk.Net48.Services;
public static class MameService
{
    public static async Task<ApiResponse<string>> Releases()
    {
        return await HttpClientReader.GetMameService<string>("releases");
    }

    public static async Task<ApiResponse<CategoriesApiResult>> Categories(List<string>? names = null, LanguageKind? language = null)
    {
        var parameters = new Dictionary<string, string?>();
        if (names is not null && names.Count > 0)
            parameters.Add("name", string.Join(";", names));
        if (language is not null)
            parameters.Add("language", language.ToString().ToLower());
        return await HttpClientReader.GetMameService<CategoriesApiResult>("categories", parameters);
    }

    public static string GetRomsetUrl(string romset) => $"{Constants.LegacyApiUrl}/?mame={romset}";
}
