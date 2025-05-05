#nullable enable
using System.Threading.Tasks;
using ArcadeDatabaseSdk.Net48.Common;
using ArcadeDatabaseSdk.Net48.Services.Mame;

namespace ArcadeDatabaseSdk.Net48.Mame;
public static class ServiceMame
{
    public static async Task<ReleasesResult> Releases()
    {
        return await HttpClientReader.GetServiceMame<ReleasesResult>("releases") ?? new();
    }

    public static string GetRomsetUrl(string romset) => $"{Constants.ApiUrl}/?mame={romset}";
}
