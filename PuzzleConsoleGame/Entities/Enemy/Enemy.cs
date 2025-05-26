using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Interfaces;

namespace PuzzleConsoleGame.Entities.Enemy;

public class Enemy : Character.Character, IDamage
{
    private readonly IInteractionHandler _interactionHandler;
    public int Damage { get; } = 10;

    public int MovementCooldown = 0;
    public readonly int MoveInterval = 20;

    public Enemy(int xPosition, int yPosition, IInteractionHandler interactionHandler) : base(xPosition, yPosition)
    {
        _interactionHandler = interactionHandler;
        XPosition = xPosition;
        YPosition = yPosition;
        Symbol = EnemyData.EnemyCharacter;
        Health = EnemyData.Health;
    }
    
    public override void Interact(IInteractable other)
    {
        _interactionHandler.HandleInteraction(this, other);
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

        if (activeEnemy.MovementCooldown > 0)
        {
            activeEnemy.MovementCooldown--;
            return;
        }

        Move(activeEnemy, positionX, positionY);
        activeEnemy.MovementCooldown = activeEnemy.MoveInterval;
    }
}