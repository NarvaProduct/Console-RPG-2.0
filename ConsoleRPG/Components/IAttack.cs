using ConsoleRPG.Entities;

namespace ConsoleRPG.Components;

public interface IAttack
{
    int Damage { get; }

    void PerformAttack(GameEntity target);
    int CalculateDamage(GameEntity target);
}