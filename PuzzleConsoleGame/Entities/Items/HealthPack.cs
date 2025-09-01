

using PuzzleConsoleGame.Config;

namespace PuzzleConsoleGame.Entities.Items;

public class HealthPack : Item
{ 
    public override EntityType Type => EntityType.HealthPack;
    public HealthPack()
    {
        Value = ItemData.HealthValue;
        Symbol = ItemData.Health;
    }
}