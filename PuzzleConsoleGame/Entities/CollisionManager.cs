using System.Diagnostics;
using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Entities.Weapon;

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
    public void CheckInteraction(List<IInteractable> entities)
    {
        var entityPairs = entities.SelectMany((entityA, index) => entities.Skip(index + 1).Select(entityB => (entityA, entityB)));

        foreach (var pair in entityPairs)
        {
            var entityA = pair.Item1;
            var entityB = pair.Item2;

            if (!(entityA is IPositioned positionedA && entityB is IPositioned positionedB)) continue;
            
            if (positionedA.XPosition != positionedB.XPosition ||
                positionedA.YPosition != positionedB.YPosition) continue;
            
            if (entityA is Bullet && entityB is Bullet)
            {
                continue;
            }
            if(entityA is Bullet && entityB is Coin) continue;

            entityA.Interact(entityB);
            entityB.Interact(entityA);
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