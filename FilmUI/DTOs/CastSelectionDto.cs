namespace FilmUI.DTOs;

public class CastSelectionDto
{
    public int CastId { get; set; }
    public string Actor { get; set; }
    public string Role { get; set; }
    public bool IsSelected { get; set; }
}
