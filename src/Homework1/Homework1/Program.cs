using System;
using System.Linq;

namespace Homework1
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (Homework2.Parser.CheckArgsCount(args) != 0)
                return 3;
            
            var parseResult = Homework2.Parser.TryParseArguments(args, out var val1, out var operation, out var val2);
            if (parseResult != 0)
            {
                return parseResult;
            }

            var result = Homework2.Calculator.Calculate(operation, val1, val2);
            if (result == Int32.MaxValue)
                return 4;
            Console.WriteLine($"{args[0]} {args[1]} {args[2]} = {result}");

            return 0;
        }
    }
}