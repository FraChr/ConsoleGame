namespace PuzzleConsoleGame;

public class Render(Player player)
{
    private Player _player = player;

    public void UpdatePlayer(Player player)
    {
        _player = player;
    }

    public void Draw(char character = ' ')
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(_player.XPosition, _player.YPosition);
        Console.Write(character);
    }

    public void DrawBounds(GameWorld boundaries)
    {
        DrawVerticalBorder(boundaries);
        DrawHorizontalBorder(boundaries);
        DrawCorners(boundaries);
    }

    private static void DrawVerticalBorder(GameWorld boundaries)
    {
        const int yMinBound = GameWorld.HorizontalMin + 1;
        for (var y = yMinBound; y < boundaries.HorizontalMax; y++)
        {
            Console.SetCursorPosition(GameWorld.VerticalMin, y);
            Console.Write(char.ConvertFromUtf32(GameConstants.Border.VerticalBorder));
            Console.SetCursorPosition(boundaries.VerticalMax, y);
            Console.Write(char.ConvertFromUtf32(GameConstants.Border.VerticalBorder));
        }
    }

    private static void DrawHorizontalBorder(GameWorld boundaries)
    {
        const int xMinBound = GameWorld.VerticalMin + 1;
        for (var x = xMinBound; x < boundaries.VerticalMax; x++)
        {
            Console.SetCursorPosition(x, GameWorld.HorizontalMin);
            Console.Write(char.ConvertFromUtf32(GameConstants.Border.HorizontalBorder));
            Console.SetCursorPosition(x, boundaries.HorizontalMax);
            Console.Write(char.ConvertFromUtf32(GameConstants.Border.HorizontalBorder));
        }
    }

    private static void DrawCorners(GameWorld boundaries)
    {
        Console.SetCursorPosition(GameWorld.VerticalMin, GameWorld.HorizontalMin);
        Console.Write(char.ConvertFromUtf32(GameConstants.Border.LeftUpperCorner));

        Console.SetCursorPosition(boundaries.VerticalMax, GameWorld.HorizontalMin);
        Console.Write(char.ConvertFromUtf32(GameConstants.Border.RightUpperCorner));

        Console.SetCursorPosition(GameWorld.VerticalMin, boundaries.HorizontalMax);
        Console.Write(char.ConvertFromUtf32(GameConstants.Border.LeftLowerCorner));

        Console.SetCursorPosition(boundaries.VerticalMax, boundaries.HorizontalMax);
        Console.Write(char.ConvertFromUtf32(GameConstants.Border.RightLowerCorner));
    }
}