namespace ConsoleRPG.Components;

public interface IDefense
{
    // Defense stat will scale from 0 - 30 with each point being a percent reduction
    int Defense { get; }

    double DefenseToPercent();
    void RaiseDefense(int amount);
    void LowerDefense(int amount);

}