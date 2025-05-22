using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Interfaces;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Weapon;

public class BulletManager
{
    private readonly List<Bullet> _activeBullets = [];
    private readonly List<Bullet> _bulletsToRemove = [];
    private readonly Render _render;
    private readonly CollisionManager _collisionManager;

    public BulletManager(Render render, CollisionManager collisionManager)
    {
        _render = render;
        _collisionManager = collisionManager;
    }


    public void SpawnBullet(Player.Player player)
    {
        var bullet = new Bullet(player);
        _activeBullets.Add(bullet);
    }

    public void UpdateAndRenderBullets()
    {
        foreach (var bullet in _activeBullets)
        {
            _render.Draw(bullet, WeaponData.Remove);
            bullet.Move();

            if (!_collisionManager.IsInBounds(bullet))
            {
                _bulletsToRemove.Add(bullet);
                continue;
            }

            _render.Draw(bullet);
        }

        foreach (var bullet in _bulletsToRemove)
        {
            _activeBullets.Remove(bullet);
        }
        _bulletsToRemove.Clear();
    }

    public void RemoveBullet(Bullet bullet)
    {
        // if(!_bulletsToRemove.Contains(bullet)){
        //     _bulletsToRemove.Add(bullet);
        // }
        _activeBullets.Remove(bullet);
    }

    public List<IEntity> GetSpawnedBullets()
    {
        return _activeBullets.OfType<IEntity>().ToList(); 
    }
}