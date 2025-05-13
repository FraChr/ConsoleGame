namespace PuzzleConsoleGame;

using static GameConstants;

public class GameBounds(int xMax, int yMax)
{
    private const int XMin = 0;
    private const int YMin = 0;
    private int XMax { get; set; } = xMax;
    private int YMax { get; set; } = yMax;

    public bool IsInBounds(PlayerPos pos)
    {
        return pos.XPos > XMin && pos.XPos < XMax && pos.YPos > YMin && pos.YPos < YMax;
    }

    public void DrawBounds()
    {
        DrawVerticalBorder();
        DrawHorizontalBorder();
        DrawCorners();
    }

    private void DrawVerticalBorder()
    {
        const int yMinBound = YMin + 1;
        for (var y = yMinBound; y < YMax; y++)
        {
            Console.SetCursorPosition(XMin, y);
            Console.Write(char.ConvertFromUtf32(Border.VerticalBorder));
            Console.SetCursorPosition(XMax, y);
            Console.Write(char.ConvertFromUtf32(Border.VerticalBorder));
        }
    }

    private void DrawHorizontalBorder()
    {
        const int xMinBound = XMin + 1;
        for (var x = xMinBound; x < XMax; x++)
        {
            Console.SetCursorPosition(x, YMin);
            Console.Write(char.ConvertFromUtf32(Border.HorizontalBorder));
            Console.SetCursorPosition(x, YMax);
            Console.Write(char.ConvertFromUtf32(Border.HorizontalBorder));
        }
    }

    private void DrawCorners()
    {
        Console.SetCursorPosition(XMin, YMin);
        Console.Write(char.ConvertFromUtf32(Border.LeftUpperCorner));

        Console.SetCursorPosition(XMax, YMin);
        Console.Write(char.ConvertFromUtf32(Border.RightUpperCorner));

        Console.SetCursorPosition(XMin, YMax);
        Console.Write(char.ConvertFromUtf32(Border.LeftLowerCorner));

        Console.SetCursorPosition(XMax, YMax);
        Console.Write(char.ConvertFromUtf32(Border.RightLowerCorner));
    }
}

public struct PlayerPos(int startXPos, int startYPos)
{
    public int XPos { get; private set; } = startXPos;
    public int YPos { get; private set; } = startYPos;

    public void Move(int dX, int dY)
    {
        XPos += dX;
        YPos += dY;
    }
}