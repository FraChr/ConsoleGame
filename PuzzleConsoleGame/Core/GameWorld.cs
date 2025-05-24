using PuzzleConsoleGame.Config;

namespace PuzzleConsoleGame.Core;

public class GameWorld
{
    public readonly int VerticalMin = Boundaries.GameBoundsVerticalMin;
    public readonly int HorizontalMin = Boundaries.GameBoundsHorizontalMin;
    public int VerticalMax { get; set; }
    public int HorizontalMax { get; set; }

    public GameWorld(int horizontalMax, int verticalMax)
    {
        VerticalMax = verticalMax;
        HorizontalMax = horizontalMax;
    }
}