using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Interfaces;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Weapon;

public class BulletManager : IInteractionHandler
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
        var bullet = new Bullet(player, this)
        {
            IsActive = true
        };
        _activeBullets.Add(bullet);
    }

    public void UpdateAndRenderBullets()
    {
        foreach (var bullet in _activeBullets)
        {
            _render.Draw(bullet, WeaponData.Remove);
            // bullet.Move();
            bullet.Update();

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