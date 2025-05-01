//
public class Dice
{
    public static int RollDCustom(int amountSides)
    {
        Tools.ClearConsole();
        Random random = new Random();
        int diceResult = random.Next(amountSides);

        Tools.OutputHandler($"Rolling a {amountSides} sided dice!");
        for (int i = 0; i <= 3; i++)
        {
            Thread.Sleep(1000);
            Tools.OutputHandler(".");
        }
        Tools.OutputHandler($"\nThe dice rolled a {diceResult}!");
        Tools.OutputHandler("Press enter to continue");
        Tools.CharInputHandler();
        Tools.ClearConsole();

        return diceResult;
    }
}