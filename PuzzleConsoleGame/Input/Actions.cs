using PuzzleConsoleGame.Entities.Character;
using PuzzleConsoleGame.Entities.Weapon;

namespace PuzzleConsoleGame.Input;

public class Actions
{
    private Character? Player {get; set;}
    private readonly BulletManager _bulletManager;
    public Actions(BulletManager bulletManager)
    {
        // _player = player;
        _bulletManager = bulletManager;
    }

    public void Shoot()
    {
        if(Player == null) return;
        // _bulletManager.SpawnBullet(_player.XPosition, _player.YPosition, _player.Facing);
        _bulletManager.SpawnBullet(Player, Player.Facing);
    }
    public void SetPlayer(Character player)
    {
        Player = player;
    }
    
}