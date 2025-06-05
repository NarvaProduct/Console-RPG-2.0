namespace ConsoleRPG.InputHandling;

public class UserInterface
{
    // - Method for displaying a message -
    public static void ShowMsg(string msg, bool waitForKey = false, bool clearConsole = true)
    {
        if (clearConsole) ClearConsole();

        Console.WriteLine(msg);
        if (waitForKey)
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
    // - Method for requesting user input as a line -
    public static string AskLn()
    {
        string inputString;

        inputString = Console.ReadLine();
        return inputString;
    }
    // - Mehtod for requesting key input -
    public static ConsoleKeyInfo AskKey()
    {
        ConsoleKeyInfo key;

        key = Console.ReadKey(intercept: true);
        return key;
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