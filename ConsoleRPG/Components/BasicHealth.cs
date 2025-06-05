namespace ConsoleRPG.Components;

public class BasicHealth : IHealth
{
    public int CurrentHealth { get; private set; }
    public int MaxHealth { get; private set; }

    public bool IsDead => CurrentHealth <= 0;

    public BasicHealth(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }
    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth < 0) CurrentHealth = 0;
    }
    public void Heal(int amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth >= MaxHealth) CurrentHealth = MaxHealth;
    }
}