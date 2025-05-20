using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Enemy;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Core;

public class GameEnvironment(Render render, GameWorld gameWorld, Player player)
{
    public async Task GameTick(CancellationToken token)
    {
        var enemy = new Enemy(EnemyData.StartPositionHorizontal, EnemyData.StartPositionVertical, gameWorld, player);
        while (!token.IsCancellationRequested)
        {
            render.Draw(enemy, ' ');
            enemy.Move();
            render.Draw(enemy);
            await Task.Delay(500);
        }
    }
}