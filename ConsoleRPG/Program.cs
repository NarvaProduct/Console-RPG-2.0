using ConsoleRPG;
using ConsoleRPG.Components;
using ConsoleRPG.InputHandling;
using ConsoleRPG.Entities;
using ConsoleRPG.Menus;
using ConsoleRPG.Utils;
using System.Text;


public class Program
{
    public static void Main(string[] args)
    {
        Console.CursorVisible = false;
        new MainMenu().Show();
    }
}