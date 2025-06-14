using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Character;

public class Character : IRenderable
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }

    public int PreviousX { get; set; }
    public int PreviousY { get; set; }
    public char Symbol { get; set; }
    public int Health { get; protected set; } = PlayerData.Health;
    public int Coin { get; set; }
    public Direction Facing { get; set; } = Direction.Up;

    public bool IsActive { get; set; }
    public int Value { get; set; }
    public virtual EntityType Type { get; set; }

    protected Character(int xPosition, int yPosition)
    {
        XPosition = xPosition;
        YPosition = yPosition;
    }

    public virtual void Interact()
    {
        
    }

    public virtual void TakeDamage(IInteractable interactionValue)
    {
        Health -= interactionValue.Value;
    }

    public virtual void GiveHealth(IInteractable interactionValue)
    {
        if (Health >= 100) return;
        Health += interactionValue.Value;
    }
}