using InputHandling.Prompter;
public class GameMenu
{
    // - Method for displaying main menu screen -
    public static int MainGameMenu()
    {
        string menuTitle = "=== Welcome to Console-RPG V2.0! ===";
        string[] options = new string[]
        {
            null,
            "Start New Game",
            "Load Game",
            "Manage Save",
            "About",
            "Roll a Dice"
        };

        int userChoice = InputHandler(
            menuTitle: menuTitle,
            options: options,
            zeroOption: "Exit Game"
            );

        return userChoice;
    }
}

