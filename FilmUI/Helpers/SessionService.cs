using Blazored.LocalStorage;
using FilmUI.DTOs;

namespace FilmUI.Helpers;

public interface ISessionService
{
    UserDto CurrentUser { get; }
    bool IsLoggedIn => CurrentUser is not null;
    Guid? UserId => CurrentUser?.Id;
    string Jwt => CurrentUser?.Jwt;

    FilmDto SelectedFilm { get; }
    Guid? SelectedFilmId => SelectedFilm?.Id;
    bool HasFilmSelected => SelectedFilm is not null;

    Task SetUser(UserDto user);
    Task SetSelectedFilm(FilmDto film);
    Task Clear();
}

public class SessionService(ILocalStorageService localStorage) : ISessionService
{
    private readonly ILocalStorageService _localStorage = localStorage;

    public UserDto CurrentUser { get; private set; }

    public FilmDto SelectedFilm { get; private set; }

    public async Task InitializeAsync()
    {
        CurrentUser = await _localStorage.GetItemAsync<UserDto>("user");
        SelectedFilm = await _localStorage.GetItemAsync<FilmDto>("film");
    }

    public async Task SetUser(UserDto user)
    {
        CurrentUser = user;
        await _localStorage.SetItemAsync("user", user);
    }

    public async Task SetSelectedFilm(FilmDto film)
    {
        SelectedFilm = film;
        await _localStorage.SetItemAsync("film", film);
    }

    public async Task Clear()
    {
        CurrentUser = null;
        SelectedFilm = null;
        await _localStorage.RemoveItemAsync("user");
        await _localStorage.RemoveItemAsync("film");
    }
}
