#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ArcadeDatabaseSdk.Net48.Common;

public class HttpClientReader
{
    private static readonly HttpClient _client;
    private static int _timeoutSeconds = 30;

    static HttpClientReader()
    {
        _client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(_timeoutSeconds),
        };
        _client.DefaultRequestHeaders.Add("User-Agent", "ArcadeDatabaseSdk.Net48/1.0");
    }

    public static void SetTimeout(int seconds)
    {
        _timeoutSeconds = seconds;
        _client.Timeout = TimeSpan.FromSeconds(_timeoutSeconds);
    }

    public static async Task<T?> GetDataFromUrlAsync<T>(string url) where T : class
    {
        try
        {
            var response = await _client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(response);
        }
        catch (TimeoutException ex)
        {
            throw new Exception($"Errore di timeout: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Errore durante la lettura dei dati: {ex.Message}");
        }
    }

    public static async Task<T?> GetService<T>(string url, string operation, Dictionary<string, string?>? parameters = null)
    {
        try
        {
            var query = new QueryBuilder(url);
            query.AddParameter(Constants.AjaxParameter, operation);
            if (parameters is not null && parameters.Count > 0)
            {
                foreach (KeyValuePair<string, string?> parameter in parameters)
                {
                    query.AddParameter(parameter.Key, parameter.Value);
                }
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            HttpResponseMessage response = await _client.GetAsync(query.Build());
            response.EnsureSuccessStatusCode();
            var contentType = response.Content.Headers.ContentType.ToString();
            var responseBody = await ReadResponseContentAsync(response);
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                try
                {
                    // Deserializza la risposta se Json
                    return JsonConvert.DeserializeObject<T>(responseBody);
                }
                catch (JsonException ex)
                {
                    throw new Exception($"Invalid Json result: {ex.Message}");
                }
            }
            throw new Exception($"Invalid content type: {contentType}");
        }
        catch (TimeoutException ex)
        {
            throw new Exception($"Timeout: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error reading data from website: {ex.Message}");
        }
    }

    private static async Task<string> ReadResponseContentAsync(HttpResponseMessage response)
    {
        // Usa StreamReader per forzare l'uso di UTF-8
        using Stream stream = await response.Content.ReadAsStreamAsync();
        using var reader = new StreamReader(stream, Encoding.UTF8); // UTF-8 senza virgolette
        return await reader.ReadToEndAsync();
    }

    //private static async Task<string> ReadResponseContentAsync(HttpResponseMessage response)
    //{
    //    // Usa StreamReader per forzare l'uso di UTF-8
    //    using (var stream = await response.Content.ReadAsStreamAsync())
    //    using (var reader = new StreamReader(stream, Encoding.UTF8))
    //    {
    //        return await reader.ReadToEndAsync();
    //    }
    //}

    public static async Task<Stream> GetFile(string url, Dictionary<string, string?>? parameters = null, CancellationToken cancellationToken = default)
    {
        try
        {
            var query = new QueryBuilder(url);
            if (parameters is not null && parameters.Count > 0)
            {
                foreach (KeyValuePair<string, string?> parameter in parameters)
                {
                    query.AddParameter(parameter.Key, parameter.Value);
                }
            }
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            HttpResponseMessage response = await _client.GetAsync(query.Build(), cancellationToken);
            response.EnsureSuccessStatusCode();
            //var contentType = response.Content.Headers.ContentType.ToString();
            return await response.Content.ReadAsStreamAsync();
        }
        catch (TimeoutException ex)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                throw new Exception("The request was canceled.", ex);
            }
            throw new Exception("Timeout: The request timed out.", ex);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error reading data from website: {ex.Message}");
        }
    }


    public static async Task<T?> GetServiceScraper<T>(string operation, Dictionary<string, string?>? parameters = null)
    {
        return await GetService<T>(Constants.ServiceScraperUrl, operation, parameters);
    }

    public static async Task<T?> GetServiceGeneric<T>(string operation, Dictionary<string, string?>? parameters = null)
    {
        return await GetService<T>(Constants.ServiceGenericUrl, operation, parameters);
    }

    public static async Task<T?> GetServiceMame<T>(string operation, Dictionary<string, string?>? parameters = null)
    {
        return await GetService<T>(Constants.ServiceMameUrl, operation, parameters);
    }
}
