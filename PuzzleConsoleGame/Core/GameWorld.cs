using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities;

namespace PuzzleConsoleGame.Core;

using static GameConstants;

public class GameWorld(int verticalMax, int horizontalMax)
{
    public const int VerticalMin = Boundaries.GameBoundsVerticalMin;
    public const int HorizontalMin = Boundaries.GameBoundsHorizontalMin;
    public int VerticalMax { get; set; } = verticalMax;
    public int HorizontalMax { get; set; } = horizontalMax;

    public bool IsInBounds(Player position)
    {
        return position.XPosition > VerticalMin && position.XPosition < VerticalMax && position.YPosition > HorizontalMin && position.YPosition < HorizontalMax;
    }
}