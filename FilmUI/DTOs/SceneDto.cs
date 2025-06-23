namespace FilmUI.DTOs;

public record SceneDto(int Id, string Number, string ShortDescription);

public record SceneShotsDto(int Id, string Number, string ShortDescription, string ShootingTime, List<ShotDetailsDto> Shots)
{
    public string Roles => Shots?
        .SelectMany(shot => shot.Casts ?? [])
        .Select(cast => cast.Role)
        .Where(role => !string.IsNullOrWhiteSpace(role))
        .Distinct()
        .OrderBy(role => role)
        .DefaultIfEmpty()
        .Aggregate((acc, next) => acc + ", " + next);

    public int NumberOfShots => Shots.Count;
}
