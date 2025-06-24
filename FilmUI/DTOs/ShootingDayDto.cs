namespace FilmUI.DTOs;

public record ShootingDayDto(int Id, string Number, string ShortDescription, string ShootingTime);

public class ShootingDayDetailsDto : BaseDataWithShotsDto
{
    public string Number { get; init; }
}
