#nullable enable
namespace MAME_Shrink.Forms.Selections;

public class SelectionListItem
{
    public string Code { get; set; } = default!;
    public string? Description { get; set; }
    public bool IsSelected { get; set; }
    public override string ToString() => Description ?? string.Empty;
}
