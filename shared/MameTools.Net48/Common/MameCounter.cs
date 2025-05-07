#nullable enable
using System.Collections.Generic;
using MameTools.Net48.Extensions;
namespace MameTools.Net48.Common;

public class MameCounter(string text, int? count = null)
{
    public string Text => _text;
    private readonly string _text = text;
    public int? Count => _count;
    private int? _count = count;

    private readonly List<string> _countItems = [];
    public List<string> CountList => _countItems;

    public void IncrementCount(int value = 1)
    {
        _count ??= 0;
        _count += value;
    }

    public void DecrementCount(int value = 1)
    {
        _count ??= 0;
        _count -= value;
    }

    public void IncrementCount(string value)
    {
        _count ??= 0;
        _count++;
        _countItems.Add(value);
    }

    public void IncrementCount(List<string> values)
    {
        _count ??= 0;
        _count += values.Count;
        _countItems.AddRange(values);
    }

    public void DecrementCount(string value)
    {
        _count ??= 0;
        _count--;
        _countItems.Remove(value);
    }

    public void DecrementCount(List<string> values)
    {
        _count ??= 0;
        _count -= values.Count;
        foreach (var value in values)
        {
            _countItems.Remove(value);
        }
    }

    public void SetCount(int? value = null) => _count = value;

    public void SetCount(List<string> texts)
    {
        _count = texts.Count;
        _countItems.Clear();
        _countItems.AddRange(texts);
    }

    public void ResetCount()
    {
        _count = null;
        _countItems.Clear();
    }


    public string CountFormattedText() => ($"{(_count ?? 0).ToDottedString()} {_text}").Trim();

    //public void Reset(int? value)
    //{
    //    _count = null;
    //    _countItems.Clear();

    public override string ToString() => Count?.ToString() ?? "0";
}
