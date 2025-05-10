#nullable enable
namespace ArcadeDatabaseSdk.Net48.Common;

public class Constants
{
    public const string HomePage = "http://adb.arcadeitalia.net";
    public const string ApiUrl = "http://adb.arcadeitalia.net/api";
    public const string GenericApiUrl = $"{ApiUrl}";
    public const string MameApiUrl = $"{ApiUrl}/mame";
    
    public const string LegacyApiUrl = "http://adb.arcadeitalia.net";
    public const string LegacyAjaxParameter = "ajax";
    public const string LegacyServiceScraperUrl = $"{LegacyApiUrl}/service_scraper.php";
    public const string LegacyApiMameUrl = $"{LegacyApiUrl}/api_mame.php";
    public const string LegacyServiceDownloadUrl = $"{LegacyApiUrl}/download_file.php";
}
