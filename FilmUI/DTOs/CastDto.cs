namespace FilmUI.DTOs;

public record CastDto(int Id, string Role, string Actor);

public record CastShotsDto(int Id, string Role, string Actor, string ShootingTime, List<ShotDetailsDto> Shots)
{
    public int NumberOfShots => Shots.Count;
}
