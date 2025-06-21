using FilmUI.DTOs;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FilmUI.Pages;

public partial class ShootingDays : ComponentBase
{
    private List<ShootingDayDto> shootingDays;

    [Inject]
    public IApiService Api { get; set; }

    protected override async Task OnInitializedAsync()
    {
        shootingDays = await Api.GetListAsync<ShootingDayDto>("/api/films/[FILMID]/shootingdays");
    }
}
