using Microsoft.AspNetCore.Components;

namespace FilmUI.Shared;

public abstract class EditPageBaseInt<TDto>: EditPageBaseCore<TDto> where TDto : class, new()
{
    [Parameter] public int Id { get; set; }

    public override bool IsAddMode => Id == 0;
    public override string IdAsString => Id.ToString();
}
