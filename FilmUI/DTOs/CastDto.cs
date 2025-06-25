namespace FilmUI.DTOs;

public class CastDto(int id, string role, string actor)
{
    public int Id { get; set; } = id;
    public string Role { get; set; } = role;
    public string Actor { get; set; } = actor;

    public CastDto() : this(0, string.Empty, string.Empty) { }
}

public class CastDetailsDto : BaseDataWithShotsDto
{
    public string Role { get; init; }
    public string Actor { get; init; }
}
