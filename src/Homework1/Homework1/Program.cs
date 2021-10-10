using System;
using System.Linq;
using Homework4;
using static Homework4.Calculator.result;
namespace Homework1
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (CheckArgsCount(args) != 0)
                return 3;

            var var1 = Homework4.Parser.parseValue(args[0]);
            var var2 = Homework4.Parser.parseValue(args[2]);
            var operation = args[1];

            if (var1.Item1 == BadValue || var2.Item1 == BadValue)
            {
                return 1;
            }
            var result = Homework4.Calculator.Calculate(var1.Item2, operation, var2.Item2);
            if (result.Item1 == DivideByZero)
            {
                return 4;
            }

            if (result.Item1 == UndefinedOperation)
            {
                return 2;
            }
            
            Console.WriteLine($"{args[0]} {args[1]} {args[2]} = {result.Item2}");

            return 0;
        }
        
        public static int CheckArgsCount(string[] args)
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