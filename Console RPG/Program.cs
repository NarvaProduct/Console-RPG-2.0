using System.Net;
using InputHandling;
using Microsoft.Win32.SafeHandles;

public class Program
{
    public static void Main(string[] args)
    {
        var menu = new Menu<Donuts>("Choose Donut Flavor", Enum.GetValues<Donuts>(), Menu<Donuts>.MenuControl.Exit);

        Donuts? donut = menu.ShowMenu();








        Type type = donut.GetType();
        string typeName = type.Name;
        UserInterface.ShowMsg($"You chose {donut}! The donut variable is of type {typeName}");
    }
}
public enum Donuts
{
    Glazed,
    Chocolate,
    Strawberry,
    Lemon
}
