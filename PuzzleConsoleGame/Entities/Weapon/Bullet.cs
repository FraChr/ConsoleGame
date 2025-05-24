using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Interfaces;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Weapon;

public class Bullet : IDamage, IInteractable, IRenderable, IPositioned
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    
    public int PreviousX { get;  set; }
    public int PreviousY { get;  set; }
    public char Symbol { get; set; }
    public int Damage => WeaponData.Damage;
    private readonly Direction _direction;
    private readonly IInteractionHandler _interactionHandler;
    public bool IsActive { get; set; }
    
    private int _movementCooldown = 0;
    private const int MoveInterval = 10;
    public int Delay = 0;


    public Bullet(Player.Player player, IInteractionHandler interactionHandler, char symbol = WeaponData.Bullet)
    {
        _direction = player.Facing;

        var (dx, dy) = GetDirectionsOffset(_direction);
        XPosition = player.XPosition + dx;
        YPosition = player.YPosition + dy;
        _interactionHandler = interactionHandler;
        Symbol = symbol;
    }

    public void Interact(IInteractable other)
    {
        if (!IsActive) return;
        _interactionHandler.HandleInteraction(this, other);
        // if (other is Player.Player player)
        // {
        //     player.TakeDamage(this);
        // }

        // IsActive = false;
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
    
    public void Move()
    {
        var (deltaX, deltaY) = GetDirectionsOffset(_direction);
        XPosition += deltaX;
        YPosition += deltaY;
    }

    private (int, int) GetDirectionsOffset(Direction direction)
    {
        return direction switch
        {
            Direction.Up => (Movement.NoMove, Movement.MoveNegative),
            Direction.Down => (Movement.NoMove, Movement.MovePositive),
            Direction.Left => (Movement.MoveNegative, Movement.NoMove),
            Direction.Right => (Movement.MovePositive, Movement.NoMove),
            _ => (Movement.NoMove, Movement.NoMove)
        };
    }
}