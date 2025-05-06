using static InputHandling.Prompter;

namespace Menu
{
    public class MainMenu
    {
        // - Method for displaying main menu screen -
        public static MainMenuOption ShowMainMenu()
        {
            string menuTitle = "Welcome to Console-RPG V2.0!";
            string[] options = new string[]
            {
                null,
                "Start New Game",
                "Load Game",
                "Manage Save",
                "About",
                "Roll a Dice"
            };

            int userChoice = ShowMenu(
                menuTitle: menuTitle,
                options: options,
                zeroOption: "Exit Game"
                );

            return (MainMenuOption)userChoice;
        }
    }

}
public enum MainMenuOption
{
    Exit,
    StartNewGame,
    LoadGame,
    ManageSave,
    About,
    RollADice
}

