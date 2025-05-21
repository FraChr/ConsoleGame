using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Enemy;

public class Enemy(int xPosition, int yPosition, Player player) : IRenderable
{
    public int XPosition { get; set; } = xPosition;
    public int YPosition { get; set; } = yPosition;
    public char Symbol { get; set; } = EnemyData.EnemyCharacter;


    public void Move()
    {
        if (XPosition < player.XPosition) XPosition++;
        else if (XPosition > player.XPosition) XPosition--;
        if (YPosition < player.YPosition) YPosition++;
        else if (YPosition > player.YPosition) YPosition--;
    }
}