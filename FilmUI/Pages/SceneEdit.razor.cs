using FilmUI.Constants;
using FilmUI.DTOs;
using FilmUI.Shared;

namespace FilmUI.Pages;

public partial class SceneEdit : EditPageBaseInt<SceneDto>
{
    public override PageKey Page => PageKey.Scenes;
}
