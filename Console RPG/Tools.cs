
public class Tools
{
    // - Method for displaying a decision menu -
    // Takes in title of menu and an array of possible options
    // Option 0 will always be the go back option
    public static int DecisionMenu(string menuTitle, string[] options)
    {
        int userChoice;
        int numOptions = options.Length;
        menuTitle = menuTitle + "\n----------------------\n" + "0. Go back";
        string optionListString = menuTitle;

        for (int i = 1; i < numOptions; i++) // Skips index zero because 0 will always be null (go back option)
        {
            optionListString = optionListString + "\n" + i + ". " + options[i];
        }

        userChoice = ReadInt(
            min: 0,
            max: numOptions,
            prompt: optionListString,
            errorMsg: "Invalid choice, please select one of the options");

        return userChoice;
    }
    // - Method for reading strings -
    // showError will be true only if checkInt returns an error
    // To do: 
    // + Decide how to handle ClearConsole() when transitioning to a GUI
    public static string ReadString(
        string prompt = "Please enter a string",
        string errorMsg = "Invalid entry",
        bool showError = false)
    {
        string inputString;

        ClearConsole();
        OutputHandler(prompt);
        if (showError) OutputHandler(errorMsg);
        inputString = InputHandler();
        while (inputString == null || inputString == "")
        {
            ClearConsole();
            OutputHandler(prompt);
            OutputHandler(errorMsg);
            inputString = InputHandler();
        }
        ClearConsole();

        return inputString;
    }
    // - Method for reading integers -
    // There are default messages for the prompt and the error message
    public static int ReadInt(
        int min,
        int max,
        string prompt = "Please enter an integer",
        string errorMsg = "Invalid entry")
    {
        string inputString;
        int inputInt;

        inputString = ReadString(prompt, errorMsg, false);
        if (!int.TryParse(inputString, out inputInt) || inputInt < min || inputInt > max)
        {
            do
            {
                inputString = ReadString(prompt, errorMsg, true);
            } while (!int.TryParse(inputString, out inputInt) || inputInt < min || inputInt > max);
        }
        return inputInt;
    }
    // - Method for allowing Console.Clear() in debug mode -
    public static void ClearConsole()
    {
        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }
    }
    // - Method for decoupling main game logic from UI elements -
    public static string InputHandler()
    {
        return Console.ReadLine();
    }
    // - Method for decoupling main game logic from UI elements -
    public static void OutputHandler(string message)
    {
        Console.WriteLine(message);
    }
}