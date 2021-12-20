using System.Linq.Expressions;

namespace HW11.Services
{
    public interface ICalculatorVisitor
    {
        public Expression Visit(Expression node);
    }
}