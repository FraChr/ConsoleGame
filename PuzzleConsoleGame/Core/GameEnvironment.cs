using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Enemy;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Entities.Player;
using PuzzleConsoleGame.Entities.Weapon;
using PuzzleConsoleGame.Input;
using PuzzleConsoleGame.Interfaces;
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
    private readonly BulletManager _bulletManager;
    private readonly CollisionManager _collisionManager;
    private int _score;

    public GameEnvironment(Render render, GameWorld gameWorld, Player player, ItemManager itemManager, Actions actions,
        BulletManager bulletManager, CollisionManager collisionManager)
    {
        _render = render;
        _gameWorld = gameWorld;
        _player = player;
        _itemManager = itemManager;
        _enemy = new Enemy(EnemyData.StartPositionHorizontal, EnemyData.StartPositionVertical, _player);
        _actions = actions;
        _bulletManager = bulletManager;
        _collisionManager = collisionManager;
    }

    public async Task GameTick(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            MoveEnemy(_enemy);
            UpdateAuto();
            _bulletManager.UpdateAndRenderBullets();
            KeepCoin();
            await Task.Delay(500);
        }
    }

    private void MoveEnemy(Enemy enemy)
    {
        if (enemy.Health <= 0)
        {
            _render.Draw(enemy, ' ');
            return;
        }
        _render.Draw(enemy, EnemyData.Remove);
        enemy.Move();
        _render.Draw(enemy);
    }

    private void KeepCoin()
    {
        foreach (var spawnedItem in _itemManager.GetSpawnedItems().Where(spawnedItem => !spawnedItem.IsActive))
        {
            _render.Draw(spawnedItem);
        }
    }
    
    private void UpdateAuto()
    {
        var allEntities = new List<IEntity>();
        allEntities.AddRange(_bulletManager.GetSpawnedBullets());
        
        foreach (var interactable in allEntities)
        {
            _collisionManager.CheckInteraction(_player, interactable);
            

            switch (interactable)
            {
                case IDamage damage when interactable.IsActive:
                    _player.TakeDamage(damage);
                    if(interactable is Bullet bullet){
                        _bulletManager.RemoveBullet(bullet);
                    }
                    interactable.IsActive = false;
                    break;
            }
        }
        
        allEntities.Clear();
    }
}