using FilmUI.DTOs;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FilmUI.Pages;

public partial class Casts : ComponentBase
{
    private List<CastDto> casts;

    [Inject]
    public IApiService Api { get; set; }

    protected override async Task OnInitializedAsync()
    {
        casts = await Api.GetListAsync<CastDto>("/api/films/{filmId}/casts");
    }
}
