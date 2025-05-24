using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Enemy;

public class EnemyManager : IInteractionHandler
{
    private readonly Render _render;
    private readonly CollisionManager _collisionManager;
    private readonly List<Enemy> _activeEnemies = [];

    public EnemyManager(Render render, CollisionManager collisionManager)
    {
        _render = render;
        _collisionManager = collisionManager;
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
        _activeEnemies.Remove(enemy);
    }

    public void UpdateAndRenderEnemies()
    {
        foreach (var activeEnemy in _activeEnemies)
        {
            _render.Draw(activeEnemy, EnemyData.Remove);
            activeEnemy.Update();
            if (activeEnemy.Health <= 0)
            {
                activeEnemy.IsActive = false;
                RemoveEnemy(activeEnemy);
            }
            _render.Draw(activeEnemy);
            
        }
        
    }

    public List<IInteractable> GetActiveEnemies()
    {
        return _activeEnemies.OfType<IInteractable>().ToList();
    }
    public void HandleInteraction(IInteractable source, IInteractable target)
    {
        if(source is not Enemy { IsActive: true } enemy) return;
        if (target is Player.Player player)
        {
            player.TakeDamage(enemy);
        }
    }
}