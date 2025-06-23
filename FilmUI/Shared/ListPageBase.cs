using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FilmUI.Shared;

public abstract class ListPageBase<TDto> : ComponentBase
{
    protected List<TDto> Items;

    [Inject]
    public IApiService Api { get; set; }

    protected abstract string ApiEndpoint { get; }

    protected override async Task OnInitializedAsync()
    {
        Items = await Api.GetListAsync<TDto>(ApiEndpoint);
    }
}
