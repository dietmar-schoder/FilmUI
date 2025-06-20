using FilmUI.DTOs;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FilmUI.Pages;

public partial class LocationsShots : ComponentBase
{
    private List<LocationShotsDto> locationsShots;

    [Inject]
    public IApiService Api { get; set; }

    protected override async Task OnInitializedAsync()
    {
        locationsShots = await Api.GetListAsync<LocationShotsDto>("/api/films/{filmId}/locations-with-shots");
    }
}
