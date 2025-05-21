using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Player;
using PuzzleConsoleGame.Entities.Weapon;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Input;

public class Actions
{
    private readonly Player _player;
    private readonly BulletManager _bulletManager;
    public Actions(Player player, BulletManager bulletManager)
    {
        _player = player;
        _bulletManager = bulletManager;
    }

    public void Shoot()
    {
        _bulletManager.SpawnBullet(_player);
    }
}