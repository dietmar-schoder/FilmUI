using FilmUI.DTOs;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FilmUI.Pages;

public partial class ScenesShots : ComponentBase
{
    private List<ShotDto> shots;

    [Inject]
    public IApiService Api { get; set; }

    protected override async Task OnInitializedAsync()
    {
        shots = await Api.GetListAsync<ShotDto>("/api/films/[FILMID]/shots");
    }
}
