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
    public int Damage => WeaponData.Damage;
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
        var(deltaX, deltaY) = GetDirectionsOffset(_direction);
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