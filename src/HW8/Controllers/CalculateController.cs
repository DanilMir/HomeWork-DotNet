using System;
using HW8.Models;
using HW8.Services;
using Microsoft.AspNetCore.Mvc;

namespace HW8.Controllers
{
    public class CalculateController : Controller
    {
        private readonly ICalculator _calculator;
        private readonly IParser _parser;
        
        public CalculateController(ICalculator calculator, IParser parser)
        {
            _calculator = calculator;
            _parser = parser;
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Calc(string value1, string operation, string value2)
        {
            var result = _parser.TryParseArguments(
                new[] {value1, operation, value2}, 
                out var val1,
                out var oper, 
                out var val2
                );

            switch (result)
            {
                case(1):
                    return BadRequest("Values is not valid");
                case(2):
                    return BadRequest("operation is not supported");
                case (3):
                    return BadRequest("Divide by zero");
            }

            return Ok(_calculator.Calculate(val1, oper, val2));
        }
    }
}