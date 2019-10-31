using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    interface ICalculatorPrinter
    {
        void WriteLine(string value);
        string ReadLine();
    }
}
