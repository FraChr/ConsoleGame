using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Weapon;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Input;

public class Actions
{
    private readonly Player _player;
    private Render _render;
    private readonly BulletManager _bulletManager;
    public Actions(Player player, Render render, BulletManager bulletManager)
    {
        _player = player;
        _render = render;
        _bulletManager = bulletManager;
    }

    public void Shoot()
    {
        _bulletManager.SpawnBullet(_player);
    }
}