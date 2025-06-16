using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.DataBaseAPI;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Entities.Player;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Core;

public class GameWorld
{
    public readonly int VerticalMin = Boundaries.GameBoundsVerticalMin;
    public readonly int HorizontalMin = Boundaries.GameBoundsHorizontalMin;

    public int VerticalMax = Boundaries.GameBoundsHorizontalMax;
    public int HorizontalMax = Boundaries.GameBoundsVerticalMax;

    public static List<IPositioned> _maps = [];
    public static (int XPosition, int YPosition) Spawn;

    public void GetMapFromDataBase()
    {
        var dbapi = new DbApi();
        var map = dbapi.GetGameMap();

        foreach (var wall in map)
        {
            var renderable = new RenderableMap(wall);
            _maps.Add(renderable);
            Spawn = (wall.XSpawn, wall.YSpawn);
            
        }
    }

    public List<IPositioned> GetMap()
    {
        return _maps;
    }

    public (int xPosition, int yPosition) GetPlayerSpawn()
    {
        return Spawn;
    }
}