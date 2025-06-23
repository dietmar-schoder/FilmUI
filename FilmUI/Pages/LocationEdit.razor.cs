using FilmUI.DTOs;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace FilmUI.Pages;

public partial class LocationEdit : ComponentBase
{
    [Parameter] public int Id { get; set; }

    [Inject] public IApiService Api { get; set; }
    [Inject] public NavigationManager Nav { get; set; }
    [Inject] IJSRuntime JS { get; set; }

    private string PageTitle => Id == 0 ? "Add New Location" : "Edit Location";
    private LocationDto location;

    protected override async Task OnInitializedAsync()
    {
        location = Id == 0
            ? new LocationDto(0, string.Empty)
            : await Api.GetAsync<LocationDto>($"/api/films/[FILMID]/locations/{Id}");
    }

    private void GoBack()
        => Nav.NavigateTo("/locations");

    private async Task Save()
    {
        if (location is null) return;

        if (Id == 0)
        {
            await Api.PostAsync($"/api/films/[FILMID]/locations", location);
        }
        else
        {
            await Api.PutAsync($"/api/films/[FILMID]/locations/{location.Id}", location);
        }

        Nav.NavigateTo("/locations");
    }

    private async Task ConfirmDelete()
    {
        await JS.InvokeVoidAsync("hideModalById", "deleteModal");
        await Api.DeleteAsync($"/api/films/[FILMID]/locations/{Id}");
        Nav.NavigateTo("/locations");
    }
}
