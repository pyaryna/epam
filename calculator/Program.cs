using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            NameValueCollection settings = ConfigurationManager.AppSettings;
            CalculatorFilePrinter filePrinter = new CalculatorFilePrinter(settings["fileToRead"], settings["fileToWrite"]);
            Calculator calculator = new Calculator(filePrinter);
            calculator.ReadExpression();
            var result = calculator.Calculate();
            calculator.WriteResult(result);

            CalculatorConsolePrinter consolePrinter = new CalculatorConsolePrinter();
            calculator = new Calculator(consolePrinter);
            calculator.ReadExpression();
            result = calculator.Calculate();
            calculator.WriteResult(result);
        }
    }
}
