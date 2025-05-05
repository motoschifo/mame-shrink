#nullable enable
using System.Collections.Generic;
using System.Threading.Tasks;
using ArcadeDatabaseSdk.Net48.Common;
using ArcadeDatabaseSdk.Net48.Services.Scraper;

namespace ArcadeDatabaseSdk.Net48.Services;
public static class ServiceScraper
{
    public static async Task<QueryMameDataResult> QueryCategories(string[]? romsets = null)
    {
        // Es. http://adb.arcadeitalia.net/service_scraper.php?ajax=query_categories&game_name=mslug;atetris;100lions;mslug3;mslug5

        return romsets is null || romsets.Length == 0
            ? await HttpClientReader.GetServiceScraper<QueryMameDataResult>("query_categories") ?? new()
            : await HttpClientReader.GetServiceScraper<QueryMameDataResult>("query_categories", new Dictionary<string, string?> {
            { "game_name", string.Join(";", romsets) }
        }) ?? new();
    }

    public static async Task<QueryMameSnapshotResult> QueryMameSnapshot(string romset)
    {
        return string.IsNullOrEmpty(romset)
            ? new()
            : await HttpClientReader.GetServiceScraper<QueryMameSnapshotResult>("query_mame_snapshot", new Dictionary<string, string?> {
            { "game_name", romset }
        }) ?? new();
    }

}
