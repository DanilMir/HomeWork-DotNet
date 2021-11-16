using System;
using HW8.Models;

namespace HW8.Services
{
    public class Calculator : ICalculator
    {
        public int Calculate(int left, string operation, int right)
        {
            return operation switch
            {
                "+" => left + right,
                "-" => left - right,
                "*" => left * right,
                "/" => left / right,
                _ => 0
            };
        }
    }
}