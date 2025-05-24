using System.Diagnostics;
using PuzzleConsoleGame.Entities;
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
    private readonly Player _player;
    private readonly GameWorld _gameWorld;
    private readonly Render _render;
    private readonly ItemManager _itemManager;
    private readonly InputProcessor _inputProcessor;
    private readonly BulletManager _bulletManager;
    private readonly EnemyManager _enemyManager;
    private readonly CollisionManager _collisionManager;
    private PlayerManager _playerManager;

    public Game(
        Player player,
        GameWorld gameWorld,
        Render render,
        ItemManager itemManager,
        InputProcessor inputProcessor,
        BulletManager bulletManager,
        EnemyManager enemyManager,
        CollisionManager collisionManager, PlayerManager playerManager)
    {
        _player = player;
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


            _enemyManager.UpdateAndRenderEnemies();
            _bulletManager.UpdateAndRenderBullets();
            _itemManager.UpdateItems();


            HandleInteractions();

            RenderFrame();

            var elapsed = stopwatch.ElapsedMilliseconds;
            var sleepTime = frameTimeMs - (int)elapsed;
            if (sleepTime > 0)
                Thread.Sleep(sleepTime);
        }

        CleanUp();
    }

    private void InitGame()
    {
        _render.DrawBoundaries(_gameWorld);
        _itemManager.SpawnItems(() => new Coin(), 10, 10);
        _enemyManager.SpawnEnemy(_player);
        foreach (var item in _itemManager.GetSpawnedItems().OfType<IRenderable>())
        {
            _render.Draw(item);
        }

        RenderFrame();
    }

    private void HandleInteractions()
    {
        var allInteractables = new List<IInteractable>();
        allInteractables.AddRange(_bulletManager.GetSpawnedBullets());
        allInteractables.AddRange(_enemyManager.GetActiveEnemies());
        allInteractables.AddRange(_itemManager.GetSpawnedItems());

        foreach (var entity in allInteractables)
        {
            _collisionManager.CheckInteraction(_player, entity);
        }

        _render.PrintAllGameObjects(allInteractables);
    }

    private void RenderFrame()
    {
        _render.DrawScore(_player);
        _render.Draw(_player);
        foreach (var enemy in _enemyManager.GetActiveEnemies().OfType<IRenderable>())
        {
            _render.Draw(enemy);
        }

        foreach (var item in _itemManager.GetSpawnedItems().OfType<IRenderable>())
        {
            _render.Draw(item);
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