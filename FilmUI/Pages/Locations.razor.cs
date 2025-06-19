using FilmUI.DTOs;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FilmUI.Pages;

public partial class Locations : ComponentBase
{
    private List<LocationDto>? locations;

    [Inject]
    public HttpClient Http { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        locations = await Http.GetListOrEmptyAsync<LocationDto>("/api/films/{filmId}/locations");
    }
}
