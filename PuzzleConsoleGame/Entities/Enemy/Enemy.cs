using PuzzleConsoleGame.Config;

namespace PuzzleConsoleGame.Entities.Enemy;

public class Enemy : Character.Character
{
    public int Value { get; } = 10;

    private int _movementCooldown = 0;
    private const int MoveInterval = 20;
    public override EntityType Type => EntityType.Enemy;

    public Enemy(int xPosition, int yPosition) : base(xPosition, yPosition)
    {
        XPosition = xPosition;
        YPosition = yPosition;
        Symbol = EnemyData.EnemyCharacter;
        Health = EnemyData.Health;
    }
    
    public override void Interact()
    {
        // if (other is not Enemy { IsActive: true } enemy) return;
        // if (other is Player.Player player)
        // {
        //     player.TakeDamage(this);
        // }
        
        // _interactionHandler.HandleInteraction(this, other);
    }
    
    
    public void Move(Enemy activeEnemy, int positionX, int positionY)
    {
        if (activeEnemy.XPosition < positionX) activeEnemy.XPosition++;
        else if (activeEnemy.XPosition > positionX) activeEnemy.XPosition--;
        if (activeEnemy.YPosition < positionY) activeEnemy.YPosition++;
        else if (activeEnemy.YPosition > positionY) activeEnemy.YPosition--;


        // if (XPosition < _player.PreviousX) XPosition++;
        // else if (XPosition > _player.PreviousX) XPosition--;
        // if (YPosition < _player.PreviousY) YPosition++;
        // else if (YPosition > _player.PreviousY) YPosition--;
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
}