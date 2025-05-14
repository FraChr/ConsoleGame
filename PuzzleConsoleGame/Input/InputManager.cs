namespace PuzzleConsoleGame;

using static GameConstants;

public class InputManager
{
    private readonly GameWorld _gameArea;

    public InputManager(GameWorld gameArea)
    {
        _gameArea = gameArea;
    }

    public Player PlayerControls(Player currentPlayerPosition)
    {
        var key = Console.ReadKey(true).Key;
        var newPosition = currentPlayerPosition;

        switch (key)
        {
            case ConsoleKey.W:
                newPosition = currentPlayerPosition.Move(deltaY: Movement.MoveNegative);
                break;
            case ConsoleKey.S:
                newPosition = currentPlayerPosition.Move(deltaY: Movement.MovePositive);
                break;
            case ConsoleKey.A:
                newPosition = currentPlayerPosition.Move(deltaX: Movement.MoveNegative);
                break;
            case ConsoleKey.D:
                newPosition = currentPlayerPosition.Move(deltaX: Movement.MovePositive);
                break;
            case ConsoleKey.Q:
                Console.Clear();
                Environment.Exit(0);
                break;
        }

        return _gameArea.IsInBounds(newPosition) ? newPosition : currentPlayerPosition;
    }
}