using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Config.Collision;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Enemy;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Entities.Player;
using PuzzleConsoleGame.Entities.Weapon;
using PuzzleConsoleGame.Input;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Core;

public class Initializer
{
    public Game Initialize()
    {
        var gameWorld = new GameWorld(Boundaries.GameBoundsVerticalMax, Boundaries.GameBoundsHorizontalMax);
        var render = new Render();
        var itemManager = new ItemManager(gameWorld, render);
        var collisionManager = new CollisionManager();
        var bulletManager = new BulletManager(collisionManager);
        var enemyManager = new EnemyManager(itemManager);
        var actions = new Actions(bulletManager);
        var playerManager = new PlayerManager(collisionManager);
        var input = new InputProcessor(actions, playerManager);
        
        
        return new Game(gameWorld, render, itemManager, input, bulletManager, enemyManager, collisionManager, playerManager);
    }
}