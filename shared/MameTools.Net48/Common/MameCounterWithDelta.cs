#nullable enable
using System.Collections.Generic;
using MameTools.Net48.Extensions;
namespace MameTools.Net48.Common;

public class MameCounterWithDelta(string text, int? count = null, int? removed = null, int? added = null, bool trustDatValues = false, bool isSoftware = false)
{
    public string Text => _text;
    private readonly string _text = text;

    public int? Count => _count;
    private int? _count = count;

    public bool IsSoftware => _isSoftware;
    public bool _isSoftware = isSoftware;

    private readonly List<string> _countItems = [];
    public List<string> CountList => _countItems;

    public int? Removed => _removed;
    private int? _removed = removed;
    public int? Added => _added;

    public bool TrustDatValues => trustDatValues;

    private int? _added = added;

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

    public void IncrementAdded(int value = 1)
    {
        _added ??= 0;
        _added += value;
    }

    public void DecrementAdded(int value = 1)
    {
        _added ??= 0;
        _added -= value;
    }

    public void SetAdded(int? value = null) => _added = value;
    public void ResetAdded() => _added = null;

    public void IncrementRemoved(int value = 1)
    {
        _removed ??= 0;
        _removed += value;
    }

    public void DecrementRemoved(int value = 1)
    {
        _removed ??= 0;
        _removed -= value;
    }

    public void SetRemoved(int? value = null) => _removed = value;
    public void ResetRemoved() => _removed = null;

    //public void Reset(int? value)
    //{
    //    _count = value;
    //    _removed = value;
    //    _added = value;
    //    _countItems.Clear();
    //}

    public void SetAddedOrRemoved(int? value = null)
    {
        if (value is null or 0)
        {
            _added = value;
            _removed = value;
        }
        else if (value > 0)
        {
            _added = value;
            _removed = 0;
        }
        else
        {
            _added = 0;
            _removed = -value;
        }
    }

    public string DeltaFormattedText()
    {
        if (_removed.HasValue && _removed.Value != 0 && _added.HasValue && _added.Value != 0)
            return $"(-{_removed.Value}/+{_added.Value})";
        if (_added.HasValue && _added != 0)
            return $"(+{_added.Value})";
        if (_removed.HasValue && _removed.Value != 0)
            return $"(-{_removed.Value})";
        return string.Empty;
    }

    public string CountFormattedText() => ($"{(_count ?? 0).ToDottedString()} {_text} {DeltaFormattedText()}").Trim();

    public override string ToString() => _count.ToString();
}
