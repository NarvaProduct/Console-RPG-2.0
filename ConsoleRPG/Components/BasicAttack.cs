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
        int reducedDamage = CalculateDamage(target);
        target.ReceiveDamage(reducedDamage);
    }

    public int CalculateDamage(GameEntity target)
    {
        double percentReduction = target.Defense.DefenseToPercent();
        double reducedDamage = Damage * (1 - percentReduction);

        int roundedDamage = Convert.ToInt32(reducedDamage);
        return roundedDamage;
    }
}