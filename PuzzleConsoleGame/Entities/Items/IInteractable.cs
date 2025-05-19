using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Items;

public interface IInteractable : IRenderable
{
    bool IsCollected { get; set; }
    int Value { get; set; }

    void Interact();
}