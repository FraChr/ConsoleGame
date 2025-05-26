using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Interfaces;
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

    
    public virtual void Interact(IInteractable other)
    {
        
    }

    public void TakeDamage(IDamage damage)
    {
        Health -= damage.Damage;
    }
    
    public int GiveHealth(int health)
    {
        int maxHealth = PlayerData.Health;
        if(Health >= maxHealth) return -1;
        Health += health;
        return 0;
    }
}