namespace PuzzleConsoleGame.Entities;

public interface IInteractable
{
    int XPosition { get; set; }
    int YPosition { get; set; }
    bool IsCollected { get; set; }

    void Interact();
}