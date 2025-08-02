using Microsoft.AspNetCore.Components;

namespace FilmUI.Layout;

public partial class MainLayout : LayoutComponentBase
{
    protected override void OnInitialized() => Session.OnChange += SessionChanged;

    private void SessionChanged() => InvokeAsync(StateHasChanged);

    public void Dispose() => Session.OnChange -= SessionChanged;

    private void Logout()
    {
        Session.Clear();
        Navigation.NavigateTo("/login");
    }
}
