namespace FilmUI.DTOs;

public class SceneDto(int id, string number, string shortDescription)
{
    public int Id { get; set; } = id;
    public string Number { get; set; } = number;
    public string ShortDescription { get; set; } = shortDescription;

    public SceneDto() : this(0, string.Empty, string.Empty) { }
}

public class SceneDetailsDto : BaseDataWithShotsDto
{
    public string Number { get; set; }
}
