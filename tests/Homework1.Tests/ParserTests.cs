using Xunit;

namespace Homework1.Tests
{
    public class ParserTests
    {
        [Theory]
        [InlineData(new string[] {"2", "+", "3"}, 2, "+", 3, 0)]
        [InlineData(new string[] {"2", "*", "3"}, 2, "*", 3, 0)]
        [InlineData(new string[] {"2", "-", "1"}, 2, "-", 1, 0)]
        [InlineData(new string[] {"2", "/", "2"}, 2, "/", 2, 0)]
        public void TryParseArguments_ValidArguments(
            string[] args, int exceptedVal1,
            string expectedOperation, 
            int expectedVal2, 
            int expected)
        {
            var actual = Parser.TryParseArguments(args, out var val1, out var operation, out var val2);
            Assert.Equal(expected, actual);
            Assert.Equal(exceptedVal1, val1);
            Assert.Equal(expectedOperation, operation);
            Assert.Equal(expectedVal2, val2);
        }
        
        [Theory]
        [InlineData(new string[] {".1", "+", ".3"}, 1)]
        public void TryParseArguments_InvalidValues(string[] args, int expected)
        {
            var actual = Parser.TryParseArguments(args, out var val1, out var operation, out var val2);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(new string[] {"2", ".", "3"}, 2, ".", 3, 2)]
        public void TryParseArguments_InvalidOperation(
            string[] args, int exceptedVal1,
            string expectedOperation, 
            int expectedVal2, 
            int expected)
        {
            var actual = Parser.TryParseArguments(args, out var val1, out var operation, out var val2);
            Assert.Equal(expected, actual);
            Assert.Equal(exceptedVal1, val1);
            Assert.Equal(expectedOperation, operation);
            Assert.Equal(expectedVal2, val2);
        }
    }
}