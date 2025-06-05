using System.Text.RegularExpressions;

namespace ConsoleRPG.Utils;

public class StringFormatter
{
    // - Splits a string by capital letters - 
    public static string SplitStringByCapitals(string stringInput)
    {
        string separatedString = "";
        string word;
        string[] words = Regex.Split(stringInput, @"(?=[A-Z])");

        for (int i = 0; i < words.Length; i++)
        {
            word = words[i];

            if (i != (words.Length - 1))
            {
                separatedString += $"{word} ";
            }
            else separatedString += $"{word}"; // Prevents the last word of string to not have white space
            
        }
        return separatedString;
    }
}