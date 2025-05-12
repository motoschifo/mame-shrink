#nullable enable
using System.Threading.Tasks;
using ArcadeDatabaseSdk.Net48.Common;
using ArcadeDatabaseSdk.Net48.Services.Base;

namespace ArcadeDatabaseSdk.Net48.Services;
public static class BaseService
{
    public static async Task<ApiResponse<StatusApiResult>> Status()
    {
        // Es. http://adb.arcadeitalia.net/service_generic.php?ajax=qebsite_status
        return await HttpClientReader.GetBaseService<StatusApiResult>("status");
    }
}
