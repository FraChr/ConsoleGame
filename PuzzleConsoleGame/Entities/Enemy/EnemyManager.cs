using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Config.Collision;
using PuzzleConsoleGame.Entities.Items;

namespace PuzzleConsoleGame.Entities.Enemy;

public class EnemyManager
{
    private readonly List<Enemy> _activeEnemies = [];
    private readonly List<Enemy> _enemiesToRemove = [];
    private readonly ItemManager _itemManager;
    private readonly CollisionManager _collisionManager;
    
    private Random _random = new Random();

    public EnemyManager(ItemManager itemManager, CollisionManager collisionManager)
    {
        _itemManager = itemManager;
        _collisionManager = collisionManager;
    }

    public void SpawnEnemy()
    {
        
        var xPos = _random.Next(Boundaries.GameBoundsHorizontalMin + 2, Boundaries.GameBoundsHorizontalMax - 1);
        var yPos = _random.Next(Boundaries.GameBoundsVerticalMin + 2, Boundaries.GameBoundsVerticalMax - 1);
        var enemy = new Enemy(xPos, yPos)
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
            if(!_collisionManager.IsInBounds(activeEnemy)) continue;
            
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