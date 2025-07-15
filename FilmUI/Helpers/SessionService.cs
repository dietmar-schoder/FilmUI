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

    void SetUser(UserDto user);
    void SetSelectedFilm(FilmDto film);
    void Clear();
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

    public async void SetUser(UserDto user)
    {
        CurrentUser = user;
        await _localStorage.SetItemAsync("user", user);
    }

    public async void SetSelectedFilm(FilmDto film)
    {
        SelectedFilm = film;
        await _localStorage.SetItemAsync("film", film);
    }

    public async void Clear()
    {
        CurrentUser = null;
        SelectedFilm = null;
        await _localStorage.RemoveItemAsync("user");
        await _localStorage.RemoveItemAsync("film");
    }
}
