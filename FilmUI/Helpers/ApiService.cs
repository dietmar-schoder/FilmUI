using FilmUI.DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace FilmUI.Helpers;

public interface IApiService
{
    Task<TRequest> GetAsyncOLD<TRequest>(string relativeUrl);
    Task<List<TRequest>> GetListAsyncOLD<TRequest>(string relativeUrl);
    Task PostAsyncOLD<TRequest>(string relativeUrl, TRequest body);
    Task PutAsyncOLD<TRequest>(string relativeUrl, TRequest body);
    Task DeleteAsyncOLD(string relativeUrl);




    Task<Result<TResponse>> GetAsync<TResponse>(string relativeUrl);
    Task<Result<TResponse>> PostAsync<TRequest, TResponse>(string relativeUrl, TRequest body);
    Task<Result<TResponse>> PutAsync<TRequest, TResponse>(string relativeUrl, TRequest body);
    Task<Result<TResponse>> DeleteAsync<TResponse>(string relativeUrl);
}

public class ApiService(
    HttpClient httpClient,
    ISessionService sessionService,
    AppConfig config,
    ISlackService slackService) : IApiService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ISessionService _sessionService = sessionService;
    private readonly ISlackService _slackService = slackService;
    private readonly string BackendUrl = config.BackendUrl;
    private readonly string FilmId = config.FilmId;

    private const int httpErrorStatusCodeRangeStart = 400;
    private const int httpErrorStatusCodeUnautorized = 401;

    public async Task PostAsyncOLD<T>(string relativeUrl, T body)
    {
        var url = $"{BackendUrl}{relativeUrl.Replace("[FILMID]", FilmId)}";
        var response = await _httpClient.PostAsJsonAsync(url, body);
        response.EnsureSuccessStatusCode();
    }

    public async Task<T> GetAsyncOLD<T>(string relativeUrl)
    {
        var url = $"{BackendUrl}{relativeUrl.Replace("[FILMID]", FilmId)}";
        var result = await _httpClient.GetFromJsonAsync<T>(url);
        return result;
    }

    public async Task<List<T>> GetListAsyncOLD<T>(string relativeUrl)
    {
        var url = $"{BackendUrl}{relativeUrl.Replace("[FILMID]", FilmId)}";
        var result = await _httpClient.GetFromJsonAsync<List<T>>(url);
        return result ?? [];
    }

    public async Task PutAsyncOLD<T>(string relativeUrl, T body)
    {
        var url = $"{BackendUrl}{relativeUrl.Replace("[FILMID]", FilmId)}";
        var response = await _httpClient.PutAsJsonAsync(url, body);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsyncOLD(string relativeUrl)
    {
        var url = $"{BackendUrl}{relativeUrl.Replace("[FILMID]", FilmId)}";
        _ = await _httpClient.DeleteAsync(url);
    }




    public Task<Result<TResponse>> GetAsync<TResponse>(string relativeUrl) =>
        SendAsync<TResponse>(HttpMethod.Get, relativeUrl);

    public Task<Result<TResponse>> PostAsync<TRequest, TResponse>(string relativeUrl, TRequest body) =>
        SendAsync<TResponse>(HttpMethod.Post, relativeUrl, body);

    public Task<Result<TResponse>> PutAsync<TRequest, TResponse>(string relativeUrl, TRequest body) =>
        SendAsync<TResponse>(HttpMethod.Put, relativeUrl, body);

    public Task<Result<TResponse>> DeleteAsync<TResponse>(string relativeUrl) =>
        SendAsync<TResponse>(HttpMethod.Delete, relativeUrl);

    private async Task<Result<TResponse>> SendAsync<TResponse>(
        HttpMethod method,
        string relativeUrl,
        object body = null)
    {
        var url = GetUrl();

        try
        {
            using var request = GetRequestMessage();
            SetBearerToken();
            using var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return GetSuccess(await response.Content.ReadFromJsonAsync<TResponse>());
            }
            return await GetServerErrorOrException(response);
        }
        catch (Exception ex)
        {
            return await HandledException(ex);
        }

        string GetUrl() =>
            $"{BackendUrl}{relativeUrl.Replace("[FILMID]", FilmId)}";

        HttpRequestMessage GetRequestMessage() =>
            new(method, url)
            {
                Content = body is not null ? JsonContent.Create(body) : null
            };

        void SetBearerToken()
        {
            if (!string.IsNullOrEmpty(_sessionService.Jwt))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _sessionService.Jwt);
            }
        }

        Result<TResponse> GetSuccess(TResponse data) =>
            Result<TResponse>.Success(data);

        async Task<Result<TResponse>> GetServerErrorOrException(HttpResponseMessage response)
        {
            var statusCode = (int)response.StatusCode;

            if (statusCode == httpErrorStatusCodeUnautorized)
            {
                return Result<TResponse>.Error("Unauthorized.");
            }

            if (statusCode >= httpErrorStatusCodeRangeStart
                && statusCode < httpErrorStatusCodeRangeStart + 100)
            {
                var error = await response.Content.ReadFromJsonAsync<ErrorDto>();
                return Result<TResponse>.Error(error?.Message ?? "Ooooops.");
            }

            return Result<TResponse>.Exception();
        }

        async Task<Result<TResponse>> HandledException(Exception ex)
        {
            var message = $"Http Error '{url}': {ex.Message}";
            Console.Error.WriteLine(message);
            await _slackService.NotifyAsync(message);
            return Result<TResponse>.Exception();
        }
    }
}
