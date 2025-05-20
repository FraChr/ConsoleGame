using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Input;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Core;

public class Initializer
{
    public GameLoop Initialize()
    {
        var gameArea = new GameWorld(Boundaries.GameBoundsVerticalMax, Boundaries.GameBoundsHorizontalMax);
        var itemManager = new ItemManager(gameArea);
        var player = new Player(PlayerStart.PlayerStartPosHoriz, PlayerStart.PlayerStartPosVert);
        var render = new Render();
        var collisionManager = new CollisionManager(itemManager);
        var actions = new Actions(player, render);
        var input = new Input.Input(player, render, gameArea, actions);
        var gameEnvironment = new GameEnvironment(render, gameArea, player, itemManager, actions);
        
        return new GameLoop(player, gameArea, render, collisionManager, itemManager, input, gameEnvironment, actions);
    }
}