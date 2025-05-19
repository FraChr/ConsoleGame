using PuzzleConsoleGame.Config;

namespace PuzzleConsoleGame.Input;

public class InputManager
{
    private static readonly Dictionary<ConsoleKey, (int dx, int dy)> MovementMap = new()
    {
        { ConsoleKey.W, (Movement.NoMove, Movement.MoveNegative) },
        { ConsoleKey.S, (Movement.NoMove, Movement.MovePositive) },
        { ConsoleKey.A, (Movement.MoveNegative, Movement.NoMove) },
        { ConsoleKey.D, (Movement.MovePositive, Movement.NoMove) },
    };

    public (int dx, int dy)? GetMovement(ConsoleKey key)
    {
        return MovementMap.TryGetValue(key, out var delta) ? delta : null;
    }
}