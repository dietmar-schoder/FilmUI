using FilmUI.DTOs;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FilmUI.Pages;

public partial class ShootingDaysShots : ComponentBase
{
    private List<ShootingDayShotsDto> shootingDays;

    [Inject]
    public IApiService Api { get; set; }

    protected override async Task OnInitializedAsync()
    {
        shootingDays = await Api.GetListAsync<ShootingDayShotsDto>("/api/films/{filmId}/shootingdays");
    }
}
