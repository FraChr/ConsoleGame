using PuzzleConsoleGame.Entities.Items;

namespace PuzzleConsoleGame.Entities.Enemy;

public class EnemyManager
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
        var enemy = new Enemy(6, 9)
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
}