using System;
using System.Linq;

namespace Homework1
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (CheckArgsCount(args) != 0)
                return 3;
            
            var parseResult = Parser.TryParseArguments(args, out var val1, out var operation, out var val2);
            if (parseResult != 0)
            {
                return parseResult;
            }

            var result = Calculator.Calculate(operation, val1, val2);
            Console.WriteLine($"{args[0]} {args[1]} {args[2]} = {result}");

            return 0;
        }

        private static int CheckArgsCount(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("The number of arguments must be 3");
                return 3;
            }

            return 0;
        }
    }
}