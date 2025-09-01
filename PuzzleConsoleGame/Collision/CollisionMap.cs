using System.Diagnostics;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Entities.Weapon;

namespace PuzzleConsoleGame.Config.Collision;

public class CollisionMap
{
    
    public static readonly Dictionary<(EntityType source, EntityType target), Action<IInteractable, IInteractable>>
        InteractionMap = new()
        {
            [(EntityType.Bullet, EntityType.Player)] = (source, target) =>
            {
                ((Entities.Player.Player)target).TakeDamage((Bullet)source);
                ((Bullet)source).IsActive = false;
            },
            
            [(EntityType.Bullet, EntityType.Enemy)] = (source, target) =>
            {
                ((Entities.Enemy.Enemy)target).TakeDamage((Bullet)source);
                ((Bullet)source).IsActive = false;
            },
            
            [(EntityType.Enemy, EntityType.Player)] = (source, target) =>
                ((Entities.Player.Player)target).TakeDamage((Entities.Enemy.Enemy)source),
            
            [(EntityType.HealthPack, EntityType.Player)] = (source, target) =>
            {
                ((Entities.Player.Player)target).GiveHealth((HealthPack)source);
                ((HealthPack)source).IsActive = false;
            },
            
            [(EntityType.Coin, EntityType.Player)] = (source, target) =>
            {
                ((Entities.Player.Player)target).GivePoints((Coin)source);
                ((Coin)source).IsActive = false;
            },
            
            [(EntityType.Upgrade, EntityType.Player)] = (source, target) =>
            {
                ((Entities.Player.Player)target).ApplyUpgrade((Upgrade)source);
                // ((Upgrade)source).IsActive = false;
            }
        };
}