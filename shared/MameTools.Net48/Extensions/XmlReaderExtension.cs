#nullable enable
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
namespace MameTools.Net48.Extensions;

public static class XmlReaderExtensions
{
    private static readonly Dictionary<Type, Func<string, (bool Success, object? Value)>> _parsers =
        new()
        {
            [typeof(int)] = s => (int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v), v),
            [typeof(bool)] = s => (bool.TryParse(s, out var v), v), // bool non ha overload con cultura
            [typeof(long)] = s => (long.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v), v),
            [typeof(short)] = s => (short.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v), v),
            [typeof(byte)] = s => (byte.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v), v),
            [typeof(decimal)] = s => (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out var v), v),
            [typeof(double)] = s => (double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var v), v),
            [typeof(float)] = s => (float.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var v), v),
            [typeof(DateTime)] = s => (DateTime.TryParse(s, CultureInfo.InvariantCulture, DateTimeStyles.None, out var v), v),
            [typeof(Guid)] = s => (Guid.TryParse(s, out var v), v),
            [typeof(uint)] = s => (uint.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v), v),
            [typeof(ulong)] = s => (ulong.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v), v),
            [typeof(ushort)] = s => (ushort.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v), v),
            [typeof(sbyte)] = s => (sbyte.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v), v),
            [typeof(char)] = s => (char.TryParse(s, out var v), v)
        };

    public static T? GetAttribute<T>(this XmlReader reader, string name) where T : struct
    {
        var value = reader.GetAttribute(name);
        if (value == null) return null;

        if (!_parsers.TryGetValue(typeof(T), out var parser))
            throw new NotImplementedException($"GetAttribute<{typeof(T)}> not implemented");
        (var success, var result) = parser(value);
        return success ? (T?)result : null;
    }

    public static bool IsStartElementIgnoreCase(this XmlReader reader, string localName) => reader.IsStartElement() && localName.EqualsIgnoreCase(reader.LocalName);

    public static bool IsElement(this XmlReader reader, string name) => reader.NodeType == XmlNodeType.Element && name.EqualsIgnoreCase(reader.LocalName);
}