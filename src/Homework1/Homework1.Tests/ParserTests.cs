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
        public void TryParseArguments_ValidArguments_ReturnAsExcepted(
            string[] args, int exceptedVal1,
            string exceptedOperation, 
            int exceptedVal2, 
            int excepted)
        {
            var actual = Parser.TryParseArguments(args, out var val1, out var operation, out var val2);
            Assert.Equal(excepted, actual);
            Assert.Equal(exceptedVal1, val1);
            Assert.Equal(exceptedOperation, operation);
            Assert.Equal(exceptedVal2, val2);
        }
        
        [Theory]
        [InlineData(new string[] {".1", "+", ".3"}, 2, "+", 3, 1)]
        public void TryParseArguments_InvalidValues_ReturnAsExcepted(
            string[] args, int exceptedVal1,
            string exceptedOperation, 
            int exceptedVal2, 
            int excepted)
        {
            var actual = Parser.TryParseArguments(args, out var val1, out var operation, out var val2);
            Assert.Equal(excepted, actual);
        }
        
        [Theory]
        [InlineData(new string[] {"2", ".", "3"}, 2, ".", 3, 2)]
        public void TryParseArguments_InvalidOperation_ReturnAsExcepted(
            string[] args, int exceptedVal1,
            string exceptedOperation, 
            int exceptedVal2, 
            int excepted)
        {
            var actual = Parser.TryParseArguments(args, out var val1, out var operation, out var val2);
            Assert.Equal(excepted, actual);
            Assert.Equal(exceptedVal1, val1);
            Assert.Equal(exceptedOperation, operation);
            Assert.Equal(exceptedVal2, val2);
        }
    }
}