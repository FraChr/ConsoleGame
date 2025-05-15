namespace PuzzleConsoleGame.Config;

public static class GameSymbols
{
    public const char Remove = ' ';
}

public static class PlayerData
{
    public const char CharacterDefault = '^';
    public const char CharacterLeft = '<';
    public const char CharacterRight = '>';
    public const char CharacterDown = 'v';
    public static char Remove => GameSymbols.Remove;
}

public static class ItemData
{
    public const char Coin = '●';
    public static char Remove => GameSymbols.Remove;
}

public static class Movement
{
    public const int MoveNegative = -1;
    public const int MovePositive = 1;
    public const int NoMove = 0;
}

public static class Boundaries
{
    public const int GameBoundsHorizontalMax = 50;
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