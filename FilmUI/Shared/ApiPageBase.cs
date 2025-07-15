using FilmUI.Constants;
using FilmUI.DTOs;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FilmUI.Shared;

public class ApiPageBase : ComponentBase
{
    [Inject] protected ISessionService Session { get; set; }
    [Inject] protected IApiService Api { get; set; }
    [Inject] protected NavigationManager Navigation { get; set; }

    protected string ErrorMessage { get; set; }
    protected virtual PageKey Page { get; }
    protected virtual string ApiEndpoint => PageMappings.ApiEndpoints[Page];

    protected override void OnInitialized()
    {
        if (!Session.IsLoggedIn)
        {
            Navigation.NavigateTo("/register");
            return;
        }

        if (!Session.HasFilmSelected && Page != PageKey.Films)
        {
            Navigation.NavigateTo("/films");
            return;
        }
    }

    protected async Task<TResponse> CallApi<TResponse>(Func<Task<Result<TResponse>>> apiCall)
    {
        var result = await apiCall();
        ErrorMessage = result.ErrorMessage;
        //if (result.IsException) { Nav.NavigateTo("/exception"); }
        return result.IsSuccess ? result.Data : default;
    }
}
