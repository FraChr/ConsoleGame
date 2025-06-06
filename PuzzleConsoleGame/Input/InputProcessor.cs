﻿using PuzzleConsoleGame.Entities.Character;
using PuzzleConsoleGame.Entities.Player;
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
            _playerManager.UpdatePlayer(movement.Value.dx, movement.Value.dy);
        }
    }
    
    public void SetPlayer(Character player)
    {
        _action.SetPlayer(player);
    }
}