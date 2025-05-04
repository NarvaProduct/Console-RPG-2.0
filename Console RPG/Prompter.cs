using static InputHandling.Validator;
namespace InputHandling
{
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
        // - Helper method for getting a integer input with validation, custom prompt, and custom error message. If askForKey is true, input will be a single character -
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
            string titleDivider = "";
            string optionListString;
            int userChoice;
            int numOptions;
            int titleLength;

            numOptions = options.Length;
            titleLength = menuTitle.Length;

            for (int i = 0; i < titleLength; i++) // Decides the length of the divider under title based on how long title is
            {
                titleDivider = titleDivider + "-";
            }
            menuTitle = menuTitle + "\n" + titleDivider; // Adds divider to the line under the title
            optionListString = menuTitle;

            for (int i = 1; i < numOptions; i++) // Skips index zero because 0 will always be null (go back option)
            {
                optionListString = optionListString + "\n" + i + ". " + options[i];
            }
            optionListString = optionListString + "\n0. " + zeroOption; // Displays 0 option at the bottom of the list

            userChoice = AskForInt(
                min: 0, max: numOptions - 1, 
                prompt: optionListString,
                errorMsg: $"Invalid Entry. Please enter an option between 0 - {numOptions - 1}",
                askForKey: true
                );

            return userChoice;
        }
    }
    
}