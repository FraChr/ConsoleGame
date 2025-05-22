using System.Collections;
using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Interfaces;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Items;



public class Coin : IInteractable , IPointsItem, IEntity
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public char Symbol { get; set; } = ItemData.Coin;
    public bool IsActive { get; set; }
    public int Value { get; set; } = ItemData.CoinValue;

    public void Interact()
    {
        IsActive = true;
    }
}