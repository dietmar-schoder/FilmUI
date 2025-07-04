using FilmUI.Constants;
using FilmUI.DTOs;
using FilmUI.Shared;

namespace FilmUI.Pages;

public partial class ShotEdit : EditPageBaseInt<ShotDto>
{
    private bool IsCastModalOpen = false;
    private bool IsSavingCastSelections = false;
    private List<CastSelectionDto> CastSelections;
    private bool IsGearModalOpen = false;
    private bool IsSavingGearSelections = false;
    private List<GearSelectionDto> GearSelections;

    public override PageKey Page => PageKey.Shots;

    protected override async Task InitNewItemAsync() =>
        Item = await Api.GetAsync<ShotDto>($"{ApiEndpoint}/0");

    private async Task OpenCastModal()
    {
        IsCastModalOpen = true;
        CastSelections = await Api.GetAsync<List<CastSelectionDto>>($"{ApiEndpoint}/{IdAsString}/cast-selections");
    }

    private void CloseCastModal() => IsCastModalOpen = false;

    private async Task SaveCastSelectionAsync()
    {
        if (IsSavingCastSelections) return;

        IsSavingCastSelections = true;

        var selectedIds = CastSelections
            .Where(c => c.IsSelected)
            .Select(c => c.CastId)
            .ToList();

        await Api.PostAsync($"{ApiEndpoint}/{IdAsString}/cast-selections", selectedIds);

        IsSavingCastSelections = false;

        CloseCastModal();
    }

    private async Task OpenGearModal()
    {
        IsGearModalOpen = true;
        GearSelections = await Api.GetAsync<List<GearSelectionDto>>($"{ApiEndpoint}/{IdAsString}/gear-selections");
    }

    private void CloseGearModal() => IsGearModalOpen = false;

    private async Task SaveGearSelectionAsync()
    {
        if (IsSavingGearSelections) return;

        IsSavingGearSelections = true;

        var selectedIds = GearSelections
            .Where(c => c.IsSelected)
            .Select(c => c.GearId)
            .ToList();

        await Api.PostAsync($"{ApiEndpoint}/{IdAsString}/gear-selections", selectedIds);

        IsSavingGearSelections = false;

        CloseGearModal();
    }
}
