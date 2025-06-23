namespace FilmUI.DTOs;

public class LocationDto(int id, string shortDescription)
{
    public int Id { get; set; } = id;
    public string ShortDescription { get; set; } = shortDescription;
}

public record LocationShotsDto(int Id, string ShortDescription, string ShootingTime, List<ShotDto> Shots)
{
    public int NumberOfShots => Shots.Count;
}
