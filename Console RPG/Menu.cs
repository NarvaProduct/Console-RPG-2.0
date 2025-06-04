using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using InputHandling;

public class Menu<T> where T : struct, Enum
{
    private string _title;
    private T[] _options;
    private MenuControl _zeroOption;

    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }
    public T[] Options
    {
        get { return _options; }
        set { _options = value; }
    }
    public MenuControl ZeroOption
    {
        get { return _zeroOption; }
        set{ _zeroOption = value; }
    }
    public Menu(string title, T[] options, MenuControl zeroOption)
    {
        Title = title;
        Options = options;
        ZeroOption = zeroOption;
    }
    // - Method for displaying a decision menu -
    // Takes in title of menu and an array of possible options
    // Returns the enum value of the user's choice
    // Option for 0 will default to a go back option
    public T? ShowMenu()
    {
        string menuString;
        int numOptions;

        menuString = BuildMenuString(Title, Options, ZeroOption);
        numOptions = Options.Length;

        int intUserChoice;
        T userChoice;

        intUserChoice = Prompter.AskForInt(
            min: 0, max: numOptions,
            prompt: menuString,
            errorMsg: $"Invalid Entry. Please enter an option between 0 - {numOptions - 1}",
            askForKey: true
            ) - 1; // subtracts one from the int input to account for zero option
        if (intUserChoice >= 0)
        {
            userChoice = (T)Enum.ToObject(typeof(T), intUserChoice);
        }
        else
        {
            return null;
        }

        return userChoice;
    }
    private static string BuildMenuString(
        string menuTitle,
        T[] options,
        MenuControl zeroOption = MenuControl.GoBack 
        )
    {
        string menuString;
        int numOptions;

        numOptions = options.Length;
        menuString = BuildMenuTitle(menuTitle);

        for (int i = 0; i < numOptions; i++)
        {
            menuString += $"\n{i + 1}. {options[i]}";
        }
        menuString += $"\n0. {zeroOption}"; // Displays 0 option at the bottom of the list

        return menuString;
    }
    private static string BuildMenuTitle(string menuTitle)
    {
        string titleDivider = "";
        int titleLength;

        menuTitle = $"=== {menuTitle} ===";
        titleLength = menuTitle.Length;

        for (int i = 0; i < titleLength; i++) // Decides the length of the divider
        {
            titleDivider += "-";
        }
        menuTitle += $"\n{titleDivider}"; // Adds divider to the line under the title

        return menuTitle;
    }
    public enum MenuControl
    {
        GoBack,
        Exit,
        Cancel
    }
}