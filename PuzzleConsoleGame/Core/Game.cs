using System.Diagnostics;
using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Config.Collision;
using PuzzleConsoleGame.DataBaseAPI;
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
    private Player? Player { get; set; }
    private GameWorld _gameWorld;
    private readonly Render _render;
    private readonly ItemManager _itemManager;
    private readonly InputProcessor _inputProcessor;
    private readonly BulletManager _bulletManager;
    private readonly EnemyManager _enemyManager;
    private readonly CollisionManager _collisionManager;
    private readonly PlayerManager _playerManager;
    

    private readonly Stopwatch _enemySpawnTimer = new();
    private readonly Stopwatch _frameTimer = new();

    public Game(
        // GameWorld gameWorld,
        Render render,
        ItemManager itemManager,
        InputProcessor inputProcessor,
        BulletManager bulletManager,
        EnemyManager enemyManager,
        CollisionManager collisionManager, PlayerManager playerManager)
    {
        // _gameWorld = gameWorld;
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
        
        InitGame();
        _enemySpawnTimer.Start();
        while (_running)
        {
            _frameTimer.Restart();

            if (Console.KeyAvailable)
            {
                _inputProcessor.ProcessControls();
            }

            if (Player != null) _enemyManager.UpdateEnemies(Player.XPosition, Player.YPosition);
            _bulletManager.UpdateBullets();
            _itemManager.UpdateItems();

            if (_enemyManager.GetActiveEnemies().Count == 0)
            {
                _enemyManager.SpawnEnemy();
            }
            if (_enemySpawnTimer.ElapsedMilliseconds >= EnemyData.EnemySpawnIntervalsMs)
            {
                _enemyManager.SpawnEnemy();
                _enemySpawnTimer.Restart();
            }

            HandleInteractions();

            RenderFrame();

            var elapsed = _frameTimer.ElapsedMilliseconds;
            var sleepTime = frameTimeMs - (int)elapsed;
            if (sleepTime > 0)
                Thread.Sleep(sleepTime);
        }

        Console.ReadLine();
    }

    private void InitGame()
    {
        _gameWorld = new GameWorld();

        _gameWorld.GetMapFromDataBase(2);

        var playerSpawn = _gameWorld.GetPlayerSpawn();
        
        var itemSpawn = _gameWorld.GetItemSpawn();

        //var toSpawn = itemSpawn.Where(x => x.XPosition != 0 || x.YPosition != 0);
        _render.DrawBoundaries(_gameWorld);
        Player = _playerManager.SpawnPlayer(playerSpawn.xPosition, playerSpawn.yPosition);
        _inputProcessor.SetPlayer(Player);
        
        foreach (var value in itemSpawn)
        {
            switch (value.ItemType)
            {
                case "Coin":
                    _itemManager.SpawnItem(() => new Coin(), value.ItemXSpawn, value.ItemYSpawn);
                    break;
            }
        }
        
        // _itemManager.SpawnItem(() => new Coin(), 10, 10);
        // _itemManager.SpawnItem(() => new Coin(), 15, 5);
        _enemyManager.SpawnEnemy();
        Sound.Music();
    
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

        allInteractables.Clear();
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

        
        foreach (var wall in _gameWorld.GetMap().OfType<IRenderable>())
        {
            _render.Draw(wall);
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