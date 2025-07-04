using FilmUI.DTOs;

namespace FilmUI.Helpers;

public static class Extensions
{
    public static string ShotsShootingTime(this IEnumerable<BaseDtoWithShotsDto> dto)
    {
        if (dto is null || !dto.Any()) return string.Empty;

        var numberOfShots = dto.Sum(dto => dto.NumberOfShots);
        return $"{numberOfShots} Shot{(numberOfShots > 1 ? "s" : string.Empty)}: {ShootingTime(dto)}";

        static string ShootingTime(IEnumerable<BaseDtoWithShotsDto> dto) =>
            dto.Sum(dto => dto.ShootingTimeMinutes).ToDayHourMinuteDuration();
    }

    public static string ToDayHourMinuteDuration(this int totalMinutes)
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
