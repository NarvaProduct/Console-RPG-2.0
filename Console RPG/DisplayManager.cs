public class DisplayManager
{
    // - Method for displaying a message -
    public static void ShowMsg(
        string msg,
        string secondaryMsg = "",
        bool showSecondary = false,
        bool waitForKey = true
        )
    {
        ClearConsole();
        Console.WriteLine(msg);
        if (showSecondary) Console.WriteLine(secondaryMsg);
        if (waitForKey) Console.ReadKey();
    }
    // - Method for requesting user input -
    public static string AskUser(
        string request,
        string errorMsg = "",
        bool showError = false,
        bool keyEntry = false
        )
    {
        string userInput = "";

        ClearConsole();
        Console.WriteLine(request);
        if (showError) Console.WriteLine(errorMsg);
        if(!keyEntry) userInput = Console.ReadLine();
        if (keyEntry) userInput = ReadKey();

        return userInput;
    }
    // - Method for displaying a decision menu -
    // Takes in title of menu and an array of possible options
    // Returns the int of the user's choice
    // Option for 0 will default to a go back option
    public static int ShowMenu(
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
            errorMsg: "Invalid choice, please select one of the options",
            keyEntry: true
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
    public static string ReadKey()
    {
        ConsoleKeyInfo key;
        key = Console.ReadKey(intercept: true);
        string stringKey = key.KeyChar.ToString();

        return stringKey;
    }
}