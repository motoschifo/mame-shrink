#nullable enable
using MameTools.Net48.Extensions;

namespace MAME_Shrink.Settings;

public partial class UserPreferences
{
    public partial class ArcadeDatabaseSection
    {
        public enum ConnectionOptionKind
        {
            Auto,
            Offline
        }

        public static ConnectionOptionKind ParseConnectionOption(string? value) => value.ToEnum(ConnectionOptionKind.Auto, ConnectionOptionKind.Auto);
    }
}
