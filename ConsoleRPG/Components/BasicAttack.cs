using ConsoleRPG.Entities;

namespace ConsoleRPG.Components;

public class BasicAttack : IAttack
{
    public int Damage { get; private set; }
    public BasicAttack(int damage)
    {
        Damage = damage;
    }
    public void PerformAttack(GameEntity target)
    {
        target.ReceiveDamage(Damage);
    }
}