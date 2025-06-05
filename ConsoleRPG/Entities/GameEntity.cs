using ConsoleRPG.Components;

namespace ConsoleRPG.Entities;

public class GameEntity
{
    public string Name { get; private set; }
    public IHealth Health { get; private set; }
    public IAttack Attack { get; private set; }
    public IDefense Defense{ get; private set; }

    public GameEntity(string name, IHealth health, IAttack attack, IDefense defense)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defense = defense;
    }
    public void ReceiveDamage(int amount)
    {
        Health.TakeDamage(amount);
    }
    public void Heal(int amount)
    {
        Health.TakeDamage(amount);
    }
    public void AttackTarget(GameEntity target)
    {
        if (Attack != null)
        {
            Attack.PerformAttack(target);
        }
    }
}
