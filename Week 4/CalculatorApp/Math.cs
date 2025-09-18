using System;

namespace CalculatorApp
{
    public class Math : ICalculator
    {
        public decimal Add(decimal a, decimal b) => a + b;

        public decimal Subtract(decimal a, decimal b) => a - b;

        public decimal Multiply(decimal a, decimal b) => a * b;

        public decimal Divide(decimal a, decimal b)
        {
            if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }
    }
}
