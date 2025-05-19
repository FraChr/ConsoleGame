using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Enemy;

public class Enemy(int xPosition, int yPosition, GameWorld gameWorld, Player player) : IRenderable
{
    public int XPosition { get; set; } = xPosition;
    public int YPosition { get; set; } = yPosition;
    public char Symbol { get; set; } = EnemyData.EnemyCharacter;
    
    
    public void Move()
    {
        if (gameWorld.IsInBounds(this))
        {
            if (XPosition < player.XPosition) XPosition++;
            else if (XPosition > player.XPosition) XPosition--;
            if (YPosition < player.YPosition) YPosition++;
            else if (YPosition > player.YPosition) YPosition--;
            // XPosition = player.XPosition;
            // YPosition = player.YPosition;
        }
    }
    
}