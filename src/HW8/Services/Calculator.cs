using HW8.Models;

namespace HW8.Services
{
    public class Calculator : ICalculator
    {
        public decimal Calculate(decimal left, string operation, decimal right)
        {
            return operation switch
            {
                "+" => left + right,
                "-" => left - right,
                "*" => left * right,
                "/" => right == 0
                    ? 0
                    : left / right,
                _ => 0
            };
        }
    }
}