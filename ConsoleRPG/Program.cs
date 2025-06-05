using System.Net;
using ConsoleRPG;
using ConsoleRPG.Components;
using InputHandling;

public class Program
{
    public static void Main(string[] args)
    {
        GameEntity player = new GameEntity("Player", new BasicHealth(100), new BasicAttack(25));
        GameEntity enemy = new GameEntity("Enemy", new BasicHealth(100), new BasicAttack(25));

        player.AttackTarget(enemy);
        UserInterface.ShowMsg($"{player.Name} dealt {player.Attack.Damage} to {enemy.Name}!\n{enemy.Name} now has {enemy.Health.CurrentHealth} health!");

    } 
}