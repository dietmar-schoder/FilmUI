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

public class CastDetailsDto : BaseDataWithShotsDto
{
    public string Role { get; init; }
    public string Actor { get; init; }
}
