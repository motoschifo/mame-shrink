#nullable enable
using MameTools.Net48.Common;
using MameTools.Net48.Extensions;
using MameTools.Net48.Software.Parts.DataAreas.Roms;

namespace MameTools.Net48.Software.Parts.DataAreas;

public partial class DataArea
{
    public string Name { get; set; } = default!;
    public int Size { get; set; }
    public int DataBits { get; set; } = 8;
    public EndianKind Endian { get; set; } = EndianKind.little;
    public static EndianKind ParseEndian(string? value) => value.ToEnum(EndianKind.unknown, EndianKind.little);
    public MameCollection<Rom> Roms { get; private set; } = [];
}
