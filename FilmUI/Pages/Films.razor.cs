using FilmUI.Constants;
using FilmUI.DTOs;
using FilmUI.Shared;

namespace FilmUI.Pages;

public partial class Films : ListPageBase<FilmDto>
{
    protected override PageKey Page => PageKey.Films;

    private async Task OnSelectFilm(FilmDto film)
    {
        await Session.SetSelectedFilm(film);
        StateHasChanged();
    }
}
