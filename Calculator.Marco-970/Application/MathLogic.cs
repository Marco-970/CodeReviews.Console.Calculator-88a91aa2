using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Application
{
    public class MathLogic
    {
        public double Add(double x, double y) => x + y;
        public double Subtract(double x, double y) => x - y;
        public double Multiply(double x, double y) => x * y;
        public double Divide(double x, double y) => x / y;
        public double SquareRoot(double x) => Math.Sqrt(x);
        public double Power(double x, double y) => Math.Pow(x, y);
        public double Sine(double x) => Math.Sin(x);
        public double Cosine(double x) => Math.Cos(x);
        public double Tan(double x) => Math.Tan(x);
    }
}
