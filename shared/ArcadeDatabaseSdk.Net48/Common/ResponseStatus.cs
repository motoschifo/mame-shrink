#nullable enable
using ArcadeDatabaseSdk.Net48.Extensions;

namespace ArcadeDatabaseSdk.Net48.Common;

public partial class ApiResponse
{
    public enum ResponseStatus
    {
        Success,
        Error
    }

    public static ResponseStatus ParseStatus(string? value) => value.ToEnum(ResponseStatus.Error, ResponseStatus.Success);
}