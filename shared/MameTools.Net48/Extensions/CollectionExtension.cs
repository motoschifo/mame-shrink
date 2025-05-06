#nullable enable
using System.Collections.Generic;
namespace MameTools.Net48.Extensions;

public static class CollectionExtensions
{
    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T>? items)
    {
        if (items is null)
            return;
        foreach (var item in items)
            collection.Add(item);
    }
}