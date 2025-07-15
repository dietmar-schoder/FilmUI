using FilmUI.Constants;
using FilmUI.DTOs;
using FilmUI.Shared;

namespace FilmUI.Pages;

public partial class Login : ApiPageBase
{
    private readonly LoginDto loginDto = new();

    protected override PageKey Page => PageKey.Login;

    protected override void OnInitialized() { }

    private async Task LoginUser()
    {
        var userDto = await CallApi(() => Api.PostAsync<LoginDto, UserDto>(ApiEndpoint, loginDto));
        if (userDto is null) return;

        if (!userDto.EmailIsConfirmed)
        {
            Navigation.NavigateTo($"/confirm-email?email={Uri.EscapeDataString(userDto.Email)}");
            return;
        }

        Session.SetUser(userDto);

        Navigation.NavigateTo("/films");
    }
}
