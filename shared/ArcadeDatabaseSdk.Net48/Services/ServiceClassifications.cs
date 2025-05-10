#nullable enable
using System.Collections.Generic;
using System.Threading.Tasks;
using ArcadeDatabaseSdk.Net48.Common;
using ArcadeDatabaseSdk.Net48.Services.Categories;
using static ArcadeDatabaseSdk.Net48.Common.ApiResponse;

namespace ArcadeDatabaseSdk.Net48.Services;
public static class ServiceClassifications
{
    public static async Task<ApiResponse<ClassificationsApiResult>> Get(ClassificationType classificationType, LanguageKind? language = null)
    {
        var parameters = new Dictionary<string, string?>();
        if (language is not null)
        {
            parameters.Add("language", language.ToString().ToLower());
        }
        ;
        return await HttpClientReader.GetServiceClassifications<ClassificationsApiResult>(classificationType, parameters);
    }
}
