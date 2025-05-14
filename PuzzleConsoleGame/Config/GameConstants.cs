namespace PuzzleConsoleGame.Config;

public static class GameConstants
{
    public static class PlayerData {
        public const char Character = '^';
    }

    public static class ItemData
    {
        public const char Character = '=';
    }

    public static class Movement
    {
        public const int MoveNegative = -1;
        public const int MovePositive = 1;
        public const int NoMove = 0;
    }

    public static class Boundaries
    {
        public const int GameBoundsHorizontalMax = 20;
        public const int GameBoundsVerticalMax = 12;
        public const int GameBoundsHorizontalMin = 0;
        public const int GameBoundsVerticalMin = 0;
    }

    public static class PlayerStart
    {
        public const int PlayerStartPosHoriz = 10;
        public const int PlayerStartPosVert = 6;
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