namespace FilmUI.DTOs;

public class FilmDto(Guid id, string title)
{
    public Guid Id { get; set; } = id;
    public string Title { get; set; } = title;

    public FilmDto() : this(Guid.Empty, string.Empty) { }
}
