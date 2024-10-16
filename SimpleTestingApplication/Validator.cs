namespace NumberConverter
{
    public static class Validator
    {
        public static bool IsValidBase(int baseValue)
        {
            return baseValue >= 2 && baseValue <= 16;
        }

        public static bool IsValidNumber(string number, int baseValue)
        {
            bool isNegative = number.StartsWith("-");
            string absoluteNumber = isNegative ? number.Substring(1) : number;

            foreach (char digit in absoluteNumber)
            {
                if (!IsValidDigit(digit, baseValue))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsValidDigit(char digit, int baseValue)
        {
            if (char.IsDigit(digit))
            {
                return digit - '0' < baseValue;
            }
            else if (char.IsLetter(digit))
            {
                int digitValue = char.ToUpper(digit) - 'A' + 10;
                return digitValue < baseValue;
            }
            return false;
        }

    }
}
