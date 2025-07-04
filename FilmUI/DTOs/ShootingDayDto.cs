namespace FilmUI.DTOs;

public class ShootingDayDto(
    int id,
    string number,
    string shortDescription,
    DateTime? shootingDate,
    string shootingTime)
{
    public int Id { get; set; } = id;
    public string Number { get; set; } = number;
    public string ShortDescription { get; set; } = shortDescription;
    public DateTime? ShootingDate { get; set; } = shootingDate;
    public string ShootingTime { get; set; } = shootingTime;

    public ShootingDayDto() : this(0, string.Empty, string.Empty, null, string.Empty) { }
}

public class ShootingDayDetailsDto : BaseDtoWithShotsDto
{
    public string Number { get; init; }
    public DateTime? ShootingDate { get; set; }
}
