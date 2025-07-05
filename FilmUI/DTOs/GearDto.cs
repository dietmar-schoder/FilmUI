namespace FilmUI.DTOs;

public class GearDto(int id, string shortDescription, string notes, int progress)
{
    public int Id { get; set; } = id;
    public string ShortDescription { get; set; } = shortDescription;
    public string Notes { get; set; } = notes;
    public int Progress { get; set; } = progress;

    public GearDto() : this(0, string.Empty, string.Empty, 0) { }
}

public class GearDetailsDto : BaseDtoWithShotsDto
{
    public int Progress { get; set; }
}
