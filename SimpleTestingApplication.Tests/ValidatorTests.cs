using NumberConverter;

namespace SimpleTestingApplication.Tests
{
    public class ValidatorTests
    {
        // Tests for IsValidBase method
        [Theory]
        [InlineData(2, true)]  // Minimum valid base (binary)
        [InlineData(10, true)] // Standard decimal base
        [InlineData(16, true)] // Maximum valid base (hexadecimal)
        [InlineData(1, false)] // Below valid base range
        [InlineData(17, false)] // Above valid base range
        public void IsValidBase_ValidAndInvalidBases_ReturnsExpectedResult(int baseValue, bool expected)
        {
            var result = Validator.IsValidBase(baseValue);
            Assert.Equal(expected, result);
        }

        // Tests for IsValidNumber method
        [Theory]
        [InlineData("101", 2, true)]      // Valid binary number
        [InlineData("FF", 16, true)]      // Valid hexadecimal number
        [InlineData("123", 10, true)]     // Valid decimal number
        [InlineData("-123", 10, true)]    // Valid negative decimal number
        [InlineData("G", 16, false)]      // Invalid character for base 16
        [InlineData("9", 8, false)]       // Invalid character for base 8
        [InlineData("-FF", 16, true)]     // Valid negative hexadecimal number
        [InlineData("-G", 16, false)]     // Invalid negative number with invalid character for base 16
        public void IsValidNumber_ValidAndInvalidNumbers_ReturnsExpectedResult(string number, int baseValue, bool expected)
        {
            var result = Validator.IsValidNumber(number, baseValue);
            Assert.Equal(expected, result);
        }

        // Test for private IsValidDigit method via IsValidNumber method
        [Theory]
        [InlineData('1', 2, true)]     // Valid binary digit
        [InlineData('0', 2, true)]     // Valid binary digit
        [InlineData('9', 10, true)]    // Valid decimal digit
        [InlineData('A', 16, true)]    // Valid hexadecimal digit
        [InlineData('G', 16, false)]   // Invalid hexadecimal digit
        [InlineData('8', 8, false)]    // Invalid octal digit
        public void IsValidNumber_ValidAndInvalidDigits_ReturnsExpectedResult(char digit, int baseValue, bool expected)
        {
            var result = Validator.IsValidNumber(digit.ToString(), baseValue);
            Assert.Equal(expected, result);
        }
    }
}
