namespace FilmUI.DTOs;

public class LocationDto(int id, string shortDescription)
{
    public int Id { get; set; } = id;
    public string ShortDescription { get; set; } = shortDescription;
    public LocationDto() : this(0, string.Empty) { }
}

public class LocationDetailsDto : BaseDtoWithShotsDto { }
