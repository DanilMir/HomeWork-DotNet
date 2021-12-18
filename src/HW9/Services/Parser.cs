using System;
using System.Linq.Expressions;
using System.Text;

namespace HW9.Services
{
    public static class Parser
    {
        public static Expression Parse(string s)
        {
            int bracketCount = 0;
            int operatorIndex = -1;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '(') bracketCount++;
                else if (c == ')') bracketCount--;
                else if ((c is '+' or '-') && bracketCount == 0)
                {
                    operatorIndex = i;
                    break;
                }
                else if ((c is '*' or '/') && bracketCount == 0 && operatorIndex < 0)
                {
                    operatorIndex = i;
                }
            }

            if (operatorIndex < 0)
            {
                s = s.Trim();
                if (s[0] == '(' && s[^1] == ')')
                {
                    return Parse(s.Substring(1, s.Length - 2)); // todo: mb problems
                }
                return Expression.Constant(int.Parse(s)); // mb problems
            }
            
            var right = Parse(s[operatorIndex] == '-' ? Negative(s[(operatorIndex + 1)..]) :
                s[(operatorIndex + 1)..]);
            return Expression.MakeBinary(ParseExpressionType(s[operatorIndex]), Parse(s[..operatorIndex]),
                right);
        }

        private static string Negative(string expression)
        {
            var sb = new StringBuilder(expression);
            for (var i = 0; i < sb.Length; i++)
            {
                if (sb[i] is '-')
                    sb[i] = '+';
                if (sb[i] is '+')
                    sb[i] = '-';
            }

            return sb.ToString();
        }
        
        private static ExpressionType ParseExpressionType(char c)
        {
            return c switch
            {
                '+' => ExpressionType.Add,
                '-' => ExpressionType.Subtract,
                '*' => ExpressionType.Multiply,
                '/' => ExpressionType.Divide,
                _ => throw new ArgumentException()
            };
        }
        
    }
}