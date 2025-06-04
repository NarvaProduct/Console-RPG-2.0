using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using InputHandling;

namespace menu;

public class Menu
{
    // - Method for displaying a decision menu -
    // Takes in title of menu and an array of possible options
    // Returns the enum value of the user's choice
    // Option for 0 will default to a go back option
    public static T ShowMenu<T>(
        string menuTitle,
        T[] options,
        string zeroOption = "Go Back"
        )  where T : struct, Enum
    {
        string optionListString;
        int numOptions;

        optionListString = BuildMenuString<T>(menuTitle, options, zeroOption);
        numOptions = options.Length;

        int intUserChoice;
        T userChoice;
        bool enumValidity;

        intUserChoice = Prompter.AskForInt(
            min: 0, max: numOptions,
            prompt: optionListString,
            errorMsg: $"Invalid Entry. Please enter an option between 0 - {numOptions - 1}",
            askForKey: true
            ) - 1; // subtracts one from the int input to account for zero option

        userChoice = (T)Enum.ToObject(typeof(T), intUserChoice);
        
        return userChoice;
    }
    public static string BuildMenuString<T>(
        string menuTitle,
        T[] options,
        string zeroOption = "Go Back"
        )
    {
        string titleDivider = "";
        string optionListString;
        int numOptions;
        int titleLength;

        menuTitle = $"=== {menuTitle} ===";
        numOptions = options.Length;
        titleLength = menuTitle.Length;

        for (int i = 0; i < titleLength; i++) // Decides the length of the divider
        {
            titleDivider += "-";
        }
        menuTitle += "\n" + titleDivider; // Adds divider to the line under the title
        optionListString = menuTitle;

        for (int i = 0; i < numOptions; i++)
        {
            optionListString += "\n" + (i + 1) + ". " + options[i];
        }
        optionListString += "\n0. " + zeroOption; // Displays 0 option at the bottom of the list

        return optionListString;
    }
}