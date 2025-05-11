#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
namespace MameTools.Net48.Common;

public class MameCollection<T> : ICollection<T>
{
    private readonly List<T> _items = [];

    public int Count => _items.Count;

    public bool IsReadOnly => false;

    public void Add(T item) => _items.Add(item);
    public void Clear() => _items.Clear();
    public bool Contains(T item) => _items.Contains(item);
    public void CopyTo(T[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);
    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();
    public bool Remove(T item)
    {
        //_items.Remove(item);
        // ATTENZIONE
        // Per poter rimuovere un elemento occorrerebbe fare tutti i calcoli a ritroso
        // e ripristinare così i totali.
        // Per il momento evito e restituisco un errore in fase di rimozione
        throw new NotImplementedException();
    }
    IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
    public List<T> ToList() => [.. _items];
    public T this[int index] => _items[index];
}
