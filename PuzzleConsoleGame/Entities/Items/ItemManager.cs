using System.Xml;
using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Items;

public class ItemManager
{
    private readonly Dictionary<int, Func<IInteractable>> _maxItemsPerType = new()
    {
        { 2, () => new Coin() },
        { 10, () => new HealthPack() }
    };

    private readonly List<IInteractable> _spawnedItems = [];
    private readonly Random _random = new();
    private readonly GameWorld _gameWorld;
    private readonly Render _render;

    public ItemManager(GameWorld gameWorld, Render render)
    {
        _gameWorld = gameWorld;
        _render = render;
    }

    public void RandomSpawnItems()
    {
        var entery = _maxItemsPerType.ElementAt(_random.Next(_maxItemsPerType.Count));
        
        
        var factory = entery.Value;
        var instance = factory();
        
        if (instance is IPositioned positioned)
        {
            SpawnItems(() => positioned, 7, 10);
        }
        



    }

    public void SpawnItems<T>(Func<T> factory, int x, int y) where T : IInteractable, IPositioned
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
    // public void SpawnItems<T>() where T : IInteractable, new()
    // {
    //     var itemType = typeof(T);
    //
    //     if (!_maxItemsPerType.TryGetValue(itemType, out var maxAllowed))
    //     {
    //         return;
    //     }
    //
    //     var currentCount = _spawnedItems.Count(i => i is T);
    //     for (var i = currentCount; i < maxAllowed; i++)
    //     {
    //         var item = new T();
    //         SpawnItem(item);
    //     }
    // }


    public void UpdateItems()
    {
        foreach (var item in _spawnedItems.ToList().Where(item => !item.IsActive))
        {
            RemoveItem(item);
        }
    }

    public List<IInteractable> GetSpawnedItems()
    {
        // return _spawnedItems.OfType<IInteractable>().ToList();
        return _spawnedItems;
    }

    public void RemoveItem(IInteractable item)
    {
        _spawnedItems.Remove(item);
    }

    private void SpawnItem(IInteractable item)
    {
        
        
        // if (item is IPositioned positioned)
        // {
        //     var y = _random.Next(_gameWorld.HorizontalMin + 1, _gameWorld.HorizontalMax);
        //     var x = _random.Next(_gameWorld.VerticalMin + 1, _gameWorld.VerticalMax);
        //
        //     positioned.XPosition = x;
        //     positioned.YPosition = y;
        // }
        //
        // item.IsActive = true;
        // _spawnedItems.Add(item);
    }
}