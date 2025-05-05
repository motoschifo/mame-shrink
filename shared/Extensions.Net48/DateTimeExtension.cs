#nullable enable
using System;

namespace Extensions.Net48;

public static class DateTimeExtension
{
    /// <summary>
    /// Restituisce una data nel formato dd/MM/yyyy per controlli di testo
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string GetString(this DateTime value)
    {
        var s = "";
        if (value != DateTime.MinValue)
            s = value.ToString("dd/MM/yyyy");
        return s;
    }
}
