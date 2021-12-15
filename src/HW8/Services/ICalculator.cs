using HW8.Models;

namespace HW8.Services
{
    public interface ICalculator
    {
        public int Calculate(int val1, string operand, int val2);
    }
}