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
    // public void CheckInteraction(Player.Player player, IInteractable interactable)
    // {
    //     if (player.XPosition == interactable.XPosition &&
    //         player.YPosition == interactable.YPosition)
    //     {
    //         interactable.Interact(player);
    //     }
    // }
    public void CheckInteraction(IInteractable a, IInteractable b)
    {
        
        // for (int i = 0; i < a.Count; i++)
        // {
        //     for (int j = i + 1; j < a.Count; j++)
        //     {
        //         if (a[i].XPosition == a[j].XPosition && a[i].YPosition == a[j].YPosition)
        //         {
        //             a[i].Interact(a[j]);
        //             a[j].Interact(a[i]);
        //         }
        //     }    
        // }

        if (a is IPositioned positionedA && b is IPositioned positionedB)
        {
            if (positionedA.XPosition != positionedB.XPosition || positionedA.YPosition != positionedB.YPosition) return;    
        }
        
        
        a.Interact(b);
        b.Interact(a);
    }

    public bool IsInBounds(IPositioned entity)
    {
        return entity.XPosition > _gameWorld.VerticalMin &&
               entity.XPosition < _gameWorld.VerticalMax &&
               entity.YPosition > _gameWorld.HorizontalMin &&
               entity.YPosition < _gameWorld.HorizontalMax;
    }
}