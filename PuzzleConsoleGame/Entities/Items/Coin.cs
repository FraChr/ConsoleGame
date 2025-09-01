using PuzzleConsoleGame.Config;

namespace PuzzleConsoleGame.Entities.Items;



public class Coin : Item
{
    public override EntityType Type => EntityType.Coin;
    public Coin()
    {
        Symbol = ItemData.Coin;
        Value = ItemData.CoinValue;
    }
}