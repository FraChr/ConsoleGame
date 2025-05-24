namespace PuzzleConsoleGame.Core;

public interface IPositioned
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public int PreviousX { get;  set; }
    public int PreviousY { get;  set; }
}