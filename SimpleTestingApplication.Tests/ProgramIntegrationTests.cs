using NumberConverter;

namespace SimpleTestingApplication.Tests
{
    public class ProgramIntegrationTests
    {
        [Fact]
        public void Program_ValidInput_ConvertsNumberCorrectly()
        {
            var inputReader = new StringReader("2\n101\n10\nexit\n");
            var outputWriter = new StringWriter();
            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);

            Program.Main(new string[0]);

            var output = outputWriter.ToString();
            Assert.Contains("The number 101 in base 2 is 5 in base 10.", output);
        }

        [Fact]
        public void Program_InvalidBase_ShowsErrorMessage()
        {
            var inputReader = new StringReader("20\nexit\n");
            var outputWriter = new StringWriter();
            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);

            Program.Main(new string[0]);

            var output = outputWriter.ToString();
            Assert.Contains("Please enter a valid base between 2 and 16.", output);
        }

        [Fact]
        public void Program_InvalidNumber_ShowsErrorMessage()
        {
            var inputReader = new StringReader("10\nZZZ\nexit\n");
            var outputWriter = new StringWriter();
            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);

            Program.Main(new string[0]);

            var output = outputWriter.ToString();
            Assert.Contains("Invalid number for base 10. Please try again.", output);
        }

        [Fact]
        public void Program_ExitCommand_ExitsApplication()
        {
            var inputReader = new StringReader("exit\n");
            var outputWriter = new StringWriter();
            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);

            Program.Main(new string[0]);

            var output = outputWriter.ToString();
            Assert.Contains("Exiting application...", output);
        }
    }
}
