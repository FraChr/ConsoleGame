using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Items;

// public interface IInteractable : IRenderable
// {
//     bool IsActive { get; set; }
//     void Interact(Player.Player player);
// }

public interface IInteractable
{
    bool IsActive { get; set; }
    void Interact(IInteractable other);
    
}