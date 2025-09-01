using System.Text.RegularExpressions;
using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Entities;
using PuzzleConsoleGame.Models;
using PuzzleConsoleGame.Rendering;

namespace PuzzleConsoleGame;

public class RenderableMap : IRenderable
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public int PreviousX { get; }
    public int PreviousY { get; }
    public char Symbol { get; }
    public bool IsActive { get; set; } = true;
    public EntityType Type { get; }
    public int Value { get; }
    public RenderableMap(MapTile mapTile)
    {
        XPosition = mapTile.XPosition;
        YPosition = mapTile.YPosition;
        Symbol = Regex.Unescape(mapTile.Symbol)[0];
    }

 
}