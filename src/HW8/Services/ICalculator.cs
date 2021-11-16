using HW8.Models;

namespace HW8.Services
{
    public interface ICalculator
    {
        public decimal Calculate(decimal val1, string operand, decimal val2);
    }
}