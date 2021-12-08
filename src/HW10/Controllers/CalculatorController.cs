using System.Linq.Expressions;
using HW10.Services;
using Microsoft.AspNetCore.Mvc;

namespace HW10.Controllers
{
    public class CalculatorController : Controller
    {
        private CachedCalculatorVisitor _visitor;

        public CalculatorController(CachedCalculatorVisitor visitor)
        {
            _visitor = visitor;
        }
        
        [HttpGet, Route("calc")]
        public IActionResult Calc(string expr)
        {
            expr = expr.Replace(" ", "+");
            var temp = Parser.Parse(expr);
            var visit = _visitor.Visit(temp);
            var t = (int) (_visitor.Visit(temp) as ConstantExpression)?.Value!;
            return Ok(t);
        }

    }
}