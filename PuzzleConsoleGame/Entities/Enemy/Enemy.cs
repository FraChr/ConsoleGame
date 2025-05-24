using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Interfaces;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Enemy;

public class Enemy : IRenderable, IInteractable, IDamage
{
    private readonly Player.Player _player;
    private readonly IInteractionHandler _interactionHandler;
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    
    public int PreviousX { get;  set; }
    public int PreviousY { get;  set; }
    public char Symbol { get; private set; } = EnemyData.EnemyCharacter;
    public int Health { get; private set; } = EnemyData.Health;
    public int Damage { get; } = 10;
    public bool IsActive { get; set; }

    private int _movementCooldown = 0;
    private const int MoveInterval = 20;

    public Enemy(int xPosition, int yPosition, Player.Player player, IInteractionHandler interactionHandler)
    {
        _player = player;
        _interactionHandler = interactionHandler;
        XPosition = xPosition;
        YPosition = yPosition;
    }


    public void Interact(IInteractable other)
    {
        _interactionHandler.HandleInteraction(this, other);
    }

    public void Update()
    {
        PreviousX = XPosition;
        PreviousY = YPosition;
        
        if (_movementCooldown > 0)
        {
            _movementCooldown--;
            return;
        }
        Move();
        _movementCooldown = MoveInterval;
    }

    private void Move()
    {
        if (XPosition < _player.XPosition) XPosition++;
        else if (XPosition > _player.XPosition) XPosition--;
        if (YPosition < _player.YPosition) YPosition++;
        else if (YPosition > _player.YPosition) YPosition--;
    }

    public void TakeDamage(IDamage damage)
    {
        Health -= damage.Damage;
    }

    
}