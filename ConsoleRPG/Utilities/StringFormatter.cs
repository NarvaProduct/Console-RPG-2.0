using System;
using System.Text.RegularExpressions;

namespace ConsoleRPG.Utils;

public class StringFormatter
{
    // - Splits a string by capital letters - 
    public static string SplitStringByCapitals(string stringInput)
    {
        string[] words = Regex.Split(stringInput, @"(?=[A-Z])");
        return string.Join(" ", words.Where(w => !string.IsNullOrEmpty(w)));
    }
}