using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Rendering;
namespace PuzzleConsoleGame.Input;

public class Input
{
    private readonly InputManager _inputManager;
    private readonly Actions _action;
    private readonly Player _player;
    private readonly Render _render;
    private readonly GameWorld _gameWorld;

    public Input(Player player, Render render, GameWorld gameWorld, Actions action)
    {
        _player = player;
        _render = render;
        _gameWorld = gameWorld;
        _action = action;
        _inputManager = new InputManager(_action);
    }

    public void HandleInput()
    {
        var key = Console.ReadKey(true).Key;


        var action = _inputManager.GetAction(key);

        if (action != null)
        {
            action();
        }


        var movement = _inputManager.GetMovement(key);

        if (key == ConsoleKey.Q)
        {
            Console.Clear();
            Environment.Exit(0);
        }
        
        var previousXPosition = _player.XPosition;
        var previousYPosition = _player.YPosition;

        if (movement != null)
        {
            var newPoint = new RenderPoint(_player.XPosition + movement.Value.dx, _player.YPosition + movement.Value.dy);
            if (_gameWorld.IsInBounds(newPoint))
            {
                _player.Move(movement.Value.dx, movement.Value.dy);
            }
        }
        
        _render.Draw(new RenderPoint(previousXPosition, previousYPosition), PlayerData.Remove);
    }
}