using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Character;

public class Character : IRenderable
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    
    public int PreviousX { get;  set; }
    public int PreviousY { get;  set; }
    public char Symbol { get; set; }
    public int Health { get; protected set; } = PlayerData.Health;
    public int Score { get; set; }
    public Direction Facing { get; set; } = Direction.Up;
    
    public bool IsActive { get; set; }

    protected Character(int xPosition, int yPosition,  Direction facing = Direction.Up)
    {
        XPosition = xPosition;
        YPosition = yPosition;
    }


    public virtual EntityType Type { get; }
    public int Value { get; }

    public virtual void Interact()
    {
        
    }

    public virtual void TakeDamage(IInteractable interactionValue)
    {
        Health -= interactionValue.Value;
    }
    
    public virtual void GiveHealth(IInteractable interactionValue)
    {
        // int maxHealth = PlayerData.Health;
        // if(Health >= maxHealth) return -1;
        
        if (Health >= 100) return;
        Health += interactionValue.Value;
        // return 0;
    }
}