using System.Reflection;
using ConsoleRPG.Entities;

namespace ConsoleRPG.Menus;

public class BattleMenu
{
    internal enum BattleMenuControls
    {
        Attack,
        Magic,
        Inventory
    }
    internal enum BattleMenuState
    {
        IntroToBattle,
        WaitingForChoice,
        ShowingPlayerMove,
        ShowingEnemyMove,
        ShowingConclusion,
        PauseMenuSelected
    }
    private Menu<BattleMenuControls> Menu { get; set; }
    private BattleMenuState BattleState{ get; set; }

    public BattleMenu(string title, GameEntity player, GameEntity enemy)
    {
        Menu = new Menu<BattleMenuControls>(
            title: title,
            options: Enum.GetValues<BattleMenuControls>(),
            zeroOption: "Pause Menu",
            infoTextA: BuildEntityText(enemy),
            infoTextB: BuildEntityText(player)
        );
        BattleState = BattleMenuState.IntroToBattle;
    }

    public void Show()
    {
        BattleMenuControls? userChoice = Menu.ShowMenu();
    }

    private void HandleBattleMenu(BattleMenuControls? userChoice)
    {
        switch (userChoice)
        {
            case BattleMenuControls.Attack:
                
                break;
            case BattleMenuControls.Magic:

                break;
            case BattleMenuControls.Inventory:

                break;
            case null:

                break;
        }
    }

    public void UpdateBattleMenu()
    {
        
    }

    private string BuildEntityText(GameEntity entity)
    {
        string entityNameString = $"{entity.Name}\n";
        string entityHealthString = $"{entity.Health.CurrentHealth}/{entity.Health.MaxHealth}";

        string entityText = entityNameString + entityHealthString;

        return entityText;
    }
}