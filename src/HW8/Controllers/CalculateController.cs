using HW8.Services;
using Microsoft.AspNetCore.Mvc;

namespace HW8.Controllers
{
    public class CalculateController : Controller
    {
        private readonly ICalculator _calculator;
        
        public CalculateController(ICalculator calculator)
        {
            _calculator = calculator;
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public decimal Add(decimal val1, decimal val2)
        {
            return _calculator.Calculate(val1, "+", val2);
        }
        //https://localhost:5001/Calculate/add?val1=1&val2=2
        
        [HttpGet]
        public decimal Sub(decimal val1, decimal val2)
        {
            return _calculator.Calculate(val1, "-", val2);
        }
        //https://localhost:5001/Calculate/sub?val1=1&val2=2
        
        [HttpGet]
        public decimal Div(decimal val1, decimal val2)
        {
            return _calculator.Calculate(val1, "/", val2);
        }
        //https://localhost:5001/Calculate/div?val1=1&val2=1
        
        [HttpGet]
        public decimal Mult(decimal val1, decimal val2)
        {
            return _calculator.Calculate(val1, "*", val2);
        }
    }
}