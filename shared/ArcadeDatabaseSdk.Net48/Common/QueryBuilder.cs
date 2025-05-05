#nullable enable
using System;
using System.Collections.Generic;
using System.Web;
namespace ArcadeDatabaseSdk.Net48.Common;

public class QueryBuilder(string baseUrl)
{
    private readonly string _baseUrl = baseUrl;
    private readonly Dictionary<string, string> _parameters = [];

    public QueryBuilder AddParameter(string key, string? value)
    {
        if (value is null)
            return this;    // I valori nulli non vengono aggiunti
        if (string.IsNullOrEmpty(key))
            throw new ArgumentException("Missing paramete key");
        _parameters[key] = HttpUtility.UrlEncode(value); // Codifica il valore
        return this;
    }

    public string Build()
    {
        var queryString = HttpUtility.ParseQueryString(string.Empty);
        foreach (var param in _parameters)
        {
            queryString[param.Key] = param.Value;
        }
        return $"{_baseUrl}?{queryString}";
    }
}
