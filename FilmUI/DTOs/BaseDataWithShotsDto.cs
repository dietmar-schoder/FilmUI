namespace FilmUI.DTOs;

public abstract class BaseDataWithShotsDto
{
    public int Id { get; init; }
    public string ShortDescription { get; init; }
    public string ShootingTime { get; init; }
    public List<ShotDetailsDto> Shots { get; init; }

    public string Roles => Shots?
        .SelectMany(shot => shot.Casts ?? [])
        .Select(cast => cast.Role)
        .Where(role => !string.IsNullOrWhiteSpace(role))
        .Distinct()
        .OrderBy(role => role)
        .DefaultIfEmpty()
        .Aggregate((acc, next) => acc + ", " + next);

    public bool HasShots => Shots is not null && Shots.Count > 0;

    public int NumberOfShots => Shots?.Count ?? 0;

    public string ShotsShootingTime =>
        HasShots ? $"{NumberOfShots} Shot{(Shots.Count > 1 ? "s" : string.Empty)}: {ShootingTime}" : string.Empty;
}
