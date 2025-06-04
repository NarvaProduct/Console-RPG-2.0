using static InputHandling.Validator;

namespace InputHandling;

public class Prompter
{
    // - Helper method for getting a string input with validation, custom prompt, and custom error message -
    public static string AskForString(
        string prompt = "Please enter a string",
        string errorMsg = "Invalid string. Please try again"
    )
    {
        string inputString;

        UserInterface.ShowMsg(prompt);
        inputString = UserInterface.AskLn();

        if (!ValidateString(inputString))
        {
            UserInterface.ShowMsg(prompt + "\n" + errorMsg);
            inputString = UserInterface.AskLn();
            while (!ValidateString(inputString)) // While loop starts after error message to not clear console each re-entry
            {
                inputString = UserInterface.AskLn();
            }
        }
        return inputString;
    }
    // - Helper method for getting a integer input with validation, custom prompt, and custom error message -
    // If askForKey is true, input will be a single character
    public static int AskForInt(
        int min, int max,
        string prompt = "Please enter an integer",
        string errorMsg = "Invalid integer. Please try again",
        bool askForKey = false
    )
    {
        string inputString = "";
        ConsoleKeyInfo inputKey;
        int intValue;

        UserInterface.ShowMsg(prompt);
        if (!askForKey)
        {
            inputString = UserInterface.AskLn();

            if (!ValidateInt(inputString, out intValue) || intValue < min || intValue > max)
            {
                UserInterface.ShowMsg(prompt + "\n" + errorMsg);
                inputString = UserInterface.AskLn();
                while (!ValidateInt(inputString, out intValue) || intValue < min || intValue > max) // While loop starts after error message to not clear console each re-entry
                {
                    inputString = UserInterface.AskLn();
                }
            }

            return intValue;
        }
        else
        {
            inputKey = UserInterface.AskKey();
            inputString = KeyToString(inputKey);

            if (!ValidateInt(inputString, out intValue) || intValue < min || intValue > max)
            {
                UserInterface.ShowMsg(prompt + "\n" + errorMsg);
                inputKey = UserInterface.AskKey();
                inputString = KeyToString(inputKey);

                while (!ValidateInt(inputString, out intValue) || intValue < min || intValue > max) // While loop starts after error message to not clear console each re-entry
                {
                    inputKey = UserInterface.AskKey();
                    inputString = KeyToString(inputKey);
                }
            }

            return intValue;
        }
    }
    // - Helper method for getting a boolean input with validation, custom prompt, and custom error message -
    public static bool AskForBool(
        string prompt = "Please enter 1 (yes) or 0 (no)",
        string errorMsg = "Invalid Entry. Please try again"
    )
    {
        string inputString;
        int intValue;
        bool boolValue;

        UserInterface.ShowMsg(prompt);
        inputString = UserInterface.AskLn();

        if (!ValidateBool(inputString, out boolValue))
        {
            UserInterface.ShowMsg(prompt + "\n" + errorMsg);
            inputString = UserInterface.AskLn();
            while (!ValidateBool(inputString, out boolValue)) // While loop starts after error message to not clear console each re-entry
            {
                inputString = UserInterface.AskLn();
            }
        }
        return boolValue;
    }    
}
