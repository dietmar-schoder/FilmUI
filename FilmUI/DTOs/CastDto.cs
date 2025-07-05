namespace FilmUI.DTOs;

public class CastDto(int id, string role, string actor, string notes, int progress)
{
    public int Id { get; set; } = id;
    public string Role { get; set; } = role;
    public string Actor { get; set; } = actor;
    public string Notes { get; set; } = notes;
    public int Progress { get; set; } = progress;

    public CastDto() : this(0, string.Empty, string.Empty, string.Empty, 0) { }
}

public class CastDetailsDto : BaseDtoWithShotsDto
{
    public string Role { get; init; }
    public string Actor { get; init; }
    public int Progress { get; set; }
}
