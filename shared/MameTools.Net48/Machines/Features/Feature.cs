#nullable enable
using MameTools.Net48.Extensions;

namespace MameTools.Net48.Machines.Feature;

public partial class Feature
{
    public FeatureKind Type { get; set; } = default!;
    public static FeatureKind Parse(string? value) => value.ToEnum(FeatureKind.unknown, FeatureKind.unknown);
    public FeatureStatusKind Status { get; set; } = default!;
    public static FeatureStatusKind ParseStatus(string? value) => value.ToEnum(FeatureStatusKind.unknown, FeatureStatusKind.unknown);
    public FeatureOverallKind Overall { get; set; } = default!;
    public static FeatureOverallKind ParseOverall(string? value) => value.ToEnum(FeatureOverallKind.unknown, FeatureOverallKind.unknown);

    public bool Unemulated => Status is FeatureStatusKind.unemulated || Overall is FeatureOverallKind.unemulated;
    public bool Imperfect => Status is FeatureStatusKind.imperfect || Overall is FeatureOverallKind.imperfect;

}
