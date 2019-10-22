using System;

namespace printer
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
