using FilmUI.DTOs;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FilmUI.Pages;

public partial class Casts : ComponentBase
{
    private List<CastDto>? casts;

    [Inject]
    public HttpClient Http { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        casts = await Http.GetListOrEmptyAsync<CastDto>("/api/films/{filmId}/casts");
    }
}
