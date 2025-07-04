using FilmUI.DTOs;

namespace FilmUI.Helpers;

public static class Extensions
{
    public static string ShotsDuration(this IEnumerable<BaseDtoWithShotsDto> dto)
    {
        if (dto is null || !dto.Any()) return string.Empty;

        return ShotDuration(dto);

        static string ShotDuration(IEnumerable<BaseDtoWithShotsDto> dto) =>
            dto.Sum(dto => dto.DurationSeconds).ToHoursMinutesSeconds();
    }

    public static string ShootingsDuration(this IEnumerable<BaseDtoWithShotsDto> dto)
    {
        if (dto is null || !dto.Any()) return string.Empty;

        var numberOfShots = dto.Sum(dto => dto.NumberOfShots);
        return $"{numberOfShots} Shot{(numberOfShots > 1 ? "s" : string.Empty)}: {ShootingDuration(dto)}";

        static string ShootingDuration(IEnumerable<BaseDtoWithShotsDto> dto) =>
            dto.Sum(dto => dto.ShootingTimeMinutes).ToWeeksDaysHoursMinutes();
    }

    public static string ToHoursMinutesSeconds(this int totalSeconds)
    {
        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = totalSeconds % 60;
        return $"{hours}:{minutes:D2}:{seconds:D2}";
    }

    public static string ToWeeksDaysHoursMinutes(this int totalMinutes)
    {
        if (totalMinutes <= 0) return null;

        const int minutesPerHour = 60;
        const int hoursPerDay = 8;
        const int daysPerWeek = 5;

        int minutesPerDay = hoursPerDay * minutesPerHour;
        int minutesPerWeek = daysPerWeek * minutesPerDay;

        int weeks = totalMinutes / minutesPerWeek;
        int remainderAfterWeeks = totalMinutes % minutesPerWeek;

        int days = remainderAfterWeeks / minutesPerDay;
        int remainderAfterDays = remainderAfterWeeks % minutesPerDay;

        int hours = remainderAfterDays / minutesPerHour;
        int minutes = remainderAfterDays % minutesPerHour;

        var parts = new List<string>();

        if (weeks > 0) parts.Add($"{weeks}w");
        if (days > 0) parts.Add($"{days}d");
        if (hours > 0) parts.Add($"{hours}h");
        if (minutes > 0) parts.Add($"{minutes}min");

        return string.Join(" ", parts);
    }
}
