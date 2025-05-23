using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Entities.Player;
using PuzzleConsoleGame.Interfaces;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Core.CoreLoop;

public class LogicProcessor
{
    private readonly ItemManager _itemManager;
    private readonly CollisionManager _collisionManager;
    private readonly Player _player;
    private readonly Render _render;

    public LogicProcessor(ItemManager itemManager, Player player, CollisionManager collisionManager, Render render)
    {
        _itemManager = itemManager;
        _player = player;
        _collisionManager = collisionManager;
        _render = render;
    }

    public void Update()
    {
        var allEntities = new List<IEntity>();
        allEntities.AddRange(_itemManager.GetSpawnedItems());
    
        foreach (var interactable in allEntities)
        {
            _collisionManager.CheckInteraction(_player, interactable);
    
            switch (interactable)
            {
                case IPointsItem pointsItem when interactable.IsActive:
                    // _score += pointsItem.Value;
                    _itemManager.RemoveItem(interactable);
                    break;
            }
        }
        
        // for debugging ----------------------------
        _render.PrintAllGameObjects(allEntities);
        // ------------------------------------------
        
        allEntities.Clear();
    }
}