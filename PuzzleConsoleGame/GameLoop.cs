namespace PuzzleConsoleGame;

using static GameConstants;

public class GameLoop
{
    private PlayerPos _player = new(PlayerStart.PlayerStartPosHoriz, PlayerStart.PlayerStartPosVert);

    private readonly GameBounds _gameArea = new(Boundaries.GameBoundsHoriz, Boundaries.GameBoundsVert);
    private readonly InputManager _inputManager;
    private readonly Render _render;
    private const bool Running = true;

    public GameLoop()
    {
        _inputManager = new InputManager(_gameArea);
        _render = new Render(_player);
    }

    public void Run()
    {
        _render.DrawBounds(_gameArea);
        while (Running)
        {
            _render.Draw(Player.Character);
            var nextPlayer = _inputManager.PlayerControls(_player);

            if (nextPlayer == _player) continue;
            _render.Draw();
            _player = nextPlayer;
            _render.UpdatePlayer(_player);
        }
    }
}