namespace FilmUI.DTOs;

public class GearDto(int id, string shortDescription, string notes)
{
    public int Id { get; set; } = id;
    public string ShortDescription { get; set; } = shortDescription;
    public string Notes { get; set; } = notes;

    public GearDto() : this(0, string.Empty, string.Empty) { }
}

public class GearDetailsDto : BaseDataWithShotsDto
{
    public string Notes { get; init; }
}
