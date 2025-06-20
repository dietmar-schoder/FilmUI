using FilmUI.DTOs;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FilmUI.Pages;

public partial class CastsShots : ComponentBase
{
    private List<CastShotsDto> castsShots;

    [Inject]
    public IApiService Api { get; set; }

    protected override async Task OnInitializedAsync()
    {
        castsShots = await Api.GetListAsync<CastShotsDto>("/api/films/{filmId}/casts-with-shots");
    }
}
