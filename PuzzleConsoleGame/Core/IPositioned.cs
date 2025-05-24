namespace PuzzleConsoleGame.Core;

public interface IPositioned
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public int previousX { get;  set; }
    public int previousY { get;  set; }
}