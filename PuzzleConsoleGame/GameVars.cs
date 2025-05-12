namespace PuzzleConsoleGame;

public struct GameBounds(int xMax, int yMax)
{
    private const int XMin = 0;
    private const int YMin = 0;
    private int XMax { get; set; } = xMax;
    private int YMax { get; set; } = yMax;

    public readonly bool IsInBounds(Position pos)
    {
        return pos.XPos > XMin && pos.XPos < XMax && pos.YPos > YMin && pos.YPos < YMax;
    }

    public readonly void DrawBounds()
    {
        for (var y = YMin + 1; y < YMax; y++)
        {
            Console.SetCursorPosition(XMin, y);
            Console.Write(char.ConvertFromUtf32(GameConstants.VerticalBorder));
            Console.SetCursorPosition(XMax, y);
            Console.Write(char.ConvertFromUtf32(GameConstants.VerticalBorder));
        }
        
        for (var x = XMin + 1; x < XMax; x++)
        {
            Console.SetCursorPosition(x, YMin);
            Console.Write(char.ConvertFromUtf32(GameConstants.HorizontalBorder));
            Console.SetCursorPosition(x, YMax);
            Console.Write(char.ConvertFromUtf32(GameConstants.HorizontalBorder));
        }
        
        Console.SetCursorPosition(XMin, YMin);
        Console.Write(char.ConvertFromUtf32(GameConstants.LeftUpperCorner));
        
        Console.SetCursorPosition(XMax, YMin);
        Console.Write(char.ConvertFromUtf32(GameConstants.RightUpperCorner));
        
        Console.SetCursorPosition(XMin, YMax);
        Console.Write(char.ConvertFromUtf32(GameConstants.LeftLowerCorner));
        
        Console.SetCursorPosition(XMax, YMax);
        Console.Write(char.ConvertFromUtf32(GameConstants.RightLowerCorner));
        
        
    }
}

public struct Position(int startXPos, int startYPos)
{
    public int XPos { get; private set; } = startXPos;
    public int YPos { get; private set; } = startYPos;

    public void Move(int dX, int dY)
    {
        XPos += dX;
        YPos += dY;
    }
}