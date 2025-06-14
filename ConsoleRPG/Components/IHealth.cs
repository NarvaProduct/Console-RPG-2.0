namespace ConsoleRPG.Components;

public interface IHealth
{
    int CurrentHealth { get; }
    int MaxHealth { get; }

    void TakeDamage(int amount);
    void Heal(int amount);
    bool IsDead{ get; }
}