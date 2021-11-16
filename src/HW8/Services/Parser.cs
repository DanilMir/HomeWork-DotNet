using System;
using System.Linq;

namespace HW8.Services
{
    public class Parser : IParser
    {
        private static readonly String[] SupportedOperations =
        {
            "+",
            "-",
            "*",
            "/",
            "+"
        };

        public int TryParseArguments(string[] args, out int val1, out string operation, out int val2)
        {
            var isVal1Int = int.TryParse(args[0], out val1);
            operation = args[1];
            var isVal2Int = int.TryParse(args[2], out val2);

            if (!isVal1Int || !isVal2Int)
            {
                return 1;
            }

            if (!SupportedOperations.Contains(operation))
            {
                return 2;
            }

            if (val2 == 0 && operation == "/")
                return 3;
            return 0;
        }
    }
}