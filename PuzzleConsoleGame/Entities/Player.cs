namespace PuzzleConsoleGame;
using static GameConstants;
public class Player
{
    public int XPosition { get; private set; }
    public int YPosition { get; private set; }
    
    public Player(int xPosition, int yPosition)
    {
        XPosition = xPosition;
        YPosition = yPosition;
    }
    
    
    public Player Move(int deltaX = Movement.NoMove, int deltaY = Movement.NoMove)
    {
        return new Player(XPosition + deltaX, YPosition + deltaY);
    }
}