namespace FilmUI.DTOs;

public class ShotDto(
    int id,
    string number,
    string shortDescription,
    string location,
    string shootingDay,
    string shootingTime,
    int shootingTimeMinutes)
{
    public int Id { get; set; } = id;
    public string Number { get; set; } = number;
    public string ShortDescription { get; set; } = shortDescription;
    public string Location { get; set; } = location;
    public string ShootingDay { get; set; } = shootingDay;
    public string ShootingTime { get; set; } = shootingTime;
    public int ShootingTimeMinutes { get; set; } = shootingTimeMinutes;
    public int? SceneId { get; set; }
    public int? LocationId { get; set; }
    public int? ShootingDayId { get; set; }
    public List<LocationDto> AllLocations { get; set; } = [];
    public List<SceneDto> AllScenes { get; set; } = [];
    public List<ShootingDayDto> AllShootingDays { get; set; } = [];

    public ShotDto() : this(0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0) { }
}

public record ShotDetailsDto(
    int Id,
    string ShortDescription,
    string Location,
    string ShootingDay,
    string ShootingTime,
    List<CastDto> Casts)
{
    public string Roles => Casts?.Count > 0
        ? string.Join(", ", Casts.Select(c => c.Role))
        : null;
}
