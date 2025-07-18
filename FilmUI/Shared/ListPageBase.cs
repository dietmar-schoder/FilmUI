﻿using FilmUI.Constants;
using FilmUI.DTOs;

namespace FilmUI.Shared;

public abstract class ListPageBase<T> : ApiPageBase
{
    protected List<T> Items;

    protected string EditRoute => PageMappings.EditRoutes[Page];
    protected string ListTitle => PageMappings.ListTitles[Page];

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (Session.IsLoggedIn)
        {
            Items = await CallApi(() => Api.GetAsync<List<T>>(ApiEndpoint)) ?? [];
        }
    }

    protected async Task OnSelectFilm(FilmDto film)
    {
        await Session.SetSelectedFilm(film);
        StateHasChanged();
    }
}
