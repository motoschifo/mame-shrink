#nullable enable
using MameTools.Net48.Extensions;

namespace MameTools.Net48.Machines.Shared;

public partial class Condition
{
    public string Tag { get; set; } = default!;
    public string Mask { get; set; } = default!;
    public RelationKind Relation { get; set; } = default!;
    public static RelationKind ParseRelation(string? value) => value.ToEnum(RelationKind.unknown, RelationKind.unknown);
    public string Value { get; set; } = default!;
}