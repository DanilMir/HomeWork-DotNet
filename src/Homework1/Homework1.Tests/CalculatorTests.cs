using System;
using Xunit;

namespace Homework1.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, "+", 2, 3)]
        [InlineData(2, "*", 2, 4)]
        [InlineData(2, "-", 2, 0)]
        [InlineData(2, "/", 2, 1)]
        [InlineData(2, ".", 2, 0)]
        public void Calculate_ValidOperations(int val1, string operation, int val2, int expected)
        {
            var actual = Calculator.Calculate(operation, val1, val2);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, "/", 0, 0)]
        public void Calculate_DivideByZero(int val1, string operation, int val2, int expected)
        {
            var actual = Calculator.Calculate(operation, val1, val2);
            Assert.Equal(expected, actual);
        }
    }
}