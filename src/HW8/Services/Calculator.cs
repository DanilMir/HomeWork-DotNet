using HW8.Models;

namespace HW8.Services
{
    public class Calculator : ICalculator
    {
        public decimal Calculate(int left, string operation, int right)
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