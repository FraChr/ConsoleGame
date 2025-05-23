using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Player;
using PuzzleConsoleGame.Entities.Weapon;
using PuzzleConsoleGame.Interfaces;

namespace PuzzleConsoleGame.Core.EnvironmentLoop;

public class EnvironmentProcessor
{
    private readonly BulletManager _bulletManager;
    private readonly CollisionManager _collisionManager;
    private readonly Player _player;

    public EnvironmentProcessor(BulletManager bulletManager, CollisionManager collisionManager, Player player)
    {
        _bulletManager = bulletManager;
        _collisionManager = collisionManager;
        _player = player;
    }

    public void UpdateAuto()
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