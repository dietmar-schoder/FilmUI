namespace FilmUI.DTOs;

public class FilmDto(Guid id, string title, string notes, int progress)
{
    public Guid Id { get; set; } = id;
    public string Title { get; set; } = title;
    public string Notes { get; set; } = notes;
    public int Progress { get; set; } = progress;

    public FilmDto() : this(Guid.Empty, string.Empty, string.Empty, 0) { }
}
