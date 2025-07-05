namespace FilmUI.DTOs;

public class ShootingDayDto(
    int id,
    string number,
    string shortDescription,
    string notes,
    DateTime? shootingDate,
    string shootingTime,
    int progress)
{
    public int Id { get; set; } = id;
    public string Number { get; set; } = number;
    public string ShortDescription { get; set; } = shortDescription;
    public string Notes { get; set; } = notes;
    public DateTime? ShootingDate { get; set; } = shootingDate;
    public string ShootingTime { get; set; } = shootingTime;
    public int Progress { get; set; } = progress;

    public ShootingDayDto() : this(0, string.Empty, string.Empty, string.Empty, null, string.Empty, 0) { }
}

public class ShootingDayDetailsDto : BaseDtoWithShotsDto
{
    public string Number { get; init; }
    public DateTime? ShootingDate { get; set; }
    public int Progress { get; set; }
}
