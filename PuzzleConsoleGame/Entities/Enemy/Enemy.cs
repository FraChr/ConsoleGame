using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Interfaces;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Enemy;

public class Enemy : IRenderable
{
    private readonly Player.Player _player;

    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public char Symbol { get; private set; } = EnemyData.EnemyCharacter;
    public int Health { get; private set; } = EnemyData.Health;
    
    public Enemy(int xPosition, int yPosition, Player.Player player)
    {
        _player = player;
        XPosition = xPosition;
        YPosition = yPosition;
    }
    
    public void Move()
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