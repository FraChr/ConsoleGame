using PuzzleConsoleGame.Config;

namespace PuzzleConsoleGame.Core;

public class GameWorld( int horizontalMax, int verticalMax)
{
    public const int VerticalMin = Boundaries.GameBoundsVerticalMin;
    public const int HorizontalMin = Boundaries.GameBoundsHorizontalMin;
    public int VerticalMax { get; set; } = verticalMax;
    public int HorizontalMax { get; set; } = horizontalMax;
    
    public bool IsInBounds(IPositioned entity)
    {
        return entity.XPosition > VerticalMin &&
               entity.XPosition < VerticalMax &&
               entity.YPosition > HorizontalMin &&
               entity.YPosition < HorizontalMax;
    }
}