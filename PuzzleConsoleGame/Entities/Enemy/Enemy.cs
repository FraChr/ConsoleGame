using PuzzleConsoleGame.Config;

namespace PuzzleConsoleGame.Entities.Enemy;

public class Enemy : Character.Character
{
    private int _movementCooldown = 0;
    private const int MoveInterval = 20;

    private readonly Random _random = new Random();
    public override EntityType Type => EntityType.Enemy;

    public Enemy(int xPosition, int yPosition) : base(xPosition, yPosition)
    {
        XPosition = xPosition;
        YPosition = yPosition;
        Symbol = EnemyData.EnemyCharacter;
        Health = EnemyData.Health;
        Value = EnemyData.Damage;
    }


    public void Update(Enemy activeEnemy, int positionX, int positionY)
    {
        activeEnemy.PreviousX = activeEnemy.XPosition;
        activeEnemy.PreviousY = activeEnemy.YPosition;

        if (activeEnemy._movementCooldown > 0)
        {
            activeEnemy._movementCooldown--;
            return;
        }

        Move(activeEnemy, positionX, positionY);
        activeEnemy._movementCooldown = MoveInterval;
    }

    private void Move(Enemy activeEnemy, int positionX, int positionY)
    {
        if(_random.NextDouble() < 0.2) return;
        // if (_random.NextDouble() < 0.3)
        // {
        //     var direction = _random.Next(4);
        //     switch (direction)
        //     {
        //         case 0: activeEnemy.YPosition -= 2; break;
        //         case 1: activeEnemy.YPosition += 2; break;
        //         case 2: activeEnemy.XPosition -= 2; break;
        //         case 3: activeEnemy.XPosition += 2; break;
        //     }
        // }

        // if (_random.NextDouble() < 0.1)
        // {
        //     activeEnemy.XPosition = positionX + 5;
        //     activeEnemy.YPosition = positionY + 5;
        // }
        
        // if (_random.NextDouble() < 0.3)
        // {
        //     if (_random.Next(2) == 0)
        //     {
        //         activeEnemy.XPosition += _random.Next(2) * 2 - 1;
        //     }
        //     else
        //     {
        //         activeEnemy.YPosition += _random.Next(2) * 2 - 1;
        //     }
        // }

        if (activeEnemy.XPosition < positionX) activeEnemy.XPosition++;
        else if (activeEnemy.XPosition > positionX) activeEnemy.XPosition--;
        if (activeEnemy.YPosition < positionY) activeEnemy.YPosition++;
        else if (activeEnemy.YPosition > positionY) activeEnemy.YPosition--;
    }
}