using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace Homework1.Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData(new string[] {"2", "+", "3"}, 0)]
        [InlineData(new string[] {"2", "*", "3"}, 0)]
        [InlineData(new string[] {"2", "-", "1"}, 0)]
        [InlineData(new string[] {"2", "/", "2"}, 0)]
        public void Main_ValidArguments(string[] args, int excepted)
        {
            var actual = Program.Main(args);
            Assert.Equal(excepted, actual);
        }
        
        [Theory]
        [InlineData(new string[] {".", "+", "."}, 1)]
        [InlineData(new string[] {"2", ".", "3"}, 2)]
        [InlineData(new string[] {".", ".", "."}, 1)]
        [InlineData(new string[] {"", "", ""}, 1)]
        [InlineData(new string[] {""}, 3)]
        [InlineData(new string[] {"", "", "", ""}, 3)]
        [InlineData(new string[] {"0", "/", "0"}, 4)]
        public void Main_InvalidArguments(string[] args, int excepted)
        {
            var actual = Program.Main(args);
            Assert.Equal(excepted, actual);
        }
    }
}