using PuzzleConsoleGame.Entities.Items;

namespace PuzzleConsoleGame.Entities;

public class CollisionManager(ItemManager itemManager)
{
    public void CheckInteraction(Player player, IInteractable interactable)
    {
        if (!interactable.IsCollected &&
            player.XPosition == interactable.XPosition &&
            player.YPosition == interactable.YPosition)
        {
            interactable.Interact();
        }

        if (interactable.IsCollected)
        {
            itemManager.RemoveItem(interactable);
        }
    }
}