namespace FilmUI.Constants;

public static class PageMappings
{
    public static readonly Dictionary<PageKey, string> ApiEndpoints = new()
    {
        [PageKey.Films] = "/api/films",
        [PageKey.Cast] = "/api/films/[FILMID]/casts",
        [PageKey.CastShots] = "/api/films/[FILMID]/casts-with-shots",
        [PageKey.Gear] = "/api/films/[FILMID]/gears",
        [PageKey.GearShots] = "/api/films/[FILMID]/gears-with-shots",
        [PageKey.Scenes] = "/api/films/[FILMID]/scenes",
        [PageKey.Shots] = "/api/films/[FILMID]/shots",
        [PageKey.ScenesShots] = "/api/films/[FILMID]/scenes-with-shots",
        [PageKey.Locations] = "/api/films/[FILMID]/locations",
        [PageKey.LocationsShots] = "/api/films/[FILMID]/locations-with-shots",
        [PageKey.ShootingDays] = "/api/films/[FILMID]/shootingdays",
        [PageKey.ShootingDaysShots] = "/api/films/[FILMID]/shootingdays-with-shots",
        [PageKey.Calendar] = "/api/films/[FILMID]/shootingdays",
    };

    public static readonly Dictionary<PageKey, string> ListRoutes = new()
    {
        [PageKey.Films] = "/films",
        [PageKey.Cast] = "/cast",
        [PageKey.Gear] = "/gear",
        [PageKey.Scenes] = "/scenes",
        [PageKey.Shots] = "/shots",
        [PageKey.Locations] = "/locations",
        [PageKey.ShootingDays] = "/shootingdays",
        [PageKey.Calendar] = "/shootingdays",
    };

    public static readonly Dictionary<PageKey, string> EditRoutes = new()
    {
        [PageKey.Films] = "/film/edit",
        [PageKey.Cast] = "/cast/edit",
        [PageKey.Gear] = "/gear/edit",
        [PageKey.Scenes] = "/scene/edit",
        [PageKey.Shots] = "/shot/edit",
        [PageKey.Locations] = "/location/edit",
        [PageKey.ShootingDays] = "/shootingday/edit",
        [PageKey.Calendar] = "/shootingday/edit",
    };

    public static readonly Dictionary<PageKey, string> ListTitles = new()
    {
        [PageKey.Films] = "Films",
        [PageKey.Cast] = "Cast",
        [PageKey.CastShots] = "Cast + Shots",
        [PageKey.Gear] = "Gear",
        [PageKey.GearShots] = "Gear + Shots",
        [PageKey.Scenes] = "Scenes",
        [PageKey.Shots] = "Shots",
        [PageKey.ScenesShots] = "Scenes + Shots",
        [PageKey.Locations] = "Locations",
        [PageKey.LocationsShots] = "Locations + Shots",
        [PageKey.ShootingDays] = "Shooting Days",
        [PageKey.ShootingDaysShots] = "Shooting Days + Shots",
        [PageKey.Calendar] = "Calendar",
    };
}
