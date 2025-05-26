using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Interfaces;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Items;



public class Item : IPointsItem, IRenderable
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    
    public int PreviousX { get;  set; }
    public int PreviousY { get;  set; }
    public char Symbol { get; set; } = ItemData.Coin;
    public bool IsActive { get; set; }
    public int Value { get; set; } = ItemData.CoinValue;

    protected Item()
    {
    }

    public virtual void Interact(IInteractable other)
    {
    }
}