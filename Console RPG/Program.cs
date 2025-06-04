using System.Net;
using InputHandling;
using menu;
using Microsoft.Win32.SafeHandles;

public class Program
{
    public static void Main(string[] args)
    {
        Donuts donut;
        donut = Menu.ShowMenu<Donuts>("Select Flavor of Donut", Enum.GetValues<Donuts>(), "No Donut for me ;(");
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
