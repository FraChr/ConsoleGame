namespace PuzzleConsoleGame;

public struct GameBounds(int xMax, int yMax)
{
    private const int XMin = 0;
    private const int YMin = 0;
    private int XMax { get; set; } = xMax;
    private int YMax { get; set; } = yMax;

    public readonly bool IsInBounds(Position pos)
    {
        return pos.X > XMin && pos.X < XMax && pos.Y > YMin && pos.Y < YMax;
    }

    public readonly void DrawBounds()
    {
        for (var y = YMin + 1; y < YMax; y++)
        {
            Console.SetCursorPosition(XMin, y);
            Console.Write(char.ConvertFromUtf32(0x2502));
            Console.SetCursorPosition(XMax, y);
            Console.Write(char.ConvertFromUtf32(0x2502));
        }
        
        for (var x = XMin + 1; x < XMax; x++)
        {
            Console.SetCursorPosition(x, YMin);
            Console.Write(char.ConvertFromUtf32(0x2500));
            Console.SetCursorPosition(x, YMax);
            Console.Write(char.ConvertFromUtf32(0x2500));
        }
        
        Console.SetCursorPosition(XMin, YMin);
        Console.Write(char.ConvertFromUtf32(0x250C));
        Console.SetCursorPosition(XMax, YMin);
        Console.Write(char.ConvertFromUtf32(0x2510));
        Console.SetCursorPosition(XMin, YMax);
        Console.Write(char.ConvertFromUtf32(0x2514));
        Console.SetCursorPosition(XMax, YMax);
        Console.Write(char.ConvertFromUtf32(0x2518));
        
        
    }
}

public struct Position(int startX, int startY)
{
    public int X { get; private set; } = startX;
    public int Y { get; private set; } = startY;

    public void Move(int dX, int dY)
    {
        X += dX;
        Y += dY;
    }
}