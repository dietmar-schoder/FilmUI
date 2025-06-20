using System.Net.Http.Json;

namespace FilmUI.Helpers;

public interface IApiService
{
    Task<List<T>> GetListAsync<T>(string relativeUrl);
}

public class ApiService(HttpClient http) : IApiService
{
    private readonly HttpClient _http = http;
    private const string BackendUrl = "http://localhost:7082";
    private const string FilmId = "C82FCBFB-2F23-40B2-A6AF-AEA8A608504D";

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
