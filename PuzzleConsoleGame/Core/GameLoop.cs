using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Input;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Core;

public class GameLoop
{
    private readonly Player _player;

    private readonly GameWorld _gameArea;
    private readonly Render _render;

    private readonly CollisionManager _collisionManager;

    private readonly ItemManager _itemManager;

    private bool _running = true;
    private int _score;
    private readonly Input.Input _input;
    private readonly GameEnvironment _gameEnvironment;
    
    private Actions _actions;

    public GameLoop()
    {
        _gameArea = new GameWorld(Boundaries.GameBoundsVerticalMax, Boundaries.GameBoundsHorizontalMax);
        _itemManager = new ItemManager(_gameArea);
        _player = new Player(PlayerStart.PlayerStartPosHoriz, PlayerStart.PlayerStartPosVert);
        _render = new Render();
        _collisionManager = new CollisionManager(_itemManager);
        
        _actions = new Actions(_player, _render);
        _input = new Input.Input(_player, _render, _gameArea, _actions);
        
        _gameEnvironment = new GameEnvironment(_render, _gameArea, _player, _itemManager, _actions);
        
    }

    public void Run()
    {
        var cts = new CancellationTokenSource();
        try
        {
            InitGame();

            var worldTick = Task.Run(() => _gameEnvironment.GameTick(cts.Token), cts.Token);
            while (_running)
            {
                _input.HandleInput();

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
            cts.Cancel();
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
        _render.DrawScore(_score);
        
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