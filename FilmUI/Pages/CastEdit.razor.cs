using FilmUI.DTOs;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace FilmUI.Pages;

public partial class CastEdit : ComponentBase
{
    [Parameter] public int Id { get; set; }

    [Inject] public IApiService Api { get; set; }
    [Inject] public NavigationManager Nav { get; set; }
    [Inject] IJSRuntime JS { get; set; }

    private string PageTitle => Id == 0 ? "Add New Cast Member" : "Edit Cast Member";
    private CastDto cast;

    protected override async Task OnInitializedAsync()
    {
        cast = Id == 0
            ? new CastDto(0, string.Empty, string.Empty)
            : await Api.GetAsync<CastDto>($"/api/films/[FILMID]/casts/{Id}");
    }
    private void GoBack()
        => Nav.NavigateTo("/cast");

    private async Task Save()
    {
        if (cast is null) return;

        if (Id == 0)
        {
            await Api.PostAsync($"/api/films/[FILMID]/casts", cast);
        }
        else
        {
            await Api.PutAsync($"/api/films/[FILMID]/casts/{cast.Id}", cast);
        }

        Nav.NavigateTo("/cast");
    }

    private async Task ConfirmDelete()
    {
        await JS.InvokeVoidAsync("hideModalById", "deleteModal");
        await Api.DeleteAsync($"/api/films/[FILMID]/casts/{Id}");
        Nav.NavigateTo("/cast");
    }
}
