using PuzzleConsoleGame.Interfaces;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Items;

public class HealthPack : IInteractable , IPointsItem, IRenderable
{
    public bool IsActive { get; set; }

    public int Value { get; set; } = 10;
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public int PreviousX { get; set; }
    public int PreviousY { get; set; }
    public char Symbol { get; } = '=';
    
    // TODO: HEALTH PACK SIDE: make some better solution to detect if player is picking up item or not!!!
    public void Interact(IInteractable other)
    {
        if (!IsActive) return;
        if (other is not Player.Player player) return;
        
        var x = player.GiveHealth(Value);
        if (x == -1) return;
        IsActive = false;
    }
}