using System.Net.Http.Json;

namespace FilmUI.Helpers;

public interface IApiService
{
    Task<T> GetAsync<T>(string relativeUrl);
    Task<List<T>> GetListAsync<T>(string relativeUrl);
    Task PostAsync<T>(string relativeUrl, T body);
    Task PutAsync<T>(string relativeUrl, T body);
    Task DeleteAsync(string relativeUrl);
}

public class ApiService(HttpClient httpClient, AppConfig config) : IApiService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly string BackendUrl = config.BackendUrl;
    private readonly string FilmId = config.FilmId;

    public async Task PostAsync<T>(string relativeUrl, T body)
    {
        var url = GetUrl(relativeUrl);

        try
        {
            var response = await _httpClient.PostAsJsonAsync(url, body);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(Error(url, ex.Message));
        }
    }

    public async Task<T> GetAsync<T>(string relativeUrl)
    {
        var url = GetUrl(relativeUrl);

        try
        {
            var result = await _httpClient.GetFromJsonAsync<T>(url);
            return result;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(Error(url, ex.Message));
            return default;
        }
    }

    public async Task<List<T>> GetListAsync<T>(string relativeUrl)
    {
        var url = GetUrl(relativeUrl);

        try
        {
            var result = await _httpClient.GetFromJsonAsync<List<T>>(url);
            return result ?? [];
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(Error(url, ex.Message));
            return [];
        }
    }

    public async Task PutAsync<T>(string relativeUrl, T body)
    {
        var url = GetUrl(relativeUrl);

        try
        {
            var response = await _httpClient.PutAsJsonAsync(GetUrl(relativeUrl), body);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(Error(url, ex.Message));
        }
    }

    public async Task DeleteAsync(string relativeUrl)
    {
        var url = GetUrl(relativeUrl);

        try
        {
            var response = await _httpClient.DeleteAsync(url);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(Error(url, ex.Message));
        }
    }

    private string GetUrl(string relativeUrl)
        => $"{BackendUrl}{relativeUrl.Replace("[FILMID]", FilmId)}";

    private static string Error(string url, string errorMessage)
        => $"Error fetching data from '{url}': {errorMessage}";
}
