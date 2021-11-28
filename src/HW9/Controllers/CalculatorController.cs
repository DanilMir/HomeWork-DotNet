using System.Linq.Expressions;
using HW9.Services;
using Microsoft.AspNetCore.Mvc;

namespace HW9.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet, Route("calc")]
        public IActionResult Calc(string expr)
        {
            var temp = Parser.Parse(expr);
            var visit = new Visitor().Visit(temp);
            var t = (int) (new Visitor().Visit(temp) as ConstantExpression)?.Value!;
            return Ok(t);
        }

    }
}