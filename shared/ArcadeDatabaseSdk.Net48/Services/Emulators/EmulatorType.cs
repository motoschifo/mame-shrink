#nullable enable
namespace ArcadeDatabaseSdk.Net48.Services.Emulators;

public partial class EmulatorsApiResult
{
    public enum EmulatorType
    {
        /// <summary>Mame</summary>
        Mame,

        /// <summary>Mess (obsolete)</summary>
        Mess,
    }
}