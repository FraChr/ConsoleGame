using PuzzleConsoleGame.Config;
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
        
        var player = new Player(PlayerStart.PlayerStartPosHoriz, PlayerStart.PlayerStartPosVert);
        var render = new Render();
        var itemManager = new ItemManager(gameWorld, render);
        var collisionManager = new CollisionManager(itemManager, gameWorld);
        var bulletManager = new BulletManager(render, collisionManager);
        var enemyManager = new EnemyManager(render, collisionManager);
        var actions = new Actions(player, bulletManager);
        var playerManager = new PlayerManager(render, collisionManager, player);
        var input = new InputProcessor(actions, playerManager);
        
        
        return new Game(player, gameWorld, render, itemManager, input, bulletManager, enemyManager, collisionManager, playerManager);
    }
}