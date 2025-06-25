using FilmUI.Constants;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FilmUI.Shared;

public abstract class ListPageBase<T> : ComponentBase
{
    protected List<T> Items;

    [Inject]
    public IApiService Api { get; set; }
    protected abstract PageKey Page { get; }
    protected string ApiEndpoint => PageMappings.ApiEndpoints[Page];
    protected string EditRoute => PageMappings.EditRoutes[Page];
    protected string ListTitle => PageMappings.ListTitles[Page];

    protected override async Task OnInitializedAsync()
    {
        Items = await Api.GetListAsync<T>(ApiEndpoint);
    }
}
