#nullable enable
using System.Collections.Generic;
using System.Threading.Tasks;
using ArcadeDatabaseSdk.Net48.Common;
using ArcadeDatabaseSdk.Net48.Services.Emulators;
using static ArcadeDatabaseSdk.Net48.Common.ApiResponse;
using static ArcadeDatabaseSdk.Net48.Services.Emulators.EmulatorsApiResult;

namespace ArcadeDatabaseSdk.Net48.Services;
public static class EmulatorsService
{
    public static async Task<ApiResponse<EmulatorsApiResult>> Get(EmulatorType emulatorType, LanguageKind? language = null)
    {
        var parameters = new Dictionary<string, string?>();
        if (language is not null)
        {
            parameters.Add("language", language.ToString().ToLower());
        }
        ;
        return await HttpClientReader.GetEmulatorsService<EmulatorsApiResult>(emulatorType.ToString().ToLower(), parameters);
    }
}
