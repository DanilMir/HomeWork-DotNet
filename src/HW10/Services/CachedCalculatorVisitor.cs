using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Threading;
using HW10.Models;
using HW10.Services;

namespace HW10.Services
{
    public class CachedCalculatorVisitor : ICalculatorVisitor
    {
        private readonly ICalculatorVisitor _calculatorVisitor;
        private AppContext _context;
        private readonly ConcurrentDictionary<string, int> _cache = new();
        
        public CachedCalculatorVisitor(ICalculatorVisitor calculatorVisitor, AppContext context)
        {
            _calculatorVisitor = calculatorVisitor;
            _context = context;
        }
        
        public Expression Visit(Expression node)
        {
            //var cache = _context.ExpressionCache.Find(node.ToString());

            if (_cache.ContainsKey(node.ToString()))
            {
                //return Expression.Constant(cache.Value);
                return Expression.Constant(_cache[node.ToString()]);
            }

            var result = _calculatorVisitor.Visit(node) as ConstantExpression;

            _cache[node.ToString()] = (int) result?.Value!;
            
            // _context.ExpressionCache.Add(new ExpressionModel()
            // {
            //     Expression = node.ToString(),
            //     Value = (int) result?.Value!
            // });
            //_context.SaveChanges();
            return result;
        }
    }
}