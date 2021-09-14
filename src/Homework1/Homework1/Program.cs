using System;
using System.Linq;

namespace Homework1
{
    internal static class Program
    {
        private static String[] ValidOperations = new[]
        {
            "+",
            "-",
            "*",
            "/"
        };
        
        static int Main(string[] args)
        {
            var isVal1Int = int.TryParse(args[0], out var val1);
            var operation = args[1];
            var isVal2Int = int.TryParse(args[2], out var val2);

            if (!isVal1Int || !isVal2Int)
            {
                Console.WriteLine($"{args[0]} {args[1]} {args[2]} is not valid");
                return 1;
            }

            if (!ValidOperations.Contains(operation))
            {
                Console.WriteLine($"{args[0]} {args[1]} {args[2]} is not valid calculation syntax. "
                + $"Supported Operaions are " +
                $"{ValidOperations.Aggregate((c, n) => $"{c} {n}")}");
                return 2;
            }
            
            var result = operation switch
            {
                "+" => val1 + val2,
                "-" => val1 - val2,
                "*" => val1 * val2,
                "/" => val1 / val2,
                _ => 0
            };
            Console.WriteLine($"{args[0]} {args[1]} {args[2]} = {result}");

            return 0;
        }
    }
}