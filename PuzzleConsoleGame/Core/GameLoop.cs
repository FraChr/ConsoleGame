using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Core;

public class GameLoop
{
    private Player _player;

    private readonly GameWorld _gameArea;
    private readonly Render _render;

    private readonly CollisionManager _collisionManager;

    private readonly ItemManager _itemManager;

    private bool _running = true;
    private int _score;
    private readonly Input _input;

    public GameLoop()
    {
        _gameArea = new GameWorld(Boundaries.GameBoundsVerticalMax, Boundaries.GameBoundsHorizontalMax);
        _itemManager = new ItemManager(_gameArea);
        _player = new Player(PlayerStart.PlayerStartPosHoriz, PlayerStart.PlayerStartPosVert);
        _render = new Render();
        _collisionManager = new CollisionManager(_itemManager);
        _input = new Input(_player, _render, _gameArea);
    }

    public void Run()
    {
        try
        {
            InitGame();
            while (_running)
            {
                _player = _input.HandleInput();
                Update();
                RenderFrame();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: Unhandled Exception - {e.Message}");
            Console.WriteLine(e.StackTrace);
        }
        finally
        {
            CleanUp();
            Console.WriteLine("Game Exited");
        }
    }

    private void CleanUp()
    {
        _running = false;
        Environment.Exit(-1);
    }

    private void Update()
    {
        foreach (var interactable in _itemManager.GetSpawnedItems())
        {
            _collisionManager.CheckInteraction(_player, interactable);
            if (interactable.IsCollected)
            {
                _score += interactable.Value;
            }
        }
    }

    private void RenderFrame()
    {
        _render.Draw(_player);
        Console.SetCursorPosition(60, 5);
        Console.Write($"score {_score}");
    }

    private void InitGame()
    {
        _render.DrawBoundaries(_gameArea);
        _itemManager.SpawnItems<Coin>();
        foreach (var item in _itemManager.GetSpawnedItems())
        {
            _render.Draw(item);
        }


        RenderFrame();
    }
}