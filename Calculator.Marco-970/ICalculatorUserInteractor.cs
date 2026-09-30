using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Calculator
{
    public interface ICalculatorUserInteractor : IUserInteractor
    {
        public (double number, double power) PromptUserForPower();
        public (double x, double y) PromptUserForNumbers();
        public double PromptUserForNumber();
        public bool PromptUserForAnotherCalculation();
        public void DisplayPastCalculations(int calculationsAmount);
        public void DisplayMenu();
    }
}
