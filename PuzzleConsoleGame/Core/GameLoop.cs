using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Input;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Core;



public class GameLoop
{
    private Player _player;

    private readonly GameWorld _gameArea;
    private readonly InputManager _inputManager;
    private readonly Render _render;

    private readonly CollisionManager _collisionManager;

    private Coin _coin;
    
    private const bool Running = true;

    public GameLoop()
    {
        _gameArea = new GameWorld(Boundaries.GameBoundsHorizontalMax, Boundaries.GameBoundsVerticalMax);
        _player = new Player(PlayerStart.PlayerStartPosHoriz, PlayerStart.PlayerStartPosVert);
        _inputManager = new InputManager(_gameArea);
        _render = new Render();
        _collisionManager = new CollisionManager();
        _coin = new Coin(12, 10);
    }

    public void Run()
    {
        InitGame();
        while (Running)
        {
            HandleInput();
            Update();
            RenderFrame();
        }
    }

    private void HandleInput()
    {
        var nextPlayer = _inputManager.PlayerControls(_player);
        if (nextPlayer == _player) return;
        _render.Draw(_player, PlayerData.Remove);
        _player = nextPlayer;
    }

    private void Update()
    {
        _collisionManager.CheckInteraction(_player, _coin);
    }

    private void RenderFrame()
    {
        if (!_coin.IsCollected)
        {
            _render.Draw(_coin);
        }
        _render.Draw(_player);
    }

    private void InitGame()
    {
        _render.DrawBoundaries(_gameArea);
        RenderFrame();
    }
    
}