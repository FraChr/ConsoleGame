namespace PuzzleConsoleGame.Entities.Items;

public class LootItemInfo
{
    public Func<IInteractable> Factory { get; set; }
    public double SpawnProbability { get; set; }
    public int? MaxSpawnCount { get; set; }

    public LootItemInfo(Func<IInteractable> factory, double spawnProbability, int? maxSpawnCount = null)
    {
        Factory = factory;
        SpawnProbability = spawnProbability;
        MaxSpawnCount = maxSpawnCount;
    }
}