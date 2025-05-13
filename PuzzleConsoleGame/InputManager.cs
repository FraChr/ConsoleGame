namespace PuzzleConsoleGame;

using static GameConstants;

public class InputManager
{
    private readonly GameBounds _gameArea;

    public InputManager(GameBounds gameArea)
    {
        _gameArea = gameArea;
    }

    public PlayerPos PlayerControls(PlayerPos currentPlayerPosition)
    {
        var key = Console.ReadKey(true).Key;
        var newPosition = currentPlayerPosition;

        switch (key)
        {
            case ConsoleKey.W:
                newPosition = currentPlayerPosition.Move(dY: Movement.MoveNegative);
                break;
            case ConsoleKey.S:
                newPosition = currentPlayerPosition.Move(dY: Movement.MovePositive);
                break;
            case ConsoleKey.A:
                newPosition = currentPlayerPosition.Move(dX: Movement.MoveNegative);
                break;
            case ConsoleKey.D:
                newPosition = currentPlayerPosition.Move(dX: Movement.MovePositive);
                break;
            case ConsoleKey.Q:
                Console.Clear();
                Environment.Exit(0);
                break;
        }

        return _gameArea.IsInBounds(newPosition) ? newPosition : currentPlayerPosition;
    }
}