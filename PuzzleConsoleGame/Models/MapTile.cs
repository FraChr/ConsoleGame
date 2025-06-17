namespace PuzzleConsoleGame.Models;

public class MapTile
{
    public int LevelId { get; init; }
    public int XPosition { get; init; }
    public int YPosition { get; init; }
    public string? Symbol { get; init; }
    public string? Description { get; init; }
}