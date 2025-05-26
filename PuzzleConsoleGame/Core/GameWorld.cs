using PuzzleConsoleGame.Config;

namespace PuzzleConsoleGame.Core;

public class GameWorld
{
    public readonly int VerticalMin = Boundaries.GameBoundsVerticalMin;
    public readonly int HorizontalMin = Boundaries.GameBoundsHorizontalMin;
    public int VerticalMax { get; }
    public int HorizontalMax { get; }

    public GameWorld(int horizontalMax, int verticalMax)
    {
        VerticalMax = verticalMax;
        HorizontalMax = horizontalMax;
    }
}