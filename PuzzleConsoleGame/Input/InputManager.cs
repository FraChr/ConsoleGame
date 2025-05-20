using PuzzleConsoleGame.Config;
using PuzzleConsoleGame.Entities.Weapon;

namespace PuzzleConsoleGame.Input;

public class InputManager
{
    private readonly Dictionary<ConsoleKey, (int dx, int dy)> _movementMap = new()
    {
        { ConsoleKey.W, (Movement.NoMove, Movement.MoveNegative) },
        { ConsoleKey.S, (Movement.NoMove, Movement.MovePositive) },
        { ConsoleKey.A, (Movement.MoveNegative, Movement.NoMove) },
        { ConsoleKey.D, (Movement.MovePositive, Movement.NoMove) },
    };

    private readonly Dictionary<ConsoleKey, Action> _actionMap;
    private readonly Actions _actions;

    public InputManager(Actions actions)
    {
        _actions = actions;
        // _actions = new Actions();
        _actionMap = new Dictionary<ConsoleKey, Action>
        {
            { ConsoleKey.Spacebar, _actions.Shoot }
        };
    }

    public (int dx, int dy)? GetMovement(ConsoleKey key)
    {
        return _movementMap.TryGetValue(key, out var delta) ? delta : null;
    }

    public Action? GetAction(ConsoleKey key)
    {
        return _actionMap.TryGetValue(key, out var action) ? action : null;
    }
}