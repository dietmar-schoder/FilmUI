using FilmUI.DTOs;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FilmUI.Pages;

public partial class Shots : ComponentBase
{
    private List<ShotDto>? shots;

    [Inject]
    public HttpClient Http { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        shots = await Http.GetListOrEmptyAsync<ShotDto>("/api/films/{filmId}/shots");
    }
}
