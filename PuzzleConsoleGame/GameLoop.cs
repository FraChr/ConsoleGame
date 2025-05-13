namespace PuzzleConsoleGame;

using static GameConstants;

public class GameLoop
{
    private PlayerPos _player = new(PlayerStart.PlayerStartPosHoriz, PlayerStart.PlayerStartPosVert);

    private readonly GameBounds _gameArea = new(Boundaries.GameBoundsHoriz, Boundaries.GameBoundsVert);
    private bool _running = true;

    public void Run()
    {
        Loop();
    }

    private void Loop()
    {
        _gameArea.DrawBounds();
        while (_running)
        {
            Draw(Character);
            Input();
        }
    }

    private void Input()
    {
        var key = Console.ReadKey(true).Key;
        var next = _player;

        switch (key)
        {
            case ConsoleKey.W:
                next.Move(Movement.NoMove, Movement.MoveNegative);
                break;
            case ConsoleKey.S:
                next.Move(Movement.NoMove, Movement.MovePositive);
                break;
            case ConsoleKey.A:
                next.Move(Movement.MoveNegative, Movement.NoMove);
                break;
            case ConsoleKey.D:
                next.Move(Movement.MovePositive, Movement.NoMove);
                break;
            case ConsoleKey.Q:
                _running = false;
                Console.Clear();
                Environment.Exit(0);
                break;
        }

        if (_gameArea.IsInBounds(next))
        {
            Draw();
            _player = next;
        }
    }


    private void Draw(char character = ' ')
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(_player.XPos, _player.YPos);
        Console.Write(character);
    }
}