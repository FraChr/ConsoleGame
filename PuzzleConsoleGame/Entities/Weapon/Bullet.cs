using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities.Items;

namespace PuzzleConsoleGame.Entities.Weapon;

public class Bullet : Item
{
    private readonly Direction _direction;
    
    private int _movementCooldown;
    private const int MoveInterval = 10;
    

    public override EntityType Type => EntityType.Bullet;

    public Bullet(int characterPositionX, int characterPositionY, Direction facing, char symbol = WeaponData.Bullet)
    {
        _direction = facing;

        var (dx, dy) = GetDirectionsOffset(_direction);
        XPosition = characterPositionX + dx;
        YPosition = characterPositionY + dy;
        
        Symbol = symbol;
        Value = 50;

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

    public void IncreaseDamage(IInteractable interactionValue)
    {
        Value += interactionValue.Value;
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