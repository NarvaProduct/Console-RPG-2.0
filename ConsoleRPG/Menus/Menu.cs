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
        get => _title;
        set => _title = value;
    }

    public T[] Options
    {
        get => _options;
        set => _options = value;
    }

    public MenuControl ZeroOption
    {
        get => _zeroOption;
        set => _zeroOption = value;
    }

    public Menu(string title, T[] options, MenuControl zeroOption)
    {
        Title = title;
        Options = options;
        ZeroOption = zeroOption;
    }
    // - Method for displaying a decision menu -
    // Returns the enum value of the user's choice
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
    private string BuildMenuString()
    {
        string menuString = BuildMenuTitle();

        for (int i = 0; i < Options.Length; i++)
        {
            menuString += $"\n{i + 1}. {Options[i]}";
        }
        menuString += $"\n0. {ZeroOption}"; // Displays 0 option at the bottom of the list

        return menuString;
    }
    private string BuildMenuTitle()
    {
        string titleDivider = "";
        string menuTitle = "";
        string header = $"=== {Title} ===";
        int titleLength = header.Length;

        for (int i = 0; i < titleLength; i++) // Decides the length of the divider
        {
            titleDivider += "-";
        }
        menuTitle += $"{header}\n{titleDivider}"; // Adds divider to the line under the title

        return menuTitle;
    }
    public enum MenuControl
    {
        GoBack,
        Exit,
        Cancel
    }
}