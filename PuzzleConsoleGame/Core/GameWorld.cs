namespace PuzzleConsoleGame;

using static GameConstants;

public class GameWorld(int verticalMax, int horizontalMax)
{
    public const int VerticalMin = Boundaries.GameBoundsVerticalMin;
    public const int HorizontalMin = Boundaries.GameBoundsHorizontalMin;
    public int VerticalMax { get; set; } = verticalMax;
    public int HorizontalMax { get; set; } = horizontalMax;

    public bool IsInBounds(Player position)
    {
        return position.XPosition > VerticalMin && position.XPosition < VerticalMax && position.YPosition > HorizontalMin && position.YPosition < HorizontalMax;
    }
}

// public class PlayerPos
// {
//     public int XPos { get; private set; }
//     public int YPos { get; private set; }
//
//     public PlayerPos(int xPos, int yPos)
//     {
//         XPos = xPos;
//         YPos = yPos;
//     }
//
//     public PlayerPos Move(int dX = Movement.NoMove, int dY = Movement.NoMove)
//     {
//         return new PlayerPos(XPos + dX, YPos + dY);
//     }
// }