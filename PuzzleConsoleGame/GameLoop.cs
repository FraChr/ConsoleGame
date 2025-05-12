namespace PuzzleConsoleGame;

public class GameLoop
{
    private Position _player = new(GameConstants.PlayerStartPosX, GameConstants.PlayerStartPosY);

    private readonly GameBounds _gameArea = new(GameConstants.GameBoundsX, GameConstants.GameBoundsY);
    private bool _running = true;

    public void Run()
    {
        Loop();
    }

    private void Loop()
    {
        while (_running)
        {
            Draw();
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
                Console.Clear();
                Environment.Exit(0);
                break;
        }

        if (_gameArea.IsInBounds(next))
        {
            _player = next;
        }
    }
    

    private void Draw()
    {
        
        Console.CursorVisible = false;
        Console.Clear();
        _gameArea.DrawBounds();
        Console.SetCursorPosition(_player.X, _player.Y);
        Console.Write("*");
    }
}