namespace FilmUI.DTOs;

public record ShotDto(
    int Id,
    string ShortDescription,
    string Location,
    string ShootingDay,
    string ShootingTime);

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
