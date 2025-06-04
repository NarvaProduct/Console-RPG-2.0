public class Dice
{
    // - Method for rolling a custom sided dice -
    public static int RollDCustom(int amountSides)
    {
        string diceRollPrompt = $"Rolling a {amountSides} sided dice!";
        string loadingAnimation = "";

        Random random = new Random();
        int diceResult = random.Next(1, amountSides);

        for (int i = 0; i <= 3; i++) // Waits 3 seconds before result is displayed
        {
            Thread.Sleep(1000);
            loadingAnimation = loadingAnimation + ".";
            UserInterface.ShowMsg(diceRollPrompt + loadingAnimation);
        }

        UserInterface.ShowMsg($"You rolled a {diceResult}!", waitForKey: true);

        return diceResult;
    }
}