
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame.Entities.Items;

public class Item : IRenderable
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }

    public int PreviousX { get; set; }
    public int PreviousY { get; set; }
    public char Symbol { get; set; }
    public bool IsActive { get; set; }
    public int Value { get; set; }

    public virtual EntityType Type { get; }

    protected Item()
    {
    }


    public virtual void Interact()
    {
    }

    
}