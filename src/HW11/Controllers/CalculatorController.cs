using System;
using System.Linq.Expressions;
using HW11.Services;
using Microsoft.AspNetCore.Mvc;

namespace HW11.Controllers
{
    public class CalculatorController : Controller
    {
        private ICalculatorVisitor _visitor;
        private readonly IExceptionHandler _exceptionHandler;

        public CalculatorController(ICalculatorVisitor visitor, IExceptionHandler exceptionHandler)
        {
            _visitor = visitor;
            _exceptionHandler = exceptionHandler;
        }
        
        [HttpGet, Route("calc")]
        public IActionResult Calc(string expr)
        {
            try
            {
                expr = expr.Replace(" ", "+");
                var temp = Parser.Parse(expr);
                var visit = _visitor.Visit(temp);
                var t = (int) (_visitor.Visit(temp) as ConstantExpression)?.Value!;
                return Ok(t);
            }
            catch(Exception e)
            {
                _exceptionHandler.HandleException(e);
                return Content(e.Message);
            }
        }

    }
}