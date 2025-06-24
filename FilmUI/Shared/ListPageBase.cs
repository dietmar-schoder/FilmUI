using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FilmUI.Shared;

public abstract class ListPageBase<T> : ComponentBase
{
    protected List<T> Items;

    [Inject]
    public IApiService Api { get; set; }

    protected abstract string ApiEndpoint { get; }

    protected override async Task OnInitializedAsync()
    {
        Items = await Api.GetListAsync<T>(ApiEndpoint);
    }
}
