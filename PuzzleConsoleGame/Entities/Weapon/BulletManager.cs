using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Entities.Items;

namespace PuzzleConsoleGame.Entities.Weapon;

public class BulletManager : IInteractionHandler
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
        var bullet = new Bullet(position.XPosition, position.YPosition, facing, this)
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
            bullet.Update();

            if (_collisionManager.IsInBounds(bullet)) continue;
            bullet.IsActive = false;
            _bulletsToRemove.Add(bullet);
        }


        // _activeBullets = _activeBullets.Where(bullet => bullet.IsActive).ToList();
        // _bulletsToRemove.Clear();
    }

    public void RemoveBullet(Bullet bullet)
    {
        if (!_bulletsToRemove.Contains(bullet))
        {
            _bulletsToRemove.Add(bullet);
        }
        // _activeBullets.Remove(bullet);
    }

    public List<IInteractable> GetSpawnedBullets()
    {
        return _activeBullets.OfType<IInteractable>().ToList();
    }

    public void HandleInteraction(IInteractable source, IInteractable target)
    {
        if (source is not Bullet { IsActive: true } bullet) return;
        switch (target)
        {
            case Player.Player player:
                player.TakeDamage(bullet);
                break;
            case Enemy.Enemy enemy:
                enemy.TakeDamage(bullet);
                break;
        }

        bullet.IsActive = false;
        RemoveBullet(bullet);
    }
}