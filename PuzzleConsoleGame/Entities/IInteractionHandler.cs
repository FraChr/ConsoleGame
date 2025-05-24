using PuzzleConsoleGame.Entities.Items;

namespace PuzzleConsoleGame.Entities;

public interface IInteractionHandler
{
    void HandleInteraction(IInteractable source, IInteractable target);
}