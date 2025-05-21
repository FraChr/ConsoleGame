using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Entities.Player;
using PuzzleConsoleGame.Input;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Core;

public class GameLoop
{
    private bool _running = true;
    private int _score;

    private readonly Player _player;
    private readonly GameWorld _gameWorld;
    private readonly Render _render;
    private readonly CollisionManager _collisionManager;
    private readonly ItemManager _itemManager;
    private readonly Input.InputProcessor _inputProcessor;
    private readonly GameEnvironment _gameEnvironment;
    private readonly Actions _actions;

    public GameLoop(Player player, GameWorld gameWorld, Render render, CollisionManager collisionManager,
        ItemManager itemManager, InputProcessor inputProcessor, GameEnvironment gameEnvironment, Actions actions)
    {
        _player = player;
        _gameWorld = gameWorld;
        _render = render;
        _collisionManager = collisionManager;
        _itemManager = itemManager;
        _inputProcessor = inputProcessor;
        _gameEnvironment = gameEnvironment;
        _actions = actions;
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
                _inputProcessor.ProcessControls();

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
        _render.DrawBoundaries(_gameWorld);
        _itemManager.SpawnItems<Coin>();
        foreach (var item in _itemManager.GetSpawnedItems())
        {
            _render.Draw(item);
        }


        RenderFrame();
    }
}