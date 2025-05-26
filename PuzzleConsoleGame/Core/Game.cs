using System.Diagnostics;
using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Character;
using PuzzleConsoleGame.Entities.Enemy;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Entities.Player;
using PuzzleConsoleGame.Entities.Weapon;
using PuzzleConsoleGame.Input;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Core;

public class Game
{
    private bool _running = true;
    private Character? Player {get; set;}
    private readonly GameWorld _gameWorld;
    private readonly Render _render;
    private readonly ItemManager _itemManager;
    private readonly InputProcessor _inputProcessor;
    private readonly BulletManager _bulletManager;
    private readonly EnemyManager _enemyManager;
    private readonly CollisionManager _collisionManager;
    private readonly PlayerManager _playerManager;

    public Game(
        GameWorld gameWorld,
        Render render,
        ItemManager itemManager,
        InputProcessor inputProcessor,
        BulletManager bulletManager,
        EnemyManager enemyManager,
        CollisionManager collisionManager, PlayerManager playerManager)
    {
        _gameWorld = gameWorld;
        _render = render;
        _itemManager = itemManager;
        _inputProcessor = inputProcessor;
        _bulletManager = bulletManager;
        _enemyManager = enemyManager;
        _collisionManager = collisionManager;
        _playerManager = playerManager;
    }

    public void Run()
    {
        const int frameTimeMs = 16;
        var stopwatch = new Stopwatch();

        InitGame();

        while (_running)
        {
            stopwatch.Restart();
            
            if (Console.KeyAvailable)
            {
                _inputProcessor.ProcessControls();
            }

            if (Player != null) _enemyManager.UpdateEnemies(Player.XPosition, Player.YPosition);
            _bulletManager.UpdateBullets();
            _itemManager.UpdateItems();
            
            HandleInteractions();

            RenderFrame();

            var elapsed = stopwatch.ElapsedMilliseconds;
            var sleepTime = frameTimeMs - (int)elapsed;
            if (sleepTime > 0)
                Thread.Sleep(sleepTime);
        }
        
    }

    private void InitGame()
    {
        // _player.IsActive = true;
        _render.DrawBoundaries(_gameWorld);
        Player = _playerManager.SpawnPlayer(PlayerStart.PlayerStartPosHoriz, PlayerStart.PlayerStartPosVert);
        _inputProcessor.SetPlayer(Player);
        _itemManager.SpawnItem(() => new Coin(), 10, 10);
        _itemManager.SpawnItem(() => new Coin(), 15, 5);
        _enemyManager.SpawnEnemy();

        RenderFrame();
    }
    
    private void HandleInteractions()
    {
        if (_playerManager.IsPlayerDead())
        {
            if (Player != null) Player.IsActive = false;
            CleanUp();
        }
        
        var allInteractables = new List<IInteractable>();
        allInteractables.AddRange(_bulletManager.GetSpawnedBullets());
        allInteractables.AddRange(_enemyManager.GetActiveEnemies());
        allInteractables.AddRange(_itemManager.GetSpawnedItems());
        if (Player != null) allInteractables.AddRange(Player);

        _collisionManager.CheckInteraction(allInteractables);

        // _render.PrintAllGameObjects(allInteractables);
    }

    private void RenderFrame()
    {
        if (Player != null)
        {
            _render.DrawScore(Player);
            _render.Draw(Player);
        }

        foreach (var enemy in _enemyManager.GetActiveEnemies().OfType<IRenderable>())
        {
            _render.Draw(enemy);
        }

        foreach (var item in _itemManager.GetSpawnedItems().OfType<IRenderable>())
        {
            _render.Draw(item);
        }

        foreach (var bullet in _bulletManager.GetSpawnedBullets().OfType<IRenderable>())
        {
            _render.Draw(bullet);
        }
    }

    private void CleanUp()
    {
        _running = false;
        Console.Clear();
        Console.WriteLine("Game Over");
        Environment.Exit(0);
    }
}