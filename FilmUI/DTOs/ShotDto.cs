namespace FilmUI.DTOs;

public record ShotDto(int Id, string Title, string ShootingTime);

public record ShotDetailsDto(int Id, string Title, string Location, string ShootingTime, List<CastDto> Casts)
{
    public string Roles => Casts?.Count > 0
        ? string.Join(", ", Casts.Select(c => c.Role))
        : null;
}
