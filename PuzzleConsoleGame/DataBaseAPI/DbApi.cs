using Dapper;
using Microsoft.Data.SqlClient;
using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Models;

namespace PuzzleConsoleGame.DataBaseAPI;

public class DbApi
{
    private string _connectionString =
        "Data Source=localhost;Database=GameWorld;Integrated Security=true;Connect Timeout=30;Encrypt=true;TrustServerCertificate=true;";


    public LevelData GetGameLevel(int levelId)
    {
        var connection = new SqlConnection(_connectionString);
        var queryMapTiles = @"SELECT 
                        M.LevelId,
                        M.XPosition,
                        M.YPosition,
                        W.Symbol,
                        W.Description
                    FROM
                        Map M
                    JOIN 
                        WallTypes W ON M.WallTypeId = W.WallTypeId
                    WHERE
                        M.LevelId = @levelId
                    ORDER BY
                        M.YPosition, M.XPosition;";

        var queryPlayerSpawn = @"SELECT  LevelId, XPosition AS PlayerXSpawn, YPosition AS PlayerYSpawn
                                    FROM PlayerSpawn
                                    WHERE LevelId = @levelId;";

        var queryItemSpawns = @"SELECT LevelId, XPosition AS ItemXSpawn, YPosition AS ItemYSpawn, Type As ItemType
                                    FROM ItemSpawns
                                    WHERE LevelId = @levelId;";
        
        var parameters = new { LevelId = levelId };
        
        var tiles = connection.Query<MapTile>(queryMapTiles, parameters).ToList();
        var playerSpawn = connection.Query<PlayerSpawn>(queryPlayerSpawn, parameters).FirstOrDefault();
        var itemSpawns = connection.Query<ItemSpawn>(queryItemSpawns, parameters).ToList();

        return new LevelData
        {
            LevelId = levelId,
            MapTiles = tiles,
            PlayerSpawn = playerSpawn,
            ItemSpawns = itemSpawns
        };
    }   
}

