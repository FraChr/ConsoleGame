namespace PuzzleConsoleGame.Entities;

public class CollisionManager
{
    public void CheckInteraction(Player player, IInteractable interactable)
    {
        if (!interactable.IsCollected &&
            player.XPosition == interactable.XPosition &&
            player.YPosition == interactable.YPosition)
        {
            interactable.Interact();
        }
    }
}