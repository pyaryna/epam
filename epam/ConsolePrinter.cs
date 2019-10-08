using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam
{
    public class ConsolePrinter: IPrinter
    {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
