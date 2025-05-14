namespace PuzzleConsoleGame;

using static GameConstants;

public class GameLoop
{
    private Player _player = new(PlayerStart.PlayerStartPosVert, PlayerStart.PlayerStartPosHoriz);

    private readonly GameWorld _gameArea = new(Boundaries.GameBoundsHorizontalMax, Boundaries.GameBoundsVerticalMax);
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
            _render.Draw(PlayerData.Character);
            var nextPlayer = _inputManager.PlayerControls(_player);

            if (nextPlayer == _player) continue;
            _render.Draw();
            _player = nextPlayer;
            _render.UpdatePlayer(_player);
        }
    }
}