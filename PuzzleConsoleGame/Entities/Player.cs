using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities;

public class Player(int xPosition, int yPosition, Direction facing = Direction.Up)
    : IRenderable
{
    public int XPosition { get; set; } = xPosition;
    public int YPosition { get; set; } = yPosition;
    public char Symbol { get; set; } = GetDirectionSymbol(facing);

    public void Move(int deltaX = Movement.NoMove, int deltaY = Movement.NoMove)
    {
        if(deltaX == Movement.MovePositive) Rotate(Direction.Right);
        else if(deltaX == Movement.MoveNegative) Rotate(Direction.Left);
        else if(deltaY == Movement.MoveNegative) Rotate(Direction.Up);
        else if(deltaY == Movement.MovePositive) Rotate(Direction.Down);
        XPosition += deltaX;
        YPosition += deltaY;
    }

    private void Rotate(Direction newDirection)
    {
        Symbol = GetDirectionSymbol(newDirection);
    }

    private static char GetDirectionSymbol(Direction direction)
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