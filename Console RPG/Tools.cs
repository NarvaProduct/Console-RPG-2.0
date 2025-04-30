
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
        userChoice = ReadInt(min: 0, max: numOptions, prompt: optionListString, errorMsg: "Invalid choice, please select one of the options");


        return userChoice;
    }
    // - Method for reading strings -
    public static string ReadString(string prompt = "Please enter a string", string errorMsg = "Invalid entry")
    {
        string inputString;

        Console.Clear();
        Console.WriteLine(prompt);
        inputString = Console.ReadLine();
        if (inputString == null || inputString == "")
        {
            do
            {
                Console.Clear();
                Console.WriteLine(errorMsg);
                inputString = Console.ReadLine();
            } while (inputString == null || inputString == "");
        }
        Console.Clear();

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

        Console.Clear();
        inputString = ReadString(prompt, errorMsg);
        if (!int.TryParse(inputString, out inputInt) || inputInt < min || inputInt > max)
        {
            do
            {
                Console.Clear();
                Console.WriteLine(errorMsg);
                inputString = ReadString(prompt, errorMsg);
            } while (!int.TryParse(inputString, out inputInt) || inputInt < min || inputInt > max);
        }
        return inputInt;
    }
}