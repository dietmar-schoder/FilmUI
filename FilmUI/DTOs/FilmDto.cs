namespace FilmUI.DTOs;

public class FilmDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public FilmDto() { }

    public FilmDto(Guid id, string title)
    {
        Id = id;
        Title = title;
    }
}
