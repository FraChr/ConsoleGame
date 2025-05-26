using PuzzleConsoleGame.Config;


namespace PuzzleConsoleGame.Entities.Player;

public class Player : Character.Character
{
    public Player(int xPosition, int yPosition, Direction facing = Direction.Up) : base(xPosition, yPosition, facing)
    {
        XPosition = xPosition;
        YPosition = yPosition;
        Symbol = PlayerData.CharacterDefault;
        Health = PlayerData.Health;
    }


    public void Update(int deltaX, int deltaY)
    {
        PreviousX = XPosition;
        PreviousY = YPosition;


        Move(deltaX, deltaY);
    }

    private void Move(int deltaX, int deltaY)
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