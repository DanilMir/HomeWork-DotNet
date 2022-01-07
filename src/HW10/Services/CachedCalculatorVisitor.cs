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
        private static readonly ConcurrentDictionary<string, int> Cache = new();
        
        public CachedCalculatorVisitor(ICalculatorVisitor calculatorVisitor, AppContext context)
        {
            _calculatorVisitor = calculatorVisitor;
            _context = context;
        }
        
        public Expression Visit(Expression node)
        {
            if (Cache.ContainsKey(node.ToString()))
            {
                return Expression.Constant(Cache[node.ToString()]);
            }

            var result = _calculatorVisitor.Visit(node) as ConstantExpression;

            Cache[node.ToString()] = (int) result?.Value!;
            
            return result;
        }
    }
}