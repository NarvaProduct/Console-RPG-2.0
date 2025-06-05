namespace ConsoleRPG.Components;

public class BasicDefense : IDefense
{
    public int Defense { get; private set; }

    public BasicDefense(int initialDefense = 0)
    {
        Defense = Math.Clamp(initialDefense, 0, 30);
    }

    public double DefenseToPercent()
    {
        double doubleDefense = (double)Defense;
        double percentDefense = doubleDefense / 100;

        return percentDefense;
    }

    public void RaiseDefense(int amount)
    {
        Defense += amount;
        if (Defense < 0) Defense = 0;
        if (Defense > 30) Defense = 30;
    }
    
    public void LowerDefense(int amount)
    {
        Defense -= amount;
        if (Defense < 0) Defense = 0;
        if (Defense > 30) Defense = 30;
    }
}