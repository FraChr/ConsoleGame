using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Player;
using PuzzleConsoleGame.Rendering;
namespace PuzzleConsoleGame.Input;

public class InputProcessor
{
    private readonly InputManager _inputManager;
    private readonly Actions _action;
    private readonly PlayerManager _playerManager;

    public InputProcessor(Actions action, PlayerManager playerManager)
    {
        _action = action;
        _inputManager = new InputManager(_action);
        _playerManager = playerManager;
    }

    public void ProcessControls()
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

        if (movement != null)
        {
            _playerManager.UpdateAndRenderPlayer(movement.Value.dx, movement.Value.dy);
        }
    }
}