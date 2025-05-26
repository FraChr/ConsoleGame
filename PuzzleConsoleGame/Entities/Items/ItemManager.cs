using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Items;

public class ItemManager
{
    private readonly Dictionary<int, Func<IInteractable>> _lootGenerationMap = new()
    {
        { 1, () => new Coin() },
        { 2, () => new HealthPack() }
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

    public void SpawnRandomItem(int positionX = 0, int positionY = 0)
    {
        var entery = _lootGenerationMap.ElementAt(_random.Next(_lootGenerationMap.Count));
        
        var factory = entery.Value;
        var instance = factory();

        if (instance is IPositioned interactable)
        {
            interactable.XPosition = positionX;
            interactable.YPosition = positionY;
        }
        
        instance.IsActive = true;
        
        _spawnedItems.Add(instance);
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