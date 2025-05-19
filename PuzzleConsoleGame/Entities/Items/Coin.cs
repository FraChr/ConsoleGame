using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Items;



public class Coin : IRenderable, IInteractable
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public char Symbol { get; set; } = ItemData.Coin;
    public bool IsCollected { get; set; } = false;
    public int Value { get; set; } = 1;

    public void Interact()
    {
        IsCollected = true;
    }
}