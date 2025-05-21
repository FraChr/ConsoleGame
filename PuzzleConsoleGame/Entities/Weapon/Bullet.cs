using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Weapon;

public class Bullet : IRenderable
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public char Symbol { get; set; }
    private readonly Direction _direction;

    public Bullet(Player player, char symbol = WeaponData.Bullet)
    {
        XPosition = player.XPosition;
        YPosition = player.YPosition;
        Symbol = symbol;
        _direction = player.Facing;
    }

    public void Move()
    {
        if (_direction == Direction.Up) YPosition--;
        else if (_direction == Direction.Down) YPosition++;
        else if (_direction == Direction.Left) XPosition--;
        else if (_direction == Direction.Right) XPosition++;
    }
}