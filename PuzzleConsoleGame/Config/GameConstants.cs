﻿
namespace PuzzleConsoleGame.Config;

public static class GameSymbols
{
    public const char Remove = ' ';
}

public static class EnemyData
{
    public const char EnemyCharacter = '\u2620';
    public const int StartPositionHorizontal = 3;
    public const int StartPositionVertical = 4;
    public const int Health = 100;
    public const int Damage = 1;
    public const int EnemySpawnIntervalsMs = 6000;
    public static char Remove => GameSymbols.Remove;
}

public static class PlayerData
{
    public const char CharacterDefault = '\u25B2';
    public const char CharacterDown = '\u25BC';
    public const char CharacterLeft = '\u25C0';
    public const char CharacterRight = '\u25B6';
    public const int Health = 100;

    public static char Remove => GameSymbols.Remove;
}

public static class WeaponData
{
    public const char Bullet = '\u2022';
    public const int Damage = 50;
    public static char Remove => GameSymbols.Remove;
}

public static class ItemData
{
    public const char Coin = '\u25CF';
    public const int CoinValue = 1;
    
    public const char Health = '\u2665';
    public const int HealthValue = 10;
    
    public const char Upgrade = '\u2660';
    public const int UpgradeValue = 10;
    public const int UpdgradeCost = 20;
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
    public const int GameBoundsHorizontalMin = 1;
    public const int GameBoundsVerticalMin = 0;
}

public static class PlayerStart
{
    public const int PlayerStartPosHoriz = 10;
    public const int PlayerStartPosVert = 6;
}

public static class Border
{
    public const char VerticalBorder = '\u2502';
    public const char HorizontalBorder = '\u2500';
    public const char LeftUpperCorner = '\u250C';
    public const char RightUpperCorner = '\u2510';
    public const char LeftLowerCorner = '\u2514';
    public const char RightLowerCorner = '\u2518';
}

public static class Ui
{
    public const int HorizontalPosition = 2;
    public const int VerticalPosition = 0;
}

