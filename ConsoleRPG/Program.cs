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
        Console.Title = GameSettings.GameTitle;
        
        // GameManager.Run();
        GameEntity player = new GameEntity(
            name: "Player",
            health: new BasicHealth(100),
            attack: new BasicAttack(50),
            defense: new BasicDefense()
            );

        GameEntity enemy = new GameEntity(
            name: "Enemy",
            health: new BasicHealth(100),
            attack: new BasicAttack(50),
            defense: new BasicDefense()
            );

        BattleMenu battleMenu = new BattleMenu(
            title: "Battle", player, enemy
            );

        battleMenu.Show();
    }
}