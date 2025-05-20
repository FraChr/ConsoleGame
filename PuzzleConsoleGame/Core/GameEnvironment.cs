using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Enemy;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Entities.Weapon;
using PuzzleConsoleGame.Input;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Core;

public class GameEnvironment
{
    private readonly Render _render;
    private readonly GameWorld _gameWorld;
    private readonly Player _player;
    private readonly ItemManager _itemManager;
    private readonly Enemy _enemy;
    private readonly Actions _actions;

    public GameEnvironment(Render render, GameWorld gameWorld, Player player, ItemManager itemManager, Actions actions)
    {
        _render = render;
        _gameWorld = gameWorld;
        _player = player;
        _itemManager = itemManager;
        _enemy = new Enemy(EnemyData.StartPositionHorizontal, EnemyData.StartPositionVertical, _gameWorld, _player);
        _actions = actions;
    }

    public async Task GameTick(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            // MoveEnemy(_enemy);
            KeepCoin();
            MoveBullet();
            await Task.Delay(500);
        }
    }

    private void MoveBullet()
    {
        // var activeBullets = new List<Bullet>();
        foreach (var bullet in GameState.Bullets)
        {
            _render.Draw(bullet, ' ');
            bullet.Move();
            _render.Draw(bullet);
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