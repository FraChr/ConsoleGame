namespace PuzzleConsoleGame.Rendering;

public interface IRenderable
{
    int XPosition { get; set; }
    int YPosition { get; set; }
    char Symbol { get; set; }
}