namespace PuzzleConsoleGame;

public struct GameBounds(int xMax, int yMax)
{
    private const int XMin = 0;
    private const int YMin = 0;
    private int XMax { get; set; } = xMax;
    private int YMax { get; set; } = yMax;

    public readonly bool IsInBounds(Position pos)
    {
        return pos.X >= XMin && pos.X <= XMax && pos.Y >= YMin && pos.Y <= YMax;
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