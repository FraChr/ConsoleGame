using PuzzleConsoleGame.Core;

namespace PuzzleConsoleGame.Rendering;

public class RenderPoint(int xPosition, int yPosition) : IPositioned
{
        public int XPosition { get; set; } = xPosition;
        public int YPosition { get; set; } = yPosition;
        
        public int PreviousX { get;  set; }
        public int PreviousY { get;  set; }
}