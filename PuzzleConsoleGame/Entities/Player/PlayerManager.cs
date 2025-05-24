using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Player;

public class PlayerManager
{
    private readonly Render _render;
    private readonly CollisionManager _collisionManager;
    private readonly Player _player;

    public PlayerManager(Render render, CollisionManager collisionManager, Player player)
    {
        _render = render;
        _collisionManager = collisionManager;
        _player = player;
    }
    
    public void UpdatePlayer(int deltaX, int deltaY)
    {
        var newPoint = new RenderPoint(_player.XPosition + deltaX, _player.YPosition + deltaY);
        if (_collisionManager.IsInBounds(newPoint))
        {
            _player.Update(deltaX, deltaY);
        }
    }
    
    


}