using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame;

public class Map
{
    public int LevelId { get; set; }
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public string Symbol { get; set; }
    public string Description { get; set; }
}