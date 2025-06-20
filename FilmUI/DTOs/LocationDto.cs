namespace FilmUI.DTOs;

public record LocationDto(int Id, string ShortDescription);

public record LocationShotsDto(int Id, string ShortDescription, string ShootingTime, List<ShotDto> Shots)
{
    public int NumberOfShots => Shots.Count;
}
