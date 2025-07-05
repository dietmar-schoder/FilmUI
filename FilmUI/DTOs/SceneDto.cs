namespace FilmUI.DTOs;

public class SceneDto(int id, string number, string shortDescription, string notes, int progress)
{
    public int Id { get; set; } = id;
    public string Number { get; set; } = number;
    public string ShortDescription { get; set; } = shortDescription;
    public string Notes { get; set; } = notes;
    public int Progress { get; set; } = progress;

    public SceneDto() : this(0, string.Empty, string.Empty, string.Empty, 0) { }
}

public class SceneDetailsDto : BaseDtoWithShotsDto
{
    public string Number { get; set; }
    public int Progress { get; set; }
}
