#nullable enable
namespace MameTools.Net48.Machines.Drivers;

public partial class Driver
{
    public enum DriverStatusKind
    {
        unknown,
        good,
        imperfect,
        preliminary
    }
}