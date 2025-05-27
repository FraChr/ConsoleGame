using PuzzleConsoleGame.Config.Collision;
using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Entities.Items;

namespace PuzzleConsoleGame.Entities.Weapon;

public class BulletManager
{
    private List<Bullet> _activeBullets = [];
    private readonly List<Bullet> _bulletsToRemove = [];
    private readonly CollisionManager _collisionManager;

    public BulletManager(CollisionManager collisionManager)
    {
        _collisionManager = collisionManager;
    }


    public void SpawnBullet(IPositioned position, Direction facing)
    {
        var bullet = new Bullet(position.XPosition, position.YPosition, facing)
        {
            IsActive = true
        };
        _activeBullets.Add(bullet);
    }

    public void UpdateBullets()
    {
        foreach (var bullet in _bulletsToRemove)
        {
            _activeBullets.Remove(bullet);
        }
        
        _bulletsToRemove.Clear();
        
        foreach (var bullet in _activeBullets)
        {
            if (!bullet.IsActive)
            {
                _bulletsToRemove.Add(bullet);
                bullet.Value = 0;
            }
            bullet.Update();
        
            if (_collisionManager.IsInBounds(bullet)) continue;
            bullet.IsActive = false;
            _bulletsToRemove.Add(bullet);
        }
    }

    private void RemoveBullet(Bullet bullet)
    {
        if (!_bulletsToRemove.Contains(bullet))
        {
            _bulletsToRemove.Add(bullet);
        }
    }

    public List<IInteractable> GetSpawnedBullets()
    {
        return _activeBullets.OfType<IInteractable>().ToList();
    }
}