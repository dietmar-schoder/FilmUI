using Microsoft.AspNetCore.Components;

namespace FilmUI.Shared;

public abstract class EditPageBaseGuid<TDto> : EditPageBaseCore<TDto> where TDto : class, new()
{
    [Parameter] public Guid Id { get; set; }

    public override bool IsAddMode => Id == Guid.Empty;
    public override string IdAsString => Id.ToString();
}
