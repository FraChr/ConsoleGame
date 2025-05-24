using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Core;
using PuzzleConsoleGame.Entities.Items;
using PuzzleConsoleGame.Entities.Player;

namespace PuzzleConsoleGame.Rendering;

public class Render
{
    public void Draw(IRenderable obj, char? overrideChar = null)
    {
        Console.SetCursorPosition(obj.previousX, obj.previousY);
        Console.Write(' ');
        
        Console.CursorVisible = false;
        Console.SetCursorPosition(obj.XPosition, obj.YPosition);
        Console.Write(overrideChar ?? obj.Symbol);
    }

    public void DrawScore(Player player)
    {
        var maxLenght = 40;
        Console.SetCursorPosition(Ui.HorizontalPosition, Ui.VerticalPosition);
        Console.Write(new String(' ', maxLenght));

        Console.SetCursorPosition(Ui.HorizontalPosition, Ui.VerticalPosition);
        Console.Write($"score {player.Score} | Health: {player.Health}");
    }

    public void PrintAllGameObjects(List<IInteractable> allEntities)
    {
        int startX = 60;
        int startY = 1;

        Console.SetCursorPosition(startX, startY);
        Console.WriteLine("Entities this frame: ");

        int line = startY + 1;
        foreach (var entity in allEntities)
        {
            if(entity is IPositioned positioned)
            {
                Console.SetCursorPosition(startX, line++);
                Console.WriteLine(
                    $"{entity.GetType().Name} @ ({positioned.XPosition}, {positioned.YPosition}), Active: {entity.IsActive}");
            }
        }
    }

    public void DrawBoundaries(GameWorld gameWorld)
    {
        DrawVerticalBorder(gameWorld);
        DrawHorizontalBorder(gameWorld);
        DrawCorners(gameWorld);
    }


    private static void DrawVerticalBorder(GameWorld gameWorld)
    {
        int yMinBound = gameWorld.HorizontalMin + 1;
        for (var y = yMinBound; y < gameWorld.HorizontalMax; y++)
        {
            Console.SetCursorPosition(gameWorld.VerticalMin, y);
            Console.Write(Border.VerticalBorder);
            Console.SetCursorPosition(gameWorld.VerticalMax, y);
            Console.Write(Border.VerticalBorder);
        }
    }

    private static void DrawHorizontalBorder(GameWorld gameWorld)
    {
        int xMinBound = gameWorld.VerticalMin + 1;
        for (var x = xMinBound; x < gameWorld.VerticalMax; x++)
        {
            Console.SetCursorPosition(x, gameWorld.HorizontalMin);
            Console.Write(Border.HorizontalBorder);
            Console.SetCursorPosition(x, gameWorld.HorizontalMax);
            Console.Write(Border.HorizontalBorder);
        }
    }

    private static void DrawCorners(GameWorld gameWorld)
    {
        Console.SetCursorPosition(gameWorld.VerticalMin, gameWorld.HorizontalMin);
        Console.Write(char.ConvertFromUtf32(Border.LeftUpperCorner));

        Console.SetCursorPosition(gameWorld.VerticalMax, gameWorld.HorizontalMin);
        Console.Write(Border.RightUpperCorner);

        Console.SetCursorPosition(gameWorld.VerticalMin, gameWorld.HorizontalMax);
        Console.Write(Border.LeftLowerCorner);

        Console.SetCursorPosition(gameWorld.VerticalMax, gameWorld.HorizontalMax);
        Console.Write(Border.RightLowerCorner);
    }
}