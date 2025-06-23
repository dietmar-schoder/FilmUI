using FilmUI.DTOs;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FilmUI.Pages;

public partial class Films : ComponentBase
{
    private List<FilmDto> films;

    [Inject]
    public IApiService Api { get; set; }

    protected override async Task OnInitializedAsync()
    {
        films = await Api.GetListAsync<FilmDto>("/api/films");
    }
}
