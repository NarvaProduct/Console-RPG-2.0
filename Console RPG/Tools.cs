
public class Tools
{
    // - Method for reading strings -
    // showError will be true only if checkInt returns an error
    public static string ReadString(
        string prompt = "Please enter a string",
        string errorMsg = "Invalid string entry",
        bool showError = false,
        bool keyEntry = false
        )
    {
        string inputString;

        do
        {
            inputString = DisplayManager.AskUser(
            request: prompt,
            errorMsg: errorMsg,
            showError: showError,
            keyEntry: keyEntry
        );
        } while (inputString == null || inputString == "");

        return inputString;

    }
    // - Method for reading integers -
    // There are default messages for the prompt and the error message
    // min and max are for defining the allowed range of integers for the user to enter
    public static int ReadInt(
        int min,
        int max,
        string prompt = "Please enter an integer",
        string errorMsg = "Invalid integer entry",
        bool keyEntry = false
        )
    {
        string inputString;
        int inputInt;

        inputString = ReadString(
            prompt: prompt,
            errorMsg: errorMsg,
            showError: false,
            keyEntry: keyEntry);

        if (!int.TryParse(inputString, out inputInt) || inputInt < min || inputInt > max)
        {
            do
            {
                inputString = ReadString(
                prompt: prompt,
                errorMsg: errorMsg,
                showError: true,
                keyEntry: keyEntry
                );
            } while (!int.TryParse(inputString, out inputInt) || inputInt < min || inputInt > max);
        }
        return inputInt;
    }
    // - Method for reading a boolean -
    // To Do:
    // + Change the default case to not return false. Maybe don't use a switch?
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
            errorMsg: errorMsg,
            keyEntry: true
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
                DisplayManager.ShowMsg("An error has occured. Returning false.");
                inputBool = false;
                return inputBool;
        }
    }
}