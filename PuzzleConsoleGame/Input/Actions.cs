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
        Console.Beep(800, 50);
        Thread.Sleep(20);
        Console.Beep(600, 80);
        _bulletManager.SpawnBullet(Player, Player.Facing);
    }
    public void SetPlayer(Character player)
    {
        Player = player;
    }
    
}