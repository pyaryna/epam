using NLog;
using printer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace threads
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter printer = new ConsolePrinter();
            Logger logger = LogManager.GetCurrentClassLogger();

            int rows = 0, columns = 0, amountOfThreads = 1;

            try
            {
                printer.WriteLine("Enter amount of rows:");
                rows = Int32.Parse(printer.ReadLine());

                printer.WriteLine("Enter amount of columns:");
                columns = Int32.Parse(printer.ReadLine());

                printer.WriteLine("Enter amount of threads:");
                amountOfThreads = Int32.Parse(printer.ReadLine());
            }
            catch(FormatException e)
            {
                logger.Fatal("ReadLile" + e.Message);
            }
            
            Matrix matrix = new Matrix(rows, columns);            

            Stopwatch sw = new Stopwatch();

            sw.Start();

            int sum = matrix.AddElements(amountOfThreads);

            sw.Stop();

            printer.WriteLine($"Sum = {sum}\nAmount of Threads = {amountOfThreads}, Elapsed = {sw.ElapsedMilliseconds} milliseconds");

            printer.ReadLine();
        }
    }
}
