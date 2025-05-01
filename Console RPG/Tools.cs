
public class Tools
{
    // - Method for reading strings -
    // showError will be true only if checkInt returns an error
    // To do: 
    // + Move the I/O handling to another class
    public static string ReadString(
        string prompt = "Please enter a string",
        string errorMsg = "Invalid string entry",
        bool showError = false
        )
    {
        string inputString;

        ClearConsole();
        OutputHandler(prompt);
        if (showError) OutputHandler(errorMsg);
        inputString = StringInputHandler();
        while (inputString == null || inputString == "")
        {
            ClearConsole();
            OutputHandler(prompt);
            OutputHandler(errorMsg);
            inputString = StringInputHandler();
        }
        ClearConsole();

        return inputString;
    }
    // - Method for reading integers -
    // There are default messages for the prompt and the error message
    // min and max are for defining the allowed range of integers for the user to enter
    public static int ReadInt(
        int min,
        int max,
        string prompt = "Please enter an integer",
        string errorMsg = "Invalid integer entry"
        )
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
    // - Method for reading a boolean -
    public static bool ReadBool(
        string prompt = "Please enter 1 (Yes) or 0 (No)",
        string errorMsg = "Invalid boolean entry"
    )
    {
        int inputInt;
        bool inputBool;

        inputInt = ReadInt(
            min: 0,
            max: 1,
            prompt: prompt,
            errorMsg: errorMsg
        );
        switch (inputInt)
        {
            case 0:
                inputBool = false;
                return inputBool;
            case 1:
                inputBool = true;
                return inputBool;
            default:
                OutputHandler("An error has occured. Returning false.");
                inputBool = false;
                return inputBool;
        }
    }
    // - Method for skipping Console.Clear() in debug mode -
    public static void ClearConsole()
    {
        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }
    }
    // - Method for decoupling main game logic from UI elements -
    public static string StringInputHandler()
    {
        return Console.ReadLine();
    }
    // - Method for decoupling main game logic from UI elements -
    public static ConsoleKeyInfo CharInputHandler()
    {
        return Console.ReadKey();
    }
    // - Method for decoupling main game logic from UI elements -
    public static void OutputHandler(string message)
    {
        Console.WriteLine(message);
    }
}