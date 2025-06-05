using ConsoleRPG.Components;

namespace ConsoleRPG.Components;

public interface IAttack
{
    int Damage { get; }

    void PerformAttack(GameEntity target);
}