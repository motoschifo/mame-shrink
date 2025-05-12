#nullable enable
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ArcadeDatabaseSdk.Net48.Common;

namespace ArcadeDatabaseSdk.Net48.Services;
public static class DownloadService
{
    public static async Task<Stream> GetCurrentIngameFile(string romset, CancellationToken cancellationToken = default)
    {
        return await HttpClientReader.GetFile(Constants.LegacyServiceDownloadUrl, new Dictionary<string, string?> {
            { "tipo", "mame_current" },
            { "codice", romset },
            { "entity", "ingame" },
            { "oper", "view" },
            { "filler", $"{romset}.png" },
        }, cancellationToken);
    }
}
