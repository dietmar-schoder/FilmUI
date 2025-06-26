using FilmUI.Constants;
using FilmUI.DTOs;
using FilmUI.Shared;

namespace FilmUI.Pages;

public partial class ShotEdit : EditPageBaseInt<ShotDto>
{
    private List<LocationDto> Locations = [];
    private List<SceneDto> Scenes = [];
    private List<ShootingDayDto> ShootingDays = [];

    public override PageKey Page => PageKey.Shots;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        Locations = await Api.GetListAsync<LocationDto>(PageMappings.ApiEndpoints[PageKey.Locations]);
        Scenes = await Api.GetListAsync<SceneDto>(PageMappings.ApiEndpoints[PageKey.Scenes]);
        ShootingDays = await Api.GetListAsync<ShootingDayDto>(PageMappings.ApiEndpoints[PageKey.ShootingDays]);
    }

    protected override void InitNewItem()
    {
        Item.ShootingTimeMinutes = 60;
    }
}
