using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Entities.Items;

namespace PuzzleConsoleGame.Entities;

public class CollisionManager
{
    private readonly ItemManager _itemManager;
    private readonly GameWorld _gameWorld;

    public CollisionManager(ItemManager itemManager, GameWorld gameWorld)
    {
        _itemManager = itemManager;
        _gameWorld = gameWorld;
    }

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
            _itemManager.RemoveItem(interactable);
        }
    }

    public bool IsInBounds(IPositioned entity)
    {
        return entity.XPosition > _gameWorld.VerticalMin &&
               entity.XPosition < _gameWorld.VerticalMax &&
               entity.YPosition > _gameWorld.HorizontalMin &&
               entity.YPosition < _gameWorld.HorizontalMax;
    }
}