using System;
using Xunit;

namespace Homework1.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, "+", 2, 3)]
        [InlineData(2, "*", 2, 4)]
        public void Calculate_ValidOperationsWorksAsExcepted(int val1, string operation, int val2, int excepted)
        {
            var actual = Calculator.Calculate(operation, val1, val2);
            Assert.Equal(excepted, actual);
        }
    }
}