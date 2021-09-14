using System.Diagnostics.Contracts;

namespace Homework1
{
    static public class Calculator
    {
        public static int Calculate(string operation, int val1, int val2)
        {
            var result = operation switch
            {
                "+" => val1 + val2,
                "-" => val1 - val2,
                "*" => val1 * val2,
                "/" => val1 / val2,
                _ => 0
            };
            return result;
        }
    }
}