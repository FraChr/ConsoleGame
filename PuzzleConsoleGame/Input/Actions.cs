using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Character;
using PuzzleConsoleGame.Entities.Weapon;

namespace PuzzleConsoleGame.Input;

public class Actions
{
    private Character? Player {get; set;}
    private readonly BulletManager _bulletManager;
    public Actions(BulletManager bulletManager)
    {
        _bulletManager = bulletManager;
    }

    public void Shoot()
    {
        if(Player == null) return;
        Sound.Gunshot();
        _bulletManager.SpawnBullet(Player, Player.Facing);
        // _bulletManager.SpawnBulletsCircle(Player);

    }
    public void SetPlayer(Character player)
    {
        Player = player;
    }
    
}