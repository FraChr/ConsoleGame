using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Entities.Weapon;

namespace PuzzleConsoleGame.Entities;

public class CollisionManager
{
    public void CheckInteraction(List<IInteractable> entities)
    {
        var entityPairs = entities.SelectMany((entityA, index) =>
            entities.Skip(index + 1).Select(entityB => (entityA, entityB)));

        foreach (var pair in entityPairs)
        {
            var entityA = pair.Item1;
            var entityB = pair.Item2;

            if (!(entityA is IPositioned positionedA && entityB is IPositioned positionedB)) continue;

            if (positionedA.XPosition != positionedB.XPosition ||
                positionedA.YPosition != positionedB.YPosition) continue;

            switch (entityA)
            {
                case Bullet when entityB is Bullet:
                case Bullet when entityB is Coin:
                case Enemy.Enemy when entityB is Coin:
                    continue;
                default:
                    entityA.Interact(entityB);
                    entityB.Interact(entityA);
                    break;
            }
        }
    }

    public bool IsInBounds(IPositioned entity)
    {
        return entity.XPosition > Boundaries.GameBoundsVerticalMin &&
               entity.XPosition < Boundaries.GameBoundsHorizontalMax &&
               entity.YPosition > Boundaries.GameBoundsHorizontalMin &&
               entity.YPosition < Boundaries.GameBoundsVerticalMax;
    }
}