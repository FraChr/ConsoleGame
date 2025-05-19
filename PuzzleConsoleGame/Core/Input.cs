using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Input;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Core;

public class Input(Player player, Render render, GameWorld gameWorld)
{
    private Player _player = player;
    private readonly InputManager _inputManager = new(gameWorld);
    
    public Player HandleInput()
    {
        var nextPlayer = _inputManager.PlayerControls(_player);
        if (nextPlayer == _player) return _player;
        render.Draw(_player, PlayerData.Remove);
        _player = nextPlayer;

        return _player;
    }
    
}