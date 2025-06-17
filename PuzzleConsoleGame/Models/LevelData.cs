namespace PuzzleConsoleGame.Models;

public class LevelData
{
    public int LevelId { get; set; }
    public PlayerSpawn? PlayerSpawn { get; init; }
    public List<ItemSpawn> ItemSpawns { get; init; } = [];
    public List<MapTile> MapTiles { get; init; } = [];

}