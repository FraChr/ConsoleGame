using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Items;

public class ItemManager
{
    private readonly Dictionary<int, LootItemInfo> _lootGenerationMap = new()
    {
        { 1, new LootItemInfo(() => new Coin(), 0.5) },
        { 2,new LootItemInfo(() => new HealthPack(), 0.2, 3) }
    };


    private readonly List<IInteractable> _spawnedItems = [];
    private readonly Random _random = new();


    public void SpawnRandomItem(int positionX = 0, int positionY = 0)
    {
        var entry = _lootGenerationMap.ElementAt(_random.Next(_lootGenerationMap.Count));

        var lootInfo = entry.Value;

        if (!ShouldSpawnItem(lootInfo) || !CanSpawnItem(lootInfo)) return;
        
        var instance = lootInfo.Factory();

        if (instance is IPositioned interactable)
        {
            interactable.XPosition = positionX;
            interactable.YPosition = positionY;
        }

        instance.IsActive = true;

        _spawnedItems.Add(instance);
    }

    private bool ShouldSpawnItem(LootItemInfo lootInfo)
    {
        var chance = _random.NextDouble();
        return chance <= lootInfo.SpawnProbability;
    }
    private bool CanSpawnItem(LootItemInfo lootInfo)
    {
        if (lootInfo.MaxSpawnCount is not { } max) return true;
        
        var itemType = lootInfo.Factory().GetType();
        var currentCount = _spawnedItems.Count(item => item.GetType() == itemType);

        return currentCount < max;
    }


    public void SpawnItem<T>(Func<T> factory, int x, int y) where T : IInteractable, IPositioned
    {
        var item = factory();
        item.XPosition = x;
        item.YPosition = y;
        item.IsActive = true;
        _spawnedItems.Add(item);

        // var itemType = typeof(T);
        //
        // if (!_maxItemsPerType.TryGetValue(itemType, out var maxAllowed))
        // {
        //     return;
        // }

        // var currentCount = _spawnedItems.Count(i => i is T);
        // for (var i = currentCount; i < maxAllowed; i++)
        // {
        //     var item = new T();
        //     SpawnItem(item);
        // }
    }


    public void UpdateItems()
    {
        foreach (var item in _spawnedItems.ToList().Where(item => !item.IsActive))
        {
            RemoveItem(item);
        }
    }

    public List<IInteractable> GetSpawnedItems()
    {
        return _spawnedItems;
    }

    private void RemoveItem(IInteractable item)
    {
        _spawnedItems.Remove(item);
    }
}