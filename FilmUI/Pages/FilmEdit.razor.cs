using FilmUI.Constants;
using FilmUI.DTOs;
using FilmUI.Shared;

namespace FilmUI.Pages;

public partial class FilmEdit : EditPageBaseGuid<FilmDto>
{
    public override PageKey Page => PageKey.Films;
}
