using Menu;
public class GameManager
{
    public void Run()
    {
        while (true)
        {
            var choice = MainMenu.ShowMainMenu();

        }
    }
    private void HandleMainMenu(MainMenuOption choice)
    {
        switch (choice)
        {
            case MainMenuOption.Exit:
                ExitGame();
                break;
            case MainMenuOption.StartNewGame:
                StartNewGame();
                break;
            case MainMenuOption.LoadGame:
                LoadGame();
                break;
            case MainMenuOption.ManageSave:
                ManageSave();
                break;
            case MainMenuOption.About:
                ShowAbout();
                break;
            case MainMenuOption.RollADice:
                Dice.RollDCustom(20);
                break;
            default:
                UserInterface.ShowMsg("Unknown Selection");
                break;
        }
    }
    public static void ExitGame()
    {
        UserInterface.ShowMsg("Exitting Game");
        Environment.Exit(0);
    }
}