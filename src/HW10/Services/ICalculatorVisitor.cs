using System.Linq.Expressions;

namespace HW10.Services
{
    public interface ICalculatorVisitor
    {
        public Expression Visit(Expression node);
    }
}