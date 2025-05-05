#nullable enable
namespace MameTools.Net48.Machines.Shared;

public partial class Condition
{
    public enum RelationKind
    {
        unknown,
        eq,
        ne,
        gt,
        le,
        lt,
        ge
    }
}
