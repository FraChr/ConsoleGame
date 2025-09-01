namespace PuzzleConsoleGame.Core;

public interface IPositioned
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public int PreviousX { get; }
    public int PreviousY { get; }
}