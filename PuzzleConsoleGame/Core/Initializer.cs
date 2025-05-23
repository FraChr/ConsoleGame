using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Core.CoreLoop;
using PuzzleConsoleGame.Core.EnvironmentLoop;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Entities.Player;
using PuzzleConsoleGame.Entities.Weapon;
using PuzzleConsoleGame.Input;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Core;

public class Initializer
{
    public GameLoop Initialize()
    {
        var gameWorld = new GameWorld(Boundaries.GameBoundsVerticalMax, Boundaries.GameBoundsHorizontalMax);
        var itemManager = new ItemManager(gameWorld);
        
        var player = new Player(PlayerStart.PlayerStartPosHoriz, PlayerStart.PlayerStartPosVert);
        var render = new Render();
        var collisionManager = new CollisionManager(itemManager, gameWorld);
        var bulletManager = new BulletManager(render, collisionManager);

        var gameUpdate = new LogicProcessor(itemManager, player, collisionManager, render);
        var environmentProcessor = new EnvironmentProcessor(bulletManager, collisionManager, player);
        var actions = new Actions(player, bulletManager);
        var playerManager = new PlayerManager(render, collisionManager, player);
        var input = new InputProcessor(actions, playerManager);
        var gameEnvironment = new GameEnvironment(render, gameWorld, player, itemManager, actions, bulletManager, collisionManager, environmentProcessor);
        
        
        return new GameLoop(player, gameWorld, render, itemManager, input, gameEnvironment, gameUpdate);
    }
}