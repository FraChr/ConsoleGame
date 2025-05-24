using PuzzleConsoleGame.Interfaces;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Items;

public class HealthPack : IInteractable , IPointsItem, IRenderable
{
    public bool IsActive { get; set; }
    public void Interact(IInteractable other)
    {
    }

    public int Value { get; set; }
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public int PreviousX { get; set; }
    public int PreviousY { get; set; }
    public char Symbol { get; } = '=';
}