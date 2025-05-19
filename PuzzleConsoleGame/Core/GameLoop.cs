using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Enemy;
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
    private bool _paused = false;
    private int _score;
    private readonly Input _input;

    // private Enemy _enemy;

    public GameLoop()
    {
        _gameArea = new GameWorld(Boundaries.GameBoundsVerticalMax, Boundaries.GameBoundsHorizontalMax);
        _itemManager = new ItemManager(_gameArea);
        _player = new Player(PlayerStart.PlayerStartPosHoriz, PlayerStart.PlayerStartPosVert);
        _render = new Render();
        _collisionManager = new CollisionManager(_itemManager);
        _input = new Input(_player, _render, _gameArea);
        // _enemy = new Enemy(EnemyData.StartPositionHorizontal, EnemyData.StartPositionVertical, _gameArea, _player);
    }

    public void Run()
    {
        var cts = new CancellationTokenSource();
        try
        {
            InitGame();
            
            var worldTick = Task.Run(() => GameTick(cts.Token), cts.Token);
            while (_running)
            {
                _input.HandleInput();

                if (_paused)
                {
                    Thread.Sleep(100);
                    continue;
                }
                
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

    private async Task GameTick(CancellationToken token)
    {
        var enemy = new Enemy(EnemyData.StartPositionHorizontal, EnemyData.StartPositionVertical, _gameArea, _player);
        while (!token.IsCancellationRequested)
        {
            _render.Draw(enemy, ' ');
            enemy.Move();
            _render.Draw(enemy);
            await Task.Delay(500);
        }
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