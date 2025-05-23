using System.Diagnostics;
using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Entities.Player;
using PuzzleConsoleGame.Entities.Weapon;
using PuzzleConsoleGame.Input;
using PuzzleConsoleGame.Interfaces;
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
    private readonly InputProcessor _inputProcessor;
    private readonly GameEnvironment _gameEnvironment;
    private readonly Actions _actions;
    private readonly BulletManager _bulletManager;

    public GameLoop(Player player, GameWorld gameWorld, Render render, CollisionManager collisionManager,
        ItemManager itemManager, InputProcessor inputProcessor, GameEnvironment gameEnvironment, Actions actions,
        BulletManager bulletManager)
    {
        _player = player;
        _gameWorld = gameWorld;
        _render = render;
        _collisionManager = collisionManager;
        _itemManager = itemManager;
        _inputProcessor = inputProcessor;
        _gameEnvironment = gameEnvironment;
        _actions = actions;
        _bulletManager = bulletManager;
    }

    public void Run()
    {
        var tokenSource = new CancellationTokenSource();
        var tickRate = TimeSpan.FromMilliseconds(16);
        var stopwatch = new Stopwatch();
        
        try
        {
            InitGame();

            var worldTick = Task.Run(() => _gameEnvironment.GameTick(tokenSource.Token), tokenSource.Token);
            while (_running)
            {
                stopwatch.Restart();
                if(Console.KeyAvailable)
                {
                    _inputProcessor.ProcessControls();
                }
                
                Update();
                RenderFrame();
                
                var elapsed = stopwatch.Elapsed;
                var sleep = tickRate - elapsed;

                if (sleep > TimeSpan.Zero)
                {
                    Thread.Sleep(sleep);
                }
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
            tokenSource.Cancel();
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
        var allEntities = new List<IEntity>();
        allEntities.AddRange(_itemManager.GetSpawnedItems());
    
        foreach (var interactable in allEntities)
        {
            _collisionManager.CheckInteraction(_player, interactable);
    
            switch (interactable)
            {
                case IPointsItem pointsItem when interactable.IsActive:
                    _score += pointsItem.Value;
                    _itemManager.RemoveItem(interactable);
                    break;
            }
        }
        _render.PrintAllGameObjects(allEntities);
        allEntities.Clear();
    }

    private void RenderFrame()
    {
        _render.DrawScore(_score, _player);
    }

    private void InitGame()
    {
        _render.Draw(_player);
        _render.DrawBoundaries(_gameWorld);
        _itemManager.SpawnItems<Coin>();
        foreach (var item in _itemManager.GetSpawnedItems())
        {
            _render.Draw(item);
        }


        RenderFrame();
    }
}