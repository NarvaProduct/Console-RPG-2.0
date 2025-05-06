namespace InputHandling
{
    public class Validator
    {
        // - Method for translating a console key input into a string -
        public static string KeyToString(ConsoleKeyInfo key)
        {
            string keyString;
            keyString = key.KeyChar.ToString();

            return keyString;
        }
        // - Method for validating strings -
        public static bool ValidateString(string inputString)
        {
            bool stringValidity;

            if (inputString == null || inputString == "")
            {
                stringValidity = false;
                return stringValidity;
            }
            else
            {
                stringValidity = true;
                return stringValidity;
            }
        }

        // - Method for validating integers -
        // Default for intValue will be 0 if validation fails
        public static bool ValidateInt(string inputString, out int intValue)
        {
            bool intValidity;
            bool stringValidity;

            stringValidity = ValidateString(inputString);
            if (!stringValidity)
            {
                intValidity = false;
                intValue = 0;
                return intValidity;
            }
            else if (!int.TryParse(inputString, out intValue))
            {
                intValidity = false;
                intValue = 0;
                return intValidity;
            }
            else
            {
                intValidity = true;
                return intValidity;
            }
        }
        // - Method for validating a boolean -
        // Default for boolValue will be false if validation fails
        public static bool ValidateBool(string inputString, out bool boolValue)
        {
            bool intValidity;
            bool boolValidity;
            int intValue;

            intValidity = ValidateInt(inputString, out intValue);
<<<<<<< HEAD
            if (intValue != 0 && intValue != 1)
=======
            if (intValidity)
            {
                if (intValue != 0 || intValue != 1)
                {
                    boolValue = false;
                    boolValidity = false;
                    return boolValidity;
                }
                else if (intValue == 0)
                {
                    boolValue = false;
                    boolValidity = true;
                    return boolValidity;
                }
                else
                {
                    boolValue = true;
                    boolValidity = true;
                    return boolValidity;
                }
            }
            else
>>>>>>> d387c83ab334856a9c759a09ab39e1f931dbb156
            {
                boolValue = false;
                boolValidity = false;
                return boolValidity;
            }
        }
    }
}
