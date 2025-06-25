using FilmUI.Constants;
using FilmUI.DTOs;
using FilmUI.Shared;

namespace FilmUI.Pages;

public partial class LocationEdit : EditPageBaseInt<LocationDto>
{
    public override PageKey Page => PageKey.Locations;
}
