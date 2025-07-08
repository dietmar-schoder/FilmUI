using FilmUI.DTOs;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FilmUI.Pages;

public partial class Register
{
    [Inject] protected IApiService Api { get; set; }
    [Inject] protected NavigationManager Nav { get; set; }

    private readonly LoginDto registerDto = new();

    private async Task RegisterUser()
    {
        await Api.PostAsync("/api/users/register", registerDto);
        if (true)
        {
            Nav.NavigateTo("/login");
        }
    }
}
