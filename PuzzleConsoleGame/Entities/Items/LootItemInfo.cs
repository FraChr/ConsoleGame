namespace PuzzleConsoleGame.Entities.Items;

public class LootItemInfo
{
    public Func<IInteractable> Factory { get; }
    public double SpawnProbability { get; }
    public int? MaxSpawnCount { get; }

    public LootItemInfo(Func<IInteractable> factory, double spawnProbability, int? maxSpawnCount = null)
    {
        Factory = factory;
        SpawnProbability = spawnProbability;
        MaxSpawnCount = maxSpawnCount;
    }
}