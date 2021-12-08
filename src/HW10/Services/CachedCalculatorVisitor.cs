using System.Linq.Expressions;
using HW10.Models;
using HW10.Services;

namespace HW10.Services
{
    public class CachedCalculatorVisitor : ICalculatorVisitor
    {
        private ICalculatorVisitor _calculatorVisitor;
        private AppContext _context;
        
        public CachedCalculatorVisitor(ICalculatorVisitor calculatorVisitor, AppContext context)
        {
            _calculatorVisitor = calculatorVisitor;
            _context = context;
        }
        
        public Expression Visit(Expression node)
        {
            var cache = _context.ExpressionCache.Find(node.ToString());
            if (cache != null)
            {
                return Expression.Constant(cache.Value);
            }

            var result = _calculatorVisitor.Visit(node) as ConstantExpression;

            _context.ExpressionCache.Add(new ExpressionModel()
            {
                Expression = node.ToString(),
                Value = (int) result?.Value!
            });
            _context.SaveChanges();
            return result;
        }
    }
}