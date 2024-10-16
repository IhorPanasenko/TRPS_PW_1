using NumberConverter;

namespace SimpleTestingApplication.Tests
{
    public class ConverterTests
    {
        [Theory]
        [InlineData("101", 2, 10, "5")]
        [InlineData("5", 10, 2, "101")]
        [InlineData("A", 16, 10, "10")]
        [InlineData("10", 10, 16, "A")]
        [InlineData("111", 2, 16, "7")]
        [InlineData("7", 16, 2, "111")]
        [InlineData("123", 8, 10, "83")]
        [InlineData("83", 10, 8, "123")]
        public void ConvertBase_ValidConversions_ReturnsExpectedResult(string number, int fromBase, int toBase, string expected)
        {
            var result = Converter.ConvertBase(number, fromBase, toBase);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("-101", 2, 10, "-5")]
        [InlineData("-A", 16, 10, "-10")]
        [InlineData("-5", 10, 2, "-101")]
        public void ConvertBase_NegativeNumbers_ReturnsExpectedResult(string number, int fromBase, int toBase, string expected)
        {
            var result = Converter.ConvertBase(number, fromBase, toBase);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertBase_Zero_ReturnsZero()
        {
            var result = Converter.ConvertBase("0", 10, 2);
            Assert.Equal("0", result);
        }

        [Theory]
        [InlineData("G", 16)]
        [InlineData("2", 2)]
        public void ConvertBase_InvalidCharacter_ThrowsArgumentException(string number, int fromBase)
        {
            var exception = Assert.Throws<ArgumentException>(() => Converter.ConvertBase(number, fromBase, 10));
            Assert.Equal($"Invalid input number {number} for base {fromBase}", exception.Message);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(37)]
        public void ConvertBase_InvalidBase_ThrowsArgumentException(int baseValue)
        {
            var exception = Assert.Throws<ArgumentException>(() => Converter.ConvertBase("10", baseValue, 10));
            Assert.Equal($"Invalid base {baseValue}", exception.Message);
        }
    }
}
