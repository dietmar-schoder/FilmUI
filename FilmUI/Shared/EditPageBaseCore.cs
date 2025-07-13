using FilmUI.Constants;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace FilmUI.Shared;

public abstract class EditPageBaseCore<TDto> : ComponentBase where TDto : class, new()
{
    [Inject] protected IApiService Api { get; set; }
    [Inject] protected NavigationManager Nav { get; set; }
    [Inject] protected IJSRuntime JS { get; set; }

    public TDto Item { get; set; } = new();

    public virtual PageKey Page { get; }
    public virtual string IdAsString { get; }
    public virtual bool IsAddMode { get; }

    public virtual string ApiEndpoint => PageMappings.ApiEndpoints[Page];
    public virtual string ListRoute => PageMappings.ListRoutes[Page];

    public bool IsEditMode => !IsAddMode;
    public bool IsSaving { get; private set; }

    public virtual string PageTitle =>
        IsAddMode ? $"Add New {Page}" : $"Edit {Page}";

    protected override async Task OnInitializedAsync()
    {
        if (IsAddMode)
        {
            await InitNewItemAsync();
        }
        else
        {
            Item = await Api.GetAsyncOLD<TDto>($"{ApiEndpoint}/{IdAsString}");
        }
    }

    protected virtual async Task InitNewItemAsync()
    {
        await Task.CompletedTask;
    }

    protected virtual bool OnBeforeSafeOk() => true;

    public async Task SaveAsync()
    {
        if (!OnBeforeSafeOk()) return;

        IsSaving = true;

        await (IsAddMode
            ? Api.PostAsyncOLD(ApiEndpoint, Item)
            : Api.PutAsyncOLD($"{ApiEndpoint}/{IdAsString}", Item));

        Nav.NavigateTo(ListRoute);

        IsSaving = false;
    }

    public async Task ConfirmDeleteAsync()
    {
        IsSaving = true;
        await JS.InvokeVoidAsync("hideModalById", "deleteModal");
        await Api.DeleteAsyncOLD($"{ApiEndpoint}/{IdAsString}");
        Nav.NavigateTo(ListRoute);
        IsSaving = false;
    }

    public void GoBack()
        => Nav.NavigateTo(ListRoute);
}
