using Calculator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Calculator.Application
{
    internal class App
    {
        ICalculatorUserInteractor _userInteractor;
        MathLogic _mathLogic;
        public App(ICalculatorUserInteractor userInteractor, MathLogic mathLogic)
        {
            _userInteractor = userInteractor;
            _mathLogic = mathLogic;
        }

        public void Run()
        {
            string _calculation = "";
            double _result = 0;
            _userInteractor.DisplayMenu();
            
            switch(_userInteractor.GetUserInput())
            {
                case "Addition":
                case "+":
                    (double x, double y) additionNumbers = _userInteractor.PromptUserForNumbers();
                    _result = _mathLogic.Add(additionNumbers.x, additionNumbers.y);
                    _calculation = $"{additionNumbers.x} + {additionNumbers.y} = {_result}";
                    _userInteractor.DisplayMessage($"\n{_calculation}");
                    break;
                case "Subtraction":
                case "-":
                    (double x, double y) subtractionNumbers = _userInteractor.PromptUserForNumbers();
                    _result = _mathLogic.Subtract(subtractionNumbers.x, subtractionNumbers.y);
                    _calculation = $"{subtractionNumbers.x} - {subtractionNumbers.y} = {_result}";
                    _userInteractor.DisplayMessage($"\n{_calculation}");
                    break;
                case "Multiplication":
                case "x":
                    (double x, double y) multiplicationNumbers = _userInteractor.PromptUserForNumbers();
                    _result = _mathLogic.Multiply(multiplicationNumbers.x, multiplicationNumbers.y);
                    _calculation = $"{multiplicationNumbers.x} * {multiplicationNumbers.y} = {_result}";
                    _userInteractor.DisplayMessage($"\n{_calculation}");
                    break;
                case "Division":
                case "/":
                    (double x, double y) divisionNumbers = _userInteractor.PromptUserForNumbers();
                    _result = _mathLogic.Divide(divisionNumbers.x, divisionNumbers.y);
                    _calculation = $"{divisionNumbers.x} / {divisionNumbers.y} = {_result}";
                    _userInteractor.DisplayMessage($"\n{_calculation}");
                    break;
                case "Square":
                    double squareNumber = _userInteractor.PromptUserForNumber();
                    _result = _mathLogic.SquareRoot(squareNumber);
                    _calculation = $"√{squareNumber} = {_result}";
                    _userInteractor.DisplayMessage($"\n{_calculation}");
                    break;
                case "Power":
                    (double number, double power) pow = _userInteractor.PromptUserForPower();
                    _result = _mathLogic.Power(pow.number, pow.power);
                    _calculation = $"{pow.number} pow {pow.power} = {_result}";
                    _userInteractor.DisplayMessage($"\n{_calculation}");
                    break;
                case "Sine":
                    double sinNumber = _userInteractor.PromptUserForNumber();
                    _result = _mathLogic.Sine(sinNumber);
                    _calculation = $"Sine of {sinNumber} = {_result}";
                    _userInteractor.DisplayMessage($"\n{_calculation}");
                    break;
                case "Cosine":
                    double cosineNumber = _userInteractor.PromptUserForNumber();
                    _result = _mathLogic.Cosine(cosineNumber);
                    _calculation = $"Cosine of {cosineNumber} = {_result}";
                    _userInteractor.DisplayMessage($"\n{_calculation}");
                    break;
                case "Tan":
                    double tanNumber = _userInteractor.PromptUserForNumber();
                    _result = _mathLogic.Tan(tanNumber);
                    _calculation = $"Tan of {tanNumber} = {_result}";
                    _userInteractor.DisplayMessage($"\n{_calculation}");
                    break;
                case "Past":
                    _userInteractor.DisplayPastCalculations(10);
                    break;
            }
            if (!string.IsNullOrEmpty(_calculation))
            {
                CalculationsRepository.Calculations.Add((_calculation, _result));
            }
        }
    }
}
