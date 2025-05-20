using PuzzleConsoleGame.Core;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var game = new Initializer().Initialize();
game.Run();
// new GameLoop().Run();