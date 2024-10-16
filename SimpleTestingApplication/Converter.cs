using System.Text;

namespace NumberConverter
{
    public static class Converter
    {
        public static string ConvertBase(string number, int fromBase, int toBase)
        {
            if (!Validator.IsValidBase(fromBase))
                throw new ArgumentException($"Invalid base {fromBase}");

            if (!Validator.IsValidBase(toBase))
                throw new ArgumentException($"Invalid base {toBase}");

            if(!Validator.IsValidNumber(number, fromBase)) 
                throw new ArgumentException($"Invalid input number {number} for base {fromBase}");

            bool isNegative = number.StartsWith("-");
            string absoluteNumber = isNegative ? number.Substring(1) : number;
            long decimalValue = ConvertToDecimal(absoluteNumber, fromBase);
            string result = ConvertFromDecimal(decimalValue, toBase);

            return isNegative ? "-" + result : result;
        }

        private static long ConvertToDecimal(string number, int fromBase)
        {
            long decimalValue = 0;
            int length = number.Length;

            for (int i = 0; i < length; i++)
            {
                char digitChar = number[i];
                int digitValue = CharToInt(digitChar);

                decimalValue += digitValue * (long)Math.Pow(fromBase, length - i - 1);
            }

            return decimalValue;
        }

        private static string ConvertFromDecimal(long decimalValue, int toBase)
        {
            if (decimalValue == 0) return "0";

            StringBuilder result = new StringBuilder();

            while (decimalValue > 0)
            {
                long remainder = decimalValue % toBase;
                result.Insert(0, IntToChar((int)remainder));
                decimalValue /= toBase;
            }

            return result.ToString();
        }

        private static int CharToInt(char c)
        {
            if (char.IsDigit(c)) return c - '0';
            if (char.IsLetter(c)) return char.ToUpper(c) - 'A' + 10;
            throw new ArgumentException($"Invalid character {c}.");
        }

        private static char IntToChar(int value)
        {
            if (value >= 0 && value <= 9) return (char)('0' + value);
            if (value >= 10 && value <= 15) return (char)('A' + value - 10);
            throw new ArgumentException($"Invalid integer value {value}.");
        }
    }
}
