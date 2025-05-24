using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Interfaces;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Items;



public class Coin : IInteractable , IPointsItem, IRenderable
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    
    public int previousX { get;  set; }
    public int previousY { get;  set; }
    public char Symbol { get; set; } = ItemData.Coin;
    public bool IsActive { get; set; }
    public int Value { get; set; } = ItemData.CoinValue;
    

    
    public Coin()
    {
        
    }

    public void Interact(IInteractable other)
    {
        if(!IsActive) return;

        if (other is Player.Player player)
        {
            if(!IsActive) return;
            // _interactionHandler.HandleInteraction(player, this);
            player.Score += Value;
        }
        IsActive = false;
    }
}