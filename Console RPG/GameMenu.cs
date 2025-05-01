namespace Menu
{
    public class GameMenu
    {
        // - Method for displaying a decision menu -
        // Takes in title of menu and an array of possible options
        // Returns the int of the user's choice
        // Option for 0 will default to a go back option
        public static int DecisionMenu(
            string menuTitle,
            string[] options,
            string zeroOption = "go back"
            )
        {
            int userChoice;
            string titleDivider = "";
            int numOptions = options.Length;
            int titleLength = menuTitle.Length;

            for (int i = 0; i < titleLength; i++) // Decides the length of the divider under title based on how long title is
            {
                titleDivider = titleDivider + "-";
            }
            menuTitle = menuTitle + "\n" + titleDivider; // Adds divider to the line under the title
            string optionListString = menuTitle;

            for (int i = 1; i < numOptions; i++) // Skips index zero because 0 will always be null (go back option)
            {
                optionListString = optionListString + "\n" + i + ". " + options[i];
            }
            optionListString = optionListString + "\n0. " + zeroOption; // Displays 0 option at the bottom of the list

            userChoice = Tools.ReadInt(
                min: 0,
                max: numOptions,
                prompt: optionListString,
                errorMsg: "Invalid choice, please select one of the options"
                );

            return userChoice;
        }
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

            int userChoice = DecisionMenu(
                menuTitle: menuTitle,
                options: options,
                zeroOption: "Exit Game"
                );

            return userChoice;
        }
    }
}
