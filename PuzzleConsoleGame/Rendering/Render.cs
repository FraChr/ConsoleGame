using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Core;

namespace PuzzleConsoleGame.Rendering;

public class Render
{
    public void Draw(IRenderable obj, char? overrideChar = null)
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(obj.XPosition, obj.YPosition);
        Console.Write(overrideChar ?? obj.Symbol);
    }

    public void DrawBoundaries(GameWorld boundaries)
    {
        DrawVerticalBorder(boundaries);
        DrawHorizontalBorder(boundaries);
        DrawCorners(boundaries);
    }

    public void DrawScore(int score)
    {
        Console.SetCursorPosition(Ui.HorizontalPosition, Ui.VerticalPosition);
        Console.Write($"score {score}");
    }

private static void DrawVerticalBorder(GameWorld boundaries)
    {
        const int yMinBound = GameWorld.HorizontalMin + 1;
        for (var y = yMinBound; y < boundaries.HorizontalMax; y++)
        {
            Console.SetCursorPosition( GameWorld.VerticalMin, y);
            Console.Write(Border.VerticalBorder);
            Console.SetCursorPosition(boundaries.VerticalMax, y);
            Console.Write(Border.VerticalBorder);
        }
    }

    private static void DrawHorizontalBorder(GameWorld boundaries)
    {
        const int xMinBound = GameWorld.VerticalMin + 1;
        for (var x = xMinBound; x < boundaries.VerticalMax; x++)
        {
            Console.SetCursorPosition(x,GameWorld.HorizontalMin);
            Console.Write(Border.HorizontalBorder);
            Console.SetCursorPosition(x, boundaries.HorizontalMax);
            Console.Write(Border.HorizontalBorder);
        }
    }

    private static void DrawCorners(GameWorld boundaries)
    {
        Console.SetCursorPosition(GameWorld.VerticalMin, GameWorld.HorizontalMin);
        Console.Write(char.ConvertFromUtf32(Border.LeftUpperCorner));

        Console.SetCursorPosition(boundaries.VerticalMax, GameWorld.HorizontalMin);
        Console.Write(Border.RightUpperCorner);

        Console.SetCursorPosition(GameWorld.VerticalMin, boundaries.HorizontalMax);
        Console.Write(Border.LeftLowerCorner);

        Console.SetCursorPosition(boundaries.VerticalMax, boundaries.HorizontalMax);
        Console.Write(Border.RightLowerCorner);
    }
}