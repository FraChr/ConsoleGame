using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Enemy;

public class EnemyManager : IInteractionHandler
{
    private readonly Render _render;
    private readonly CollisionManager _collisionManager;
    private readonly List<Enemy> _activeEnemies = [];
    private readonly List<Enemy> _enemiesToRemove = [];
    private readonly ItemManager _itemManager;

    public EnemyManager(Render render, CollisionManager collisionManager, ItemManager itemManager)
    {
        _render = render;
        _collisionManager = collisionManager;
        _itemManager = itemManager;
    }

    public void SpawnEnemy(Player.Player player)
    {
        var enemy = new Enemy(6, 9, player, this)
        {
            IsActive = true
        };
        _activeEnemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        _activeEnemies.ToList().Remove(enemy);
    }

    public void UpdateEnemies()
    {
        foreach (var enemy in _enemiesToRemove)
        {
            // _itemManager.SpawnItems(() => new Coin(), enemy.XPosition, enemy.YPosition);
            _itemManager.RandomSpawnItems();
            _activeEnemies.Remove(enemy);
        }
        _enemiesToRemove.Clear();
        foreach (var activeEnemy in _activeEnemies)
        {
            activeEnemy.Update();
            if (activeEnemy.Health > 0) continue;
            activeEnemy.IsActive = false;
            _enemiesToRemove.Add(activeEnemy);
            // RemoveEnemy(activeEnemy);
        }
    }

    public List<IInteractable> GetActiveEnemies()
    {
        return _activeEnemies.OfType<IInteractable>().ToList();
    }

    public void HandleInteraction(IInteractable source, IInteractable target)
    {
        if (source is not Enemy { IsActive: true } enemy) return;
        if (target is Player.Player player)
        {
            player.TakeDamage(enemy);
        }
    }
}