using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Entities.Items;

namespace PuzzleConsoleGame.Rendering;

public interface IRenderable : IPositioned, IInteractable
{ 
    char Symbol { get; }
}