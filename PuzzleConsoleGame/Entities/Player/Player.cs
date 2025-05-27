using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities.Items;


namespace PuzzleConsoleGame.Entities.Player;

public class Player : Character.Character
{
    public override EntityType Type => EntityType.Player;
    public Player(int xPosition, int yPosition) : base(xPosition, yPosition)
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

        if (Health >= 100)
        {
            Health = 100;
        }
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
    
    public override void GiveHealth(IInteractable interactionValue)
    {
        if (Health >= 100) return;
        Health += interactionValue.Value;
    }

    public void GivePoints(IInteractable interactionValue)
    {
        Score += interactionValue.Value;
    }

    public override void TakeDamage(IInteractable interactionValue)
    {
        Health -= interactionValue.Value;
    }
}