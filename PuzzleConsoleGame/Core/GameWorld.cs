using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.DataBaseAPI;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Models;

namespace PuzzleConsoleGame.Core;

public class GameWorld
{
    public readonly int VerticalMin = Boundaries.GameBoundsVerticalMin;
    public readonly int HorizontalMin = Boundaries.GameBoundsHorizontalMin;

    public int VerticalMax = Boundaries.GameBoundsHorizontalMax;
    public int HorizontalMax = Boundaries.GameBoundsVerticalMax;

    public static List<IPositioned> Maps = [];
    private static (int XPosition, int YPosition) _spawn;
    private static List<ItemSpawn> _itemSpawns = [];

    public void GetMapFromDataBase(int levelId)
    {
        var dbApi = new DbApi();
        var map = dbApi.GetGameLevel(levelId);
        
        foreach (var renderable in map.MapTiles.Select(data => new RenderableMap(data)))
        {
            Maps.Add(renderable);
        }
        
        Maps = map.MapTiles.Select(x => new RenderableMap(x)).Cast<IPositioned>().ToList();
        
        if (map.PlayerSpawn is not null)
        {
            _spawn = (map.PlayerSpawn.PlayerXSpawn, map.PlayerSpawn.PlayerYSpawn);
        }

        _itemSpawns = map.ItemSpawns
            .Select(x => new ItemSpawn
            {
                ItemXSpawn = x.ItemXSpawn,
                ItemYSpawn = x.ItemYSpawn,
                ItemType = x.ItemType,
            })
            .ToList();
        
        // _itemSpawns = map.ItemSpawns
        //     .Select(x => (x.ItemXSpawn, x.ItemYSpawn))
        //     .ToList();
    }

    public List<IPositioned> GetMap()
    {
        return Maps;
    }

    public (int xPosition, int yPosition) GetPlayerSpawn()
    {
        return _spawn;
    }
    
    public List<ItemSpawn> GetItemSpawn()
    {
        return _itemSpawns;
    }
}