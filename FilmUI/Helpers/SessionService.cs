using FilmUI.DTOs;

namespace FilmUI.Helpers;

public interface ISessionService
{
    string Jwt { get; }
    Guid? SelectedFilmId { get; }
    void SetUser(UserDto user);
    void SetSelectedFilmId(Guid filmId);
    void Clear();
}

public class SessionService : ISessionService
{
    public UserDto CurrentUser { get; private set; }
    public string Jwt => CurrentUser?.Jwt;
    public Guid? UserId => CurrentUser?.Id;

    public Guid? SelectedFilmId { get; private set; }

    public bool IsLoggedIn => CurrentUser is not null;

    public void SetUser(UserDto user)
    {
        CurrentUser = user;
        // Optionally persist to local storage if you want auto-login
    }

    public void SetSelectedFilmId(Guid filmId) =>
        SelectedFilmId = filmId;

    public void Clear()
    {
        CurrentUser = null;
        SelectedFilmId = null;
    }
}
