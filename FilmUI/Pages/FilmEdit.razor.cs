using FilmUI.DTOs;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace FilmUI.Pages;

public partial class FilmEdit : ComponentBase
{
    [Parameter] public Guid Id { get; set; }

    [Inject] public IApiService Api { get; set; }
    [Inject] public NavigationManager Nav { get; set; }
    [Inject] IJSRuntime JS { get; set; }

    private string PageTitle => Id == Guid.Empty ? "Add New Film" : "Edit Film";
    private FilmDto film;

    protected override async Task OnInitializedAsync()
    {
        film = Id == Guid.Empty
            ? new FilmDto(Guid.Empty, string.Empty)
            : await Api.GetAsync<FilmDto>($"/api/films/{Id}");
    }
    private void GoBack()
        => Nav.NavigateTo("/films");

    private async Task Save()
    {
        if (film is null) return;

        if (Id == Guid.Empty)
        {
            await Api.PostAsync($"/api/films", film);
        }
        else
        {
            await Api.PutAsync($"/api/films/{film.Id}", film);
        }

        Nav.NavigateTo("/films");
    }

    private async Task ConfirmDelete()
    {
        await JS.InvokeVoidAsync("hideModalById", "deleteModal");
        //await Api.DeleteAsync($"/api/films/{Id}");
        Nav.NavigateTo("/films");
    }
}
