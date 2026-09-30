using Calculator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Calculator
{
    public class CalculatorConsoleUserInteractor : ICalculatorUserInteractor
    {
        private readonly IUserInteractor _console;
        public CalculatorConsoleUserInteractor(IUserInteractor console)
        {
            _console = console;
        }
        public (double number, double power) PromptUserForPower()
        {
            _console.DisplayMessage("\nEnter the number:\n");
            double number = double.Parse(GetUserInput());
            _console.DisplayMessage("\nEnter the power:\n");
            double power = double.Parse(GetUserInput());
            return (number, power);
        }
        public (double x, double y) PromptUserForNumbers()
        {
            _console.DisplayMessage("\nEnter the first number:\n");
            double x = double.Parse(GetUserInput());
            _console.DisplayMessage("\nEnter the second number:\n");
            double y = double.Parse(GetUserInput());
            return (x, y);
        }
        public double PromptUserForNumber()
        {
            _console.DisplayMessage("\nEnter the number:\n");
            return double.Parse(GetUserInput());
        }
        
        public void DisplayMessage(string message) => _console.DisplayMessage(message);

        public void WriteOnSameLine(string message) => _console.WriteOnSameLine(message);

        public void ReadKey() => _console.ReadKey();

        public string GetUserInput() => _console.GetUserInput();

        public void Clear() => _console.Clear();

        public void Quit() => _console.Quit();

        public bool PromptUserForAnotherCalculation()
        {
            _console.DisplayMessage("\nDo you want to calculate some more? Y/N");
            return GetUserInput().ToUpper() == "Y" ? true : false;
        }
        public void DisplayPastCalculations(int calculationsAmount)
        {
            Clear();
            calculationsAmount = Math.Min(calculationsAmount, CalculationsRepository.Calculations.Count);
            if(CalculationsRepository.Calculations.Count == 0)
            {
                _console.DisplayMessage("There are no past calculations.");
                return;
            }
            _console.DisplayMessage("---------------");
            for(int i = CalculationsRepository.Calculations.Count - 1; i >= CalculationsRepository.Calculations.Count - calculationsAmount; i--)
            {
                var calculation = CalculationsRepository.Calculations[i];
                _console.DisplayMessage($"{calculation.calculation}\n---------------\n");
            }
        }
        public void DisplayMenu()
        {
            _console.DisplayMessage("Select from the menu what you'd like to do. Write the name or the symbol if there is one.\nChoose Past to check the last 10 calculations.");
            _console.DisplayMessage("---------------");
            foreach (var option in Enum.GetNames(typeof(MenuOptions)))
            {
                _console.DisplayMessage($"{option}\n---------------");
            }
        }
    }
}
