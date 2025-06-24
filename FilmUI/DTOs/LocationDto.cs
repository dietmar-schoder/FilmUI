namespace FilmUI.DTOs;

public class LocationDto(int id, string shortDescription)
{
    public int Id { get; set; } = id;
    public string ShortDescription { get; set; } = shortDescription;
}

public class LocationDetailsDto : BaseDataWithShotsDto { }
