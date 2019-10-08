using enums.Task1;
using enums.Task2;
using enums.Task3;
using epam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enums
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter printer = new ConsolePrinter();

            #region Task 1

            printer.WriteLine("Task 1");

            printer.WriteLine("Enter n: ");
            int n, month = -1;
            bool nHasParsed = Int32.TryParse(printer.ReadLine(), out n);
            if (!nHasParsed)
                printer.WriteLine("Invalid n");
            else
                month = ((n - 1 >= 0) && (n - 1 < 12) ? n - 1 : -1);

            printer.WriteLine((month == -1) ? "Invalid n" : ((Months)month).ToString());

            #endregion

            #region Task 2

            printer.WriteLine("\nTask 2");

            var colors = new Colors();
            colors.PrintAscending(printer);

            #endregion

            #region Task 3

            printer.WriteLine("\nTask 3");

            printer.WriteLine($"{(long)LongRange.Max} - {LongRange.Max.ToString()}");
            printer.WriteLine($"{(long)LongRange.Min} - {LongRange.Min.ToString()}");

            #endregion

            printer.ReadLine();
        }
    }
}
