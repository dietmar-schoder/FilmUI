using FilmUI.DTOs;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FilmUI.Pages;

public partial class CastEdit : ComponentBase
{
    [Parameter] public int Id { get; set; }

    [Inject] public IApiService Api { get; set; }
    [Inject] public NavigationManager Nav { get; set; }

    protected CastDto cast;

    protected override async Task OnInitializedAsync()
    {
        cast = await Api.GetAsync<CastDto>($"/api/films/[FILMID]/casts/{Id}");
    }
    private void GoBack() => Nav.NavigateTo("/cast");

    protected async Task Save()
    {
        if (cast is null) return;

        await Api.PutAsync($"/api/films/[FILMID]/casts/{cast.Id}", cast);
        Nav.NavigateTo("/cast");
    }
}
