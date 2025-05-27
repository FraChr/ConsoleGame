using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Config.Collision;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Player;

public class PlayerManager
{
    private readonly CollisionManager _collisionManager;
    private Player? Player { get; set; }


    public PlayerManager(CollisionManager collisionManager)
    {
        _collisionManager = collisionManager;
    }

    public void UpdatePlayer(int deltaX, int deltaY)
    {
        if (Player == null) return;
        var newPoint = new RenderPoint(Player.XPosition + deltaX, Player.YPosition + deltaY);
        if (_collisionManager.IsInBounds(newPoint))
        {
            Player.Update(deltaX, deltaY);
        }
    }

    public bool IsPlayerDead()
    {
        return Player is { Health: <= 0 };
    }

    public Player SpawnPlayer(int xPosition, int yPosition)
    {
        var player = new Player(xPosition, yPosition)
        {
            IsActive = true
        };
        Player = player;
        return player;
    }
}