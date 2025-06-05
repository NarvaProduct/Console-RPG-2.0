
using ConsoleRPG.Entities;
using ConsoleRPG.InputHandling;
using ConsoleRPG.Utils;

namespace ConsoleRPG.Menus;

public class MainMenu
{
    internal enum MainMenuControls
    {
        StartGame,
        LoadGame,
        ManageSaves,
        About
    }

    private Menu<MainMenuControls>? Menu { get; set; }

    public MainMenu()
    {
        Menu = new Menu<MainMenuControls>(
            title: GameSettings.GameTitle,
            options: Enum.GetValues<MainMenuControls>(),
            zeroOption: "Exit Game",
            infoTextA: $"Version: {GameSettings.Version}");
    }

    public void Show()
    {
        MainMenuControls? userChoice = Menu?.ShowMenu();
        HandleMainMenu(userChoice);
    }

    private void HandleMainMenu(MainMenuControls? userChoice)
    {
        switch (userChoice)
        {
            case MainMenuControls.StartGame:
                // Game.StartGame();
                PrintAction("StartGame");
                break;
            case MainMenuControls.LoadGame:
                // Game.LoadGame();
                PrintAction("LoadGame");
                break;
            case MainMenuControls.ManageSaves:
                // Game.ManageSaves();
                PrintAction("ManageSaves");
                break;
            case MainMenuControls.About:
                // Game.About();
                PrintAction("About");
                break;
            case null:
                // Game.ExitGame();
                PrintAction("ExitGame");
                break;
        }
    }
    private void PrintAction(string action)
    {
        UserInterface.ShowMsg($"Calling Game.{action}");
    }
}
