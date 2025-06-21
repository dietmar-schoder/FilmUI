using System.Net.Http.Json;

namespace FilmUI.Helpers;

public interface IApiService
{
    Task<T> GetAsync<T>(string relativeUrl);
    Task<List<T>> GetListAsync<T>(string relativeUrl);
    Task PutAsync<T>(string relativeUrl, T body);
}

public class ApiService(HttpClient httpClient, AppConfig config) : IApiService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly string BackendUrl = config.BackendUrl;
    private readonly string FilmId = config.FilmId;

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
        var response = await _httpClient.PutAsJsonAsync(GetUrl(relativeUrl), body);
        response.EnsureSuccessStatusCode();
    }

    private string GetUrl(string relativeUrl)
        => $"{BackendUrl}{relativeUrl.Replace("[FILMID]", FilmId)}";

    private static string Error(string url, string errorMessage)
        => $"Error fetching data from '{url}': {errorMessage}";
}
