using PuzzleConsoleGame.Core;

namespace PuzzleConsoleGame.Rendering;

public interface IRenderable : IPositioned
{ 
    char Symbol { get; set; }
}