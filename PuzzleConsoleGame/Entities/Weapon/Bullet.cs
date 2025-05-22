using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Interfaces;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Weapon;

public class Bullet : IDamage, IEntity
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public char Symbol { get; set; }
    public int Damage { get; } = 50;
    private readonly Direction _direction;

    public bool IsActive { get; set; }

    public void Interact()
    {
        IsActive = true;
    }

    public Bullet(Player.Player player, char symbol = WeaponData.Bullet)
    {
        _direction = player.Facing;
        
        var (dx, dy) = GetDirectionsOffset(_direction);
        XPosition = player.XPosition + dx;
        YPosition = player.YPosition + dy;
        Symbol = symbol;
        
    }

    public void Move()
    {
        // if (_direction == Direction.Up) YPosition--;
        // else if (_direction == Direction.Down) YPosition++;
        // else if (_direction == Direction.Left) XPosition--;
        // else if (_direction == Direction.Right) XPosition++;
        
        var(dx, dy) = GetDirectionsOffset(_direction);
        XPosition += dx;
        YPosition += dy;
    }

    private (int, int) GetDirectionsOffset(Direction direction)
    {
        return direction switch
        {
            // Direction.Up => (0, -1),
            Direction.Up => (Movement.NoMove, Movement.MoveNegative),
            Direction.Down => (Movement.NoMove, Movement.MovePositive),
            Direction.Left => (Movement.MoveNegative, Movement.NoMove),
            Direction.Right => (Movement.MovePositive, Movement.NoMove),
            _ => (Movement.NoMove, Movement.NoMove)
        };
    }
}