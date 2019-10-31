using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class CalculatorConsolePrinter: ICalculatorPrinter
    {
        public void WriteLine(string value)
        {
            Console.WriteLine("result = " + value);
            Console.ReadLine();
        }

        public string ReadLine()
        {
            Console.WriteLine("enter expression: {a,b,operation}");
            return Console.ReadLine();
        }
    }
}
