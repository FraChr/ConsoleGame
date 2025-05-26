namespace PuzzleConsoleGame.Entities.Items;

public class HealthPack : Item
{
    public HealthPack()
    {
        Value = 10;
        Symbol = '=';
    }
    
    // TODO: HEALTH PACK SIDE: make some better solution to detect if player is picking up item or not!!!
    public override void Interact(IInteractable other)
    {
        if (!IsActive) return;
        if (other is not Character.Character player) return;
        
        var x = player.GiveHealth(Value);
        if (x == -1) return;
        IsActive = false;
    }
}