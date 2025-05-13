namespace PuzzleConsoleGame;

public static class GameConstants
{
    public static class Player {
        public const char Character = '^';
    }

    public static class Movement
    {
        public const int MoveNegative = -1;
        public const int MovePositive = 1;
        public const int NoMove = 0;
    }

    public static class Boundaries
    {
        public const int GameBoundsHoriz = 20;
        public const int GameBoundsVert = 12;
    }

    public static class PlayerStart
    {
        public const int PlayerStartPosHoriz = 5;
        public const int PlayerStartPosVert = 5;
    }

    public static class Border
    {
        public const int VerticalBorder = 0x2502;
        public const int HorizontalBorder = 0x2500;
        public const int LeftUpperCorner = 0x250C;
        public const int RightUpperCorner = 0x2510;
        public const int LeftLowerCorner = 0x2514;
        public const int RightLowerCorner = 0x2518;
    }
}