namespace PuzzleConsoleGame;

using static GameConstants;

public class GameBounds(int xMax, int yMax)
{
    public const int XMin = 0;
    public const int YMin = 0;
    public int XMax { get; set; } = xMax;
    public int YMax { get; set; } = yMax;

    public bool IsInBounds(PlayerPos pos)
    {
        return pos.XPos > XMin && pos.XPos < XMax && pos.YPos > YMin && pos.YPos < YMax;
    }
}

public class PlayerPos
{
    public int XPos { get; private set; }
    public int YPos { get; private set; }

    public PlayerPos(int xPos, int yPos)
    {
        XPos = xPos;
        YPos = yPos;
    }

    public PlayerPos Move(int dX = Movement.NoMove, int dY = Movement.NoMove)
    {
        return new PlayerPos(XPos + dX, YPos + dY);
    }
}