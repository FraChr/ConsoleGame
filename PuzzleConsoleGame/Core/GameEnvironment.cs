using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Enemy;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Core;

public class GameEnvironment
{
    private readonly Render _render;
    private readonly GameWorld _gameWorld;
    private readonly Player _player;
    private readonly ItemManager _itemManager;
    private readonly Enemy _enemy;

    public GameEnvironment(Render render, GameWorld gameWorld, Player player, ItemManager itemManager)
    {
        _render = render;
        _gameWorld = gameWorld;
        _player = player;
        _itemManager = itemManager;
        _enemy = new Enemy(EnemyData.StartPositionHorizontal, EnemyData.StartPositionVertical, _gameWorld, _player);
    }

    public async Task GameTick(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            MoveEnemy(_enemy);
            KeepCoin();   
            await Task.Delay(500);
        }
    }

    private void MoveEnemy(Enemy enemy)
    {
        _render.Draw(enemy, ' ');
        enemy.Move();
        _render.Draw(enemy);
    }
    
    private void KeepCoin()
    {
        foreach (var spawnedItem in _itemManager.GetSpawnedItems().Where(spawnedItem => !spawnedItem.IsCollected))
        {
            _render.Draw(spawnedItem);
        }
    }
}