namespace PuzzleConsoleGame;

public class Render(PlayerPos player)
{
    private PlayerPos _player = player;

    public void UpdatePlayer(PlayerPos player)
    {
        _player = player;
    }

    public void Draw(char character = ' ')
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(_player.XPos, _player.YPos);
        Console.Write(character);
    }

    public void DrawBounds(GameBounds boundaries)
    {
        DrawVerticalBorder(boundaries);
        DrawHorizontalBorder(boundaries);
        DrawCorners(boundaries);
    }

    private static void DrawVerticalBorder(GameBounds boundaries)
    {
        const int yMinBound = GameBounds.YMin + 1;
        for (var y = yMinBound; y < boundaries.YMax; y++)
        {
            Console.SetCursorPosition(GameBounds.XMin, y);
            Console.Write(char.ConvertFromUtf32(GameConstants.Border.VerticalBorder));
            Console.SetCursorPosition(boundaries.XMax, y);
            Console.Write(char.ConvertFromUtf32(GameConstants.Border.VerticalBorder));
        }
    }

    private static void DrawHorizontalBorder(GameBounds boundaries)
    {
        const int xMinBound = GameBounds.XMin + 1;
        for (var x = xMinBound; x < boundaries.XMax; x++)
        {
            Console.SetCursorPosition(x, GameBounds.YMin);
            Console.Write(char.ConvertFromUtf32(GameConstants.Border.HorizontalBorder));
            Console.SetCursorPosition(x, boundaries.YMax);
            Console.Write(char.ConvertFromUtf32(GameConstants.Border.HorizontalBorder));
        }
    }

    private static void DrawCorners(GameBounds boundaries)
    {
        Console.SetCursorPosition(GameBounds.XMin, GameBounds.YMin);
        Console.Write(char.ConvertFromUtf32(GameConstants.Border.LeftUpperCorner));

        Console.SetCursorPosition(boundaries.XMax, GameBounds.YMin);
        Console.Write(char.ConvertFromUtf32(GameConstants.Border.RightUpperCorner));

        Console.SetCursorPosition(GameBounds.XMin, boundaries.YMax);
        Console.Write(char.ConvertFromUtf32(GameConstants.Border.LeftLowerCorner));

        Console.SetCursorPosition(boundaries.XMax, boundaries.YMax);
        Console.Write(char.ConvertFromUtf32(GameConstants.Border.RightLowerCorner));
    }
}