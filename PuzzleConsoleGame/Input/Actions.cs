using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Weapon;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Input;

public class Actions
{
    private Player _player;
    private Render _render;
    public Actions(Player player, Render render)
    {
        _player = player;
        _render = render;
    }

    public void Shoot()
    {
        var bullet = new Bullet(_player);
        GameState.Bullets.Add(bullet);
    }
}