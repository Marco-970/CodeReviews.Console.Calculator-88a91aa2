using Calculator.Application;
using Tools;
namespace Calculator;

internal class Program
{
    static void Main(string[] args)
    {
        int _uses = 0;
        ConsoleUserInteractor _consoleUserInteractor = new ConsoleUserInteractor();
        ICalculationsFileManager _calculationsFileManager = new CalculationsTextFileManager();
        ICalculatorUserInteractor _userInteractor = new CalculatorConsoleUserInteractor((_consoleUserInteractor));
        App _app = new App(_userInteractor, new MathLogic());

        bool _keepCalculating = true;
        _calculationsFileManager.Read();
        int sessionStart = CalculationsRepository.Calculations.Count;

        while (_keepCalculating)
        {
            _uses++;
            _consoleUserInteractor.DisplayMessage($"Calculations this session: {_uses}");
            _app.Run();
            _keepCalculating = _userInteractor.PromptUserForAnotherCalculation();
            _consoleUserInteractor.Clear();
        }
        _calculationsFileManager.Write(sessionStart);

        _userInteractor.Quit();
    }
}
