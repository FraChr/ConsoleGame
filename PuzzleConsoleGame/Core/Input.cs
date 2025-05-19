using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Input;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Core;

public class Input(Player player, Render render, GameWorld gameWorld)
{
    private readonly InputManager _inputManager = new();
    
    public void HandleInput()
    {
        var key = Console.ReadKey(true).Key;
        
        var movement = _inputManager.GetMovement(key);

        if (key == ConsoleKey.Q)
        {
            Console.Clear();
            Environment.Exit(0);
        }
        
        var previousXPosition = player.XPosition;
        var previousYPosition = player.YPosition;

        if (movement != null)
        {
            var newPoint = new RenderPoint(player.XPosition + movement.Value.dx, player.YPosition + movement.Value.dy);
            if (gameWorld.IsInBounds(newPoint))
            {
                player.Move(movement.Value.dx, movement.Value.dy);
            }
        }
        
        render.Draw(new RenderPoint(previousXPosition, previousYPosition), PlayerData.Remove);
    }
}