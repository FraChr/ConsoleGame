namespace PuzzleConsoleGame;

public class GameLoop
{
    private Position _player = new(GameConstants.PlayerStartPosX, GameConstants.PlayerStartPosY);

    private readonly GameBounds _gameArea = new(GameConstants.GameBoundsX, GameConstants.GameBoundsY);
    private bool _running = true;

    public void Run()
    {
        Draw();
        Loop();
    }

    private void Loop()
    {
        while (_running)
        {
            Input();
            Draw();
        }
    }

    private void Input()
    {
        var key = Console.ReadKey(true).Key;
        var next = _player;

        switch (key)
        {
            case ConsoleKey.W:
                next.Move(GameConstants.NoMove, GameConstants.MoveNegative);
                break;
            case ConsoleKey.S:
                next.Move(GameConstants.NoMove, GameConstants.MovePositive);
                break;
            case ConsoleKey.A:
                next.Move(GameConstants.MoveNegative, GameConstants.NoMove);
                break;
            case ConsoleKey.D:
                next.Move(GameConstants.MovePositive, GameConstants.NoMove);
                break;
            case ConsoleKey.Q:
                _running = false;
                Clean();
                Environment.Exit(0);
                break;
        }

        if (_gameArea.IsInBounds(next))
        {
            _player = next;
        }
    }

    private static void Clean()
    {
        Console.Clear();
    }

    private void Draw()
    {
        Console.CursorVisible = false;
        Console.Clear();
        Console.SetCursorPosition(_player.X, _player.Y);
        Console.Write("*");
    }
}