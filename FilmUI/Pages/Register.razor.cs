using FilmUI.Constants;
using FilmUI.DTOs;
using FilmUI.Shared;

namespace FilmUI.Pages;

public partial class Register : ApiPageBase
{
    private readonly LoginDto registerDto = new();

    protected override PageKey Page => PageKey.Register;

    private async Task RegisterUser()
    {
        var userDto = await CallApi(() => Api.PostAsync<LoginDto, UserDto>(ApiEndpoint, registerDto));
        if (userDto is null) return;

        Navigation.NavigateTo(userDto.EmailIsConfirmed
            ? "/login"
            : $"/confirm-email?email={Uri.EscapeDataString(userDto.Email)}");
    }
}
