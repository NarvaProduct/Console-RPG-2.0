public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            int userInput = GameMenu.MainGameMenu();
            if (userInput == 5) Dice.RollDCustom(6);
        }
    }
}
