using System.Diagnostics;
using PuzzleConsoleGame.Core.EnvironmentLoop;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Entities.Player;
using PuzzleConsoleGame.Input;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Core.CoreLoop;

public class GameLoop
{
    private bool _running = true;
    private int _score;

    private readonly Player _player;
    private readonly GameWorld _gameWorld;
    private readonly Render _render;
    private readonly ItemManager _itemManager;
    private readonly InputProcessor _inputProcessor;
    private readonly GameEnvironment _gameEnvironment;
    private readonly LogicProcessor _logicProcessor;

    public GameLoop(Player player, GameWorld gameWorld, Render render,
        ItemManager itemManager, InputProcessor inputProcessor, GameEnvironment gameEnvironment, 
        LogicProcessor logicProcessor)
    {
        _player = player;
        _gameWorld = gameWorld;
        _render = render;
        _itemManager = itemManager;
        _inputProcessor = inputProcessor;
        _gameEnvironment = gameEnvironment;
        _logicProcessor = logicProcessor;
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

                _logicProcessor.Update();
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