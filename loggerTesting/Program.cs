using logger;
using printer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loggerTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter consolePrinter = new ConsolePrinter();

            consolePrinter.WriteLine("Enter logger number: {1(Console) or 2(File)}");

            int loggerNumber;
            
            int[] array = new int[2] { 1, 2 };

            bool nHasParsed = Int32.TryParse(consolePrinter.ReadLine(), out loggerNumber);
            if (!nHasParsed)
                consolePrinter.WriteLine("Invalid logger number");
            else
            {
                try
                {
                    array[10] = 1;
                }
                catch(IndexOutOfRangeException e)
                {
                    switch (loggerNumber)
                    {
                        case (1):
                            Logger consoleLogger = new Logger(consolePrinter);
                            consoleLogger.WriteMessage(e.Message);
                            break;

                        case (2):
                            string path = "info.log";
                            FilePrinter filePrinter = new FilePrinter(path);
                            Logger fileLogger = new Logger(filePrinter);
                            fileLogger.WriteMessage(e.Message);
                            break;                        
                        default:
                            consolePrinter.WriteLine("Invalid logger number");
                            break;
                    }
                }
            }
            consolePrinter.ReadLine();
        }
    }
}
