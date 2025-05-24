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

    public void RandomSpawnItems(int positionX = 0, int positionY = 0)
    {
        var entry = _maxItemsPerType.ElementAt(_random.Next(_maxItemsPerType.Count));

        var factory = entry.Value;
        var instance = factory();

        if (instance is IPositioned interactable)
        {
            interactable.XPosition = positionX;
            interactable.YPosition = positionY;
        }

        instance.IsActive = true;

        _spawnedItems.Add(instance);
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