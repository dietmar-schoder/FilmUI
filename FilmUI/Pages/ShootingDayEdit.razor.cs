using FilmUI.Constants;
using FilmUI.DTOs;
using FilmUI.Shared;

namespace FilmUI.Pages;

public partial class ShootingDayEdit : EditPageBaseInt<ShootingDayDto>
{
    public override PageKey Page => PageKey.ShootingDays;

    protected override async Task InitNewItemAsync()
    {
        Item.ShootingDate = DateTime.Today;
        await Task.CompletedTask;
    }
}
