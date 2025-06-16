using Dapper;
using Microsoft.Data.SqlClient;
using PuzzleConsoleGame.Core;

namespace PuzzleConsoleGame.DataBaseAPI;

public class DbApi
{
    private string _connectionString =
        "Data Source=localhost;Database=GameWorld;Integrated Security=true;Connect Timeout=30;Encrypt=true;TrustServerCertificate=true;";


    public Map[] GetGameMap(int levelId)
    {
        var connection = new SqlConnection(_connectionString);
        var query = @"SELECT 
                        M.LevelId,
                        M.XPosition,
                        M.YPosition,
                        W.Symbol,
                        W.Description,
                        PS.XPosition as XSpawn,
                        PS.YPosition as YSpawn
                    From
                        Map M
                    JOIN 
                        WallTypes W On M.WallTypeId = W.WallTypeId
                    JOIN
                        PlayerSpawn PS ON M.LevelId = PS.LevelId
                    WHERE
                        M.LevelId = @LevelId
                    ORDER BY
                        M.YPosition, M.XPosition";
        
        var parameters = new { LevelId = levelId };
        
        var map = connection.Query<Map>(query, parameters).ToArray();
        return map;
    }   
}

