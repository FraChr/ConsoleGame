using PuzzleConsoleGame.Entities.Items;

namespace PuzzleConsoleGame.Entities.Enemy;

public class EnemyManager : IInteractionHandler
{
    private readonly List<Enemy> _activeEnemies = [];
    private readonly List<Enemy> _enemiesToRemove = [];
    private readonly ItemManager _itemManager;

    public EnemyManager(ItemManager itemManager)
    {
        _itemManager = itemManager;
    }

    public void SpawnEnemy()
    {
        var enemy = new Enemy(6, 9, this)
        {
            IsActive = true
        };
        _activeEnemies.Add(enemy);
    }


    public void UpdateEnemies(int positionX, int positionY)
    {
        foreach (var enemy in _enemiesToRemove)
        {
            _itemManager.SpawnRandomItem(enemy.XPosition, enemy.YPosition);
            _activeEnemies.Remove(enemy);
            RemoveEnemy(enemy);
        }

        _enemiesToRemove.Clear();
        foreach (var activeEnemy in _activeEnemies)
        {
            activeEnemy.Update(activeEnemy, positionX, positionY);
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

    private void RemoveEnemy(Enemy enemy)
    {
        // _activeEnemies.ToList().Remove(enemy);
        // _enemiesToRemove.Remove(enemy);
    }

    // private void Update(Enemy activeEnemy, int positionX, int positionY)
    // {
    //     activeEnemy.PreviousX = activeEnemy.XPosition;
    //     activeEnemy.PreviousY = activeEnemy.YPosition;
    //
    //     if (activeEnemy.MovementCooldown > 0)
    //     {
    //         activeEnemy.MovementCooldown--;
    //         return;
    //     }
    //
    //     activeEnemy.Move(activeEnemy, positionX, positionY);
    //     activeEnemy.MovementCooldown = activeEnemy.MoveInterval;
    // }
}