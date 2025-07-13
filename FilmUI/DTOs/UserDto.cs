namespace FilmUI.DTOs;

public record UserDto(Guid Id, string Email, bool EmailIsConfirmed, string Jwt);
