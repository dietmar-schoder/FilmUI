using FilmUI.Constants;

namespace FilmUI.Shared;

public abstract class ListPageBase<T> : ApiPageBase
{
    protected List<T> Items;

    protected string EditRoute => PageMappings.EditRoutes[Page];
    protected string ListTitle => PageMappings.ListTitles[Page];

    protected override async Task OnInitializedAsync() =>
        Items = await CallApi(() => Api.GetAsync<List<T>>(ApiEndpoint)) ?? [];
}
