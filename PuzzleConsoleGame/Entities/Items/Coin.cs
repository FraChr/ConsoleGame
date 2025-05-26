using PuzzleConsoleGame.Config;

namespace PuzzleConsoleGame.Entities.Items;



public class Coin : Item
{
    public Coin()
    {
        Symbol = ItemData.Coin;
        Value = ItemData.CoinValue;
    }

    public override void Interact(IInteractable other)
    {
        if(!IsActive) return;

        if (other is Character.Character player)
        {
            if(!IsActive) return;
            // _interactionHandler.HandleInteraction(player, this);
            player.Score += Value;
        }
        IsActive = false;
    }
}