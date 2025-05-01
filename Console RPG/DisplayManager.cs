public class DisplayManager
{
    // - Method for displaying a message that requires user acknowledgement -
    public static void DisplayPrompt(
        string msg,
        string secondaryMsg = "",
        bool showSecondary = false
        )
    {
        if (showSecondary) // Shows msg and secondaryMsg
        {
            ClearConsole();
            Console.WriteLine(msg);
            Console.WriteLine(secondaryMsg);
            Console.ReadKey();
            ClearConsole();
        }
        else // Shows only msg
        {
            ClearConsole();
            Console.WriteLine(msg);
            Console.ReadKey();
            ClearConsole();
        }
    }
        // - Method for displaying a message without acknowledgement -
    public static void DisplayText(
        string msg,
        string secondaryMsg = "",
        bool showSecondary = false
        )
    {
        if (showSecondary) // Shows msg and secondaryMsg
        {
            ClearConsole();
            Console.WriteLine(msg);
            Console.WriteLine(secondaryMsg);
        }
        else // Shows only msg
        {
            ClearConsole();
            Console.WriteLine(msg);
        }
    }
    // - Method for requesting user input -
    public static string DisplayRequest(
        string request,
        string errorMsg = "",
        bool showError = false
        )
    {
        string userInput = "";

        if (showError)
        {
            ClearConsole();
            Console.WriteLine(request);
            Console.WriteLine(errorMsg);
            userInput = Console.ReadLine();
            ClearConsole();
        }
        else // Shows only msg
        {
            ClearConsole();
            Console.WriteLine(request);
            userInput = Console.ReadLine();
            ClearConsole();
        }

        return userInput;
    }
        // - Method for displaying a decision menu -
        // Takes in title of menu and an array of possible options
        // Returns the int of the user's choice
        // Option for 0 will default to a go back option
        public static int DisplayMenu(
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
    // - Method for skipping Console.Clear() in debug mode -
    public static void ClearConsole()
    {
        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }
    }
}