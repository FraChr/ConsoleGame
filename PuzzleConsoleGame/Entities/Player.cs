using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities;

public class Player : IRenderable
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public char Symbol { get; set; }
    private Direction Facing { get; }

    public Player(int xPosition, int yPosition, Direction facing = Direction.Up)
    {
        XPosition = xPosition;
        YPosition = yPosition;
        Facing = facing;
        Symbol = GetDirectionSymbol(facing);
    }


    public Player Move(int deltaX = Movement.NoMove, int deltaY = Movement.NoMove)
    {
        return new Player(XPosition + deltaX, YPosition + deltaY, Facing);
    }

    public Player Rotate(Direction newDirection)
    {
        return new Player(XPosition, YPosition, newDirection);
    }

    private char GetDirectionSymbol(Direction direction)
    {
        return direction switch
        {
            Direction.Up => PlayerData.CharacterDefault,
            Direction.Down => PlayerData.CharacterDown,
            Direction.Left => PlayerData.CharacterLeft,
            Direction.Right => PlayerData.CharacterRight,
            _ => PlayerData.CharacterDefault
        };
    }
}