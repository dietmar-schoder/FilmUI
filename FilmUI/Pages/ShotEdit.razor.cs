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
        Item = await Api.GetAsyncOLD<ShotDto>($"{ApiEndpoint}/0");

    private async Task OpenCastModal()
    {
        IsCastModalOpen = true;
        CastSelections = await Api.GetAsyncOLD<List<CastSelectionDto>>($"{ApiEndpoint}/{IdAsString}/cast-selections");
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

        await Api.PostAsyncOLD($"{ApiEndpoint}/{IdAsString}/cast-selections", selectedIds);

        IsSavingCastSelections = false;

        CloseCastModal();
    }

    private async Task OpenGearModal()
    {
        IsGearModalOpen = true;
        GearSelections = await Api.GetAsyncOLD<List<GearSelectionDto>>($"{ApiEndpoint}/{IdAsString}/gear-selections");
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

        await Api.PostAsyncOLD($"{ApiEndpoint}/{IdAsString}/gear-selections", selectedIds);

        IsSavingGearSelections = false;

        CloseGearModal();
    }
}
