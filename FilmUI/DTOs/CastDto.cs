namespace FilmUI.DTOs;

public class CastDto
{
    public int Id { get; set; }
    public string Role { get; set; }
    public string Actor { get; set; }

    public CastDto() { }

    public CastDto(int id, string role, string actor)
    {
        Id = id;
        Role = role;
        Actor = actor;
    }
}

public record CastShotsDto(int Id, string Role, string Actor, string ShootingTime, List<ShotDetailsDto> Shots)
{
    public int NumberOfShots => Shots.Count;
}
