namespace FilmUI.DTOs;

public class LocationDto(int id, string shortDescription, string notes, int progress)
{
    public int Id { get; set; } = id;
    public string ShortDescription { get; set; } = shortDescription;
    public string Notes { get; set; } = notes;
    public int Progress { get; set; } = progress;

    public LocationDto() : this(0, string.Empty, string.Empty, 0) { }
}

public class LocationDetailsDto : BaseDtoWithShotsDto
{
    public int Progress { get; set; }
}
