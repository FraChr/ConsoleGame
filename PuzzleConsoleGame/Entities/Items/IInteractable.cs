
using PuzzleConsoleGame.Core;

namespace PuzzleConsoleGame.Entities.Items;

public interface IInteractable
{
    bool IsActive { get; set; }
    void Interact(IInteractable other);
    
}