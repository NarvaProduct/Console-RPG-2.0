public class Program
{
    public static void Main(string[] args)
    {
        string[] options = new string[]
        {
            null, "Garbanzo bean", "Balsemic Juice?", "Ballgina"
        };
        int userChoice = Tools.DecisionMenu("Choose your guy", options);
        Console.Clear();
        Console.WriteLine($"User chose {userChoice}. {options[userChoice]}");

    }
}
