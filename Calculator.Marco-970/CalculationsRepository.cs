using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class CalculationsRepository
    {
        public static List<(string calculation, double result)> Calculations = new();
    }
}
