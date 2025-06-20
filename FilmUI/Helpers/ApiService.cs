using System.Net.Http.Json;

namespace FilmUI.Helpers;

public interface IApiService
{
    Task<List<T>> GetListAsync<T>(string relativeUrl);
}

public class ApiService(HttpClient http, AppConfig config) : IApiService
{
    private readonly HttpClient _http = http;
    private readonly string BackendUrl = config.BackendUrl;
    private readonly string FilmId = config.FilmId;

    public async Task<List<T>> GetListAsync<T>(string relativeUrl)
    {
        var url = $"{BackendUrl}{relativeUrl.Replace("{filmId}", FilmId)}";

        try
        {
            var result = await _http.GetFromJsonAsync<List<T>>(url);
            return result ?? [];
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error fetching data from '{url}': {ex.Message}");
            return [];
        }
    }
}
