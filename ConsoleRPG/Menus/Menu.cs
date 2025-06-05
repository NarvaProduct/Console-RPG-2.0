using ConsoleRPG.InputHandling;
using ConsoleRPG.Utils;

namespace ConsoleRPG.Menus;

public class Menu<T> where T : struct, Enum
{
    public string Title { get; private set; }
    public string InfoTextA { get; private set; }
    public string InfoTextB { get; private set; }
    public T[] Options { get; private set; }
    public string ZeroOption { get; private set; }

    public Menu(string title, T[] options, string zeroOption, string infoTextA = "", string infoTextB = "")
    {
        Title = title;
        InfoTextA = infoTextA;
        InfoTextB = infoTextB;
        Options = options;
        ZeroOption = zeroOption;
    }

    // - Method for displaying a decision menu -
    // Returns the enum value of the user's choice
    // If 0 option is selected, returns null
    public T? ShowMenu()
    {
        string menuString = BuildMenuString();
        int numOptions = Options.Length;

        int intUserChoice = Prompter.AskForInt(
            min: 0, max: numOptions,
            prompt: menuString,
            errorMsg: $"Invalid Entry. Please enter an option between 0 - {numOptions}",
            askForKey: true
            ) - 1; // subtracts one from the int input to account for zero option

        if (intUserChoice >= 0)
            return (T)Enum.ToObject(typeof(T), intUserChoice);
        else
            return null;
    }

    // - Builds the string that will be displayed for completed menu -
    // Variable divider creates a new line (------\n)
    private string BuildMenuString()
    {
        string menuTitle = BuildMenuTitle(out string divider);
        string infoText = BuildInfoText(divider, InfoTextA, InfoTextB);
        string optionString = BuildOptionString();
        
        string menuString = menuTitle + infoText + optionString;

        return menuString;
    }

    // - Builds string for the title of the menu - 
    // Creates fancy header with a divider and a line break
    private string BuildMenuTitle(out string divider)
    {
        string header = $"=== {Title} ===";
        divider = BuildDivider(header);

        string menuTitle = $"{header}\n{divider}"; // Adds divider to the line under the title

        return menuTitle;
    }

    // - Builds string for optional info text with an optional secondary info text -
    // The strings stringA and stringB end with a divider and a line break
    private string BuildInfoText(string divider, string stringA, string stringB)
    {
        string infoText = "";

        if (!string.IsNullOrEmpty(stringA)) infoText += $"{stringA}\n" + divider;     
        if (!string.IsNullOrEmpty(stringB)) infoText += $"{stringB}\n" + divider;

        return infoText;
    }

    // - Builds string for the possible option selections -
    private string BuildOptionString()
    {
        string optionListString = "";
        string optionString;
        string splitOptionString;

        for (int i = 0; i < Options.Length; i++)
        {
            optionString = Options[i].ToString();
            splitOptionString = StringFormatter.SplitStringByCapitals(optionString);
            optionListString += $"{i + 1}. {splitOptionString}\n";
        }

        optionListString += $"0. {ZeroOption}"; // Displays 0 option at the bottom of the list

        return optionListString;
    }

    // - Helper method that builds a divider string based on length of string input -
    // Adds a line break after divider
    private static string BuildDivider(string inputString)
    {
        string divider = "";

        for (int i = 0; i < inputString.Length; i++) // Decides the length of the divider
        {
            divider += GameSettings.DividerChar;
        }
        divider += "\n";

        return divider;
    }
}