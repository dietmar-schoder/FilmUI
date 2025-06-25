using FilmUI.Constants;
using FilmUI.DTOs;
using FilmUI.Shared;

namespace FilmUI.Pages;

public partial class CastEdit : EditPageBaseInt<CastDto>
{
    public override PageKey Page => PageKey.Cast;
}
