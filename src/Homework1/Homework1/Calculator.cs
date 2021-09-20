using System;
using System.Diagnostics.Contracts;

namespace Homework1
{
    public static class Calculator
    {
        public static int Calculate(string operation, int val1, int val2)
        {
            switch (operation)
            {
                case "+":
                    return val1 + val2;
                case "-":
                    return val1 - val2;
                case "*":
                    return val1 * val2;
                case "/":
                    if (val2 == 0)
                    {
                        Console.WriteLine("Error: Val 2 was 0");
                        return Int32.MaxValue;
                        //throw new DivideByZeroException("Val 2 was 0");
                    }

                    return val1 / val2;
                default:
                    return 0;
            }
        }
    }
}