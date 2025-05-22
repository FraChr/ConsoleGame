using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Interfaces;

namespace PuzzleConsoleGame.Entities.Items;

public class ItemManager(GameWorld gameWorld)
{
    private readonly Dictionary<Type, int> _maxItemsPerType = new()
    {
        { typeof(Coin), 2 }
    };

    private readonly List<IPositioned> _spawnedItems = [];
    private readonly Random _random = new();

    public void SpawnItems<T>() where T : IPositioned, new()
    {
        var itemType = typeof(T);

        if (!_maxItemsPerType.TryGetValue(itemType, out var maxAllowed))
        {
            return;
        }

        var currentCount = _spawnedItems.Count(i => i is T);
        for (var i = currentCount; i < maxAllowed; i++)
        {
            var item = new T();
            SpawnItem(item, _spawnedItems);
        }
    }

    public List<IEntity> GetSpawnedItems()
    {
        return _spawnedItems.OfType<IEntity>().ToList();
    }

    public void RemoveItem(IInteractable item)
    {
        if (_spawnedItems.Contains(item))
        {
            _spawnedItems.Remove(item);
        }
    }

    private void SpawnItem(IPositioned item, List<IPositioned> spawnedItems)
    {
        var y = _random.Next(gameWorld.HorizontalMin + 1, gameWorld.HorizontalMax);
        var x = _random.Next(gameWorld.VerticalMin + 1, gameWorld.VerticalMax);

        item.XPosition = x;
        item.YPosition = y;
        spawnedItems.Add(item);
    }
}