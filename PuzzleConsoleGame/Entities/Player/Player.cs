using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Interfaces;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Player;

public class Player
    : IRenderable, IInteractable, IPositioned
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    
    public int PreviousX { get;  set; }
    public int PreviousY { get;  set; }
    public char Symbol { get; private set; }
    public int Health { get;  private set; } = PlayerData.Health;
    public int Score { get; set; }
    public Direction Facing { get; private set; }
    
    public bool IsActive { get; set; }

    public Player(int xPosition, int yPosition, Direction facing = Direction.Up)
    {
        XPosition = xPosition;
        YPosition = yPosition;
        Symbol = GetDirectionSymbol(facing);
    }

    
    public void Interact(IInteractable other)
    {
        
    }

    public void Update(int deltaX, int deltaY)
    {
        PreviousX = XPosition;
        PreviousY = YPosition;
        
        Move(deltaX, deltaY);
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

    public void TakeDamage(IDamage damage)
    {
        Health -= damage.Damage;
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