using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculationsTextFileManager : ICalculationsFileManager
    {
        private readonly string _fileName = $"calculations.txt";
        public void Read()
        {
            if (!File.Exists(_fileName))
                return;
            foreach (string line in File.ReadAllLines(_fileName))
            {
                var calculation = line.Split('|');
                CalculationsRepository.Calculations.Add((calculation[0], double.Parse(calculation[1])));
            }
        }
        public void Write(int sessionStart)
        {
            for(int i = sessionStart; i < CalculationsRepository.Calculations.Count; i++)
            {
                var calculation = CalculationsRepository.Calculations[i];
                File.AppendAllText(_fileName, $"{calculation.calculation}|{calculation.result}{Environment.NewLine}");
            }
        }
    }
}
