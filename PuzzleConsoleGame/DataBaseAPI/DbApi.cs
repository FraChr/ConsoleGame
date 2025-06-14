using Dapper;
using Microsoft.Data.SqlClient;
using PuzzleConsoleGame.Core;

namespace PuzzleConsoleGame.DataBaseAPI;

public class DbApi
{
    private string _connectionString =
        "Data Source=localhost;Database=GameWorld;Integrated Security=true;Connect Timeout=30;Encrypt=true;TrustServerCertificate=true;";


    public Map[] GetGameMap()
    {
        var connection = new SqlConnection(_connectionString);
        var query = @"SELECT 
                        M.LevelId,
                        M.XPosition,
                        M.YPosition,
                        W.Symbol,
                        W.Description
                    From
                        Map M
                    JOIN 
                        WallTypes W On M.WallTypeId = W.WallTypeId
                    WHERE
                         M.LevelId = 1
                    ORDER BY
                        M.YPosition, M.XPosition";
        var map = connection.Query<Map>(query).ToArray();
        return map;        
    }   
}

