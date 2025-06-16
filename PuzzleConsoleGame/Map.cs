using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame;

public class Map
{
    public int LevelId { get; set; }
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public string Symbol { get; set; }
    public string Description { get; set; }
    public int XSpawn { get; set; }
    public int YSpawn { get; set; }
}

public class PlayerSpawn
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
}