using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Player;

public class Player
    : IRenderable
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public char Symbol { get; set; }
    public int Health { get; set; } = 100;
    public Direction Facing { get; private set; }

    public Player(int xPosition, int yPosition, Direction facing = Direction.Up)
    {
        XPosition = xPosition;
        YPosition = yPosition;
        Symbol = GetDirectionSymbol(facing);
    }

    public void Move(int deltaX = Movement.NoMove, int deltaY = Movement.NoMove)
    {
        if (deltaX == Movement.MovePositive) Rotate(Direction.Right);
        else if (deltaX == Movement.MoveNegative) Rotate(Direction.Left);
        else if (deltaY == Movement.MoveNegative) Rotate(Direction.Up);
        else if (deltaY == Movement.MovePositive) Rotate(Direction.Down);
        XPosition += deltaX;
        YPosition += deltaY;
    }

    private void Rotate(Direction newDirection)
    {
        Facing = newDirection;
        Symbol = GetDirectionSymbol(newDirection);
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