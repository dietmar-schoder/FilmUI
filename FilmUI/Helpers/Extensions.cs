using System.Net.Http.Json;

namespace FilmUI.Helpers;

public static class Extensions
{
    private const string backendUrl = "http://localhost:7082";
    private const string filmId = "C82FCBFB-2F23-40B2-A6AF-AEA8A608504D";
    public static async Task<List<T>> GetListOrEmptyAsync<T>(this HttpClient httpClient, string url)
    {
        url = $"{backendUrl}{url.Replace("{filmId}", filmId)}";

        try
        {
            var result = await httpClient.GetFromJsonAsync<List<T>>(url);
            return result ?? [];
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error fetching list from '{url}': {ex.Message}");
            return [];
        }
    }
}
