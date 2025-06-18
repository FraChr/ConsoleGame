using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities.Weapon;

namespace PuzzleConsoleGame.Entities.Items;

public class Upgrade : Item
{
    public int Cost { get; set; }
    public override EntityType Type => EntityType.Upgrade;
    
    public Upgrade()
    {
        Symbol = ItemData.Upgrade;
        Value = ItemData.UpgradeValue;
        Cost = ItemData.UpdgradeCost;
    }

    
}