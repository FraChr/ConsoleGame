namespace PuzzleConsoleGame.Rendering;

public class RenderPoint(int xPosition, int yPosition) : IRenderable
{
        public int XPosition { get; set; } = xPosition;
        public int YPosition { get; set; } = yPosition;
        public char Symbol { get; set; }
}