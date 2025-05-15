using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Items;

public class Coin : IRenderable, IInteractable
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public char Symbol { get; set; }
    public bool IsCollected { get; set; }

    public Coin(int x, int y)
    {
        XPosition = x;
        YPosition = y;
        IsCollected = false;
        Symbol = ItemData.Coin;
    }

    public void Interact()
    {
        IsCollected = true;
    }
}