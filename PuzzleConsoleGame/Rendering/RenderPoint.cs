using PuzzleConsoleGame.Core;

namespace PuzzleConsoleGame.Rendering;

public class RenderPoint(int xPosition, int yPosition) : IRenderable, IPositioned
{
        public int XPosition { get; set; } = xPosition;
        public int YPosition { get; set; } = yPosition;
        
        public int previousX { get;  set; }
        public int previousY { get;  set; }
        public char Symbol { get; set; }
}