using System;

namespace Homework1
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var val1 = int.Parse(args[0]);
            var operation = args[1];
            var val2 = int.Parse(args[2]);
            var result = 0;
            switch (operation)
            {
                case "+":
                    result = val1 + val2;
                    break;
                case "-":
                    result = val1 - val2;
                    break;
                case "*":
                    result = val1 * val2;
                    break;
                case "/":
                    result = val1 / val2;
                    break;
            }
            Console.WriteLine($"{args[0]} {args[1]} {args[2]} = {result}");
        }
    }
}