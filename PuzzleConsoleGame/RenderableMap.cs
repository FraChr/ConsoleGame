using System.Text.RegularExpressions;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame;

public class RenderableMap : IRenderable
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public int PreviousX { get; }
    public int PreviousY { get; }
    public bool IsActive { get; set; } = true;
    public EntityType Type { get; set; }
    public int Value { get; }
    public char Symbol { get; }

    public RenderableMap(Map map)
    {
        XPosition = map.XPosition;
        YPosition = map.YPosition;
        Symbol = Regex.Unescape(map.Symbol)[0];
    }
}