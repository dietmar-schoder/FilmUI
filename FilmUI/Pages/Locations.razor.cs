using FilmUI.DTOs;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FilmUI.Pages;

public partial class Locations : ComponentBase
{
    private List<LocationDto> locations;

    [Inject]
    public IApiService Api { get; set; }

    protected override async Task OnInitializedAsync()
    {
        locations = await Api.GetListAsync<LocationDto>("/api/films/[FILMID]/locations");
    }
}
