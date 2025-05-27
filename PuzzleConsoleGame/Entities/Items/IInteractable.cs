
using PuzzleConsoleGame.Core;

namespace PuzzleConsoleGame.Entities.Items;

public interface IInteractable
{
    bool IsActive { get; set; }
    EntityType Type { get; }
    int Value { get; }
}