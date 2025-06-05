using ConsoleRPG.Menus;

namespace ConsoleRPG;

public static class GameManager
{
    public static void Run()
    {
        new MainMenu().Show();
    }
    
}