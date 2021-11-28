using System;
using System.Linq.Expressions;

namespace HW9.Services
{
    public class Parser
    {
        public Expression Parse(string s)
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
                    return Parse(s.Substring(1, s.Length - 1)); // todo: mb problems
                }
                return Expression.Constant(int.Parse(s)); // mb problems
            }
            return Expression.MakeBinary(parseExpressionType(s[operatorIndex]), Parse(s[..operatorIndex]),
                Parse(s[(operatorIndex + 1)..]));
        }

        private ExpressionType parseExpressionType(char c)
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