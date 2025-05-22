using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Items;

public interface IInteractable : IRenderable
{
    bool IsActive { get; set; }
    void Interact();
}

// public interface IInteractable : IRenderable
// {
//     bool IsCollected { get; set; }
//     int Value { get; set; }
//
//     void Interact();
// }