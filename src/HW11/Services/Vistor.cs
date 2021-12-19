using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace HW11.Services
{
    public class Visitor : ExpressionVisitor, ICalculatorVisitor
    {
        public Expression Visit(Expression node)
        {
            return Visit((dynamic) node);
        }

        private Expression Visit(BinaryExpression node)
        {
            var left = Task.Run(() => Visit(node.Left));
            var right = Task.Run(() => Visit(node.Right));

            Thread.Sleep(1000);
            var t = Task.WhenAll(left, right);
            t.Wait();
            var leftVal = (int)(t.Result[0] as ConstantExpression)?.Value!;
            var rightVal = (int)(t.Result[1] as ConstantExpression)?.Value!;
            var result = node.NodeType switch
            {
                ExpressionType.Add => leftVal + rightVal,
                ExpressionType.Subtract => leftVal - rightVal,
                ExpressionType.Multiply => leftVal * rightVal,
                ExpressionType.Divide => leftVal / rightVal,
            };

            return Expression.Constant(result);
        }

        private Expression Visit(ConstantExpression node)
        {
            return node;
        }
    }
}