using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Enemy;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Entities.Weapon;

namespace PuzzleConsoleGame.Config.Collision;

public class CollisionManager
{
    public void CheckInteraction(List<IInteractable> entities)
    {
        var entityPairs = entities.SelectMany((source, index) =>
            entities.Skip(index + 1).Select(target => (entityA: source, entityB: target)));

        foreach (var (source, target) in entityPairs)
        {
            if (!(source is IPositioned positionedA && target is IPositioned positionedB)) continue;

            if (positionedA.XPosition != positionedB.XPosition ||
                positionedA.YPosition != positionedB.YPosition) continue;


            HandleInteraction(source, target);
        }
    }

    private void HandleInteraction(IInteractable source, IInteractable target)
    {
        var key = (source.Type, target.Type);
        if (CollisionMap.InteractionMap.TryGetValue(key, out var interaction))
        {
            interaction(source, target);
        }
    }

    public bool IsInBounds(IPositioned entity)
    {
       
        
        var t = entity.XPosition is > Boundaries.GameBoundsVerticalMin and < Boundaries.GameBoundsHorizontalMax &&
               entity.YPosition is > Boundaries.GameBoundsHorizontalMin and < Boundaries.GameBoundsVerticalMax;

        var walls = GameWorld._maps;
        
        if (walls.Where(wall => entity is not Enemy).Any(wall => entity.XPosition == wall.XPosition && entity.YPosition == wall.YPosition))
        {
            return false;
        }
        
        return t;
    }
}