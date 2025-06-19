using FilmUI.DTOs;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FilmUI.Pages;

public partial class ShootingDays : ComponentBase
{
    private List<ShootingDayDto>? shootingDays;

    [Inject]
    public HttpClient Http { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        shootingDays = await Http.GetListOrEmptyAsync<ShootingDayDto>("/api/films/{filmId}/shootingdays");
    }
}
