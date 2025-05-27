

namespace PuzzleConsoleGame.Entities.Items;

public class HealthPack : Item
{
    public int Value { get; } = 10;
    public override EntityType Type => EntityType.HealthPack;
    public HealthPack()
    {
        Value = 10;
        Symbol = '=';
    }
}