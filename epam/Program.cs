using epam.Task1;
using epam.Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter printer = new ConsolePrinter();

            #region Task 1
            printer.WriteLine("Task 1");

            Person Peter = new Person("Peter", "Black", 60);
            Person Ann = new Person("Ann", "White", 22);

            printer.WriteLine("Enter n: ");
            
            int n = Int32.Parse(Console.ReadLine());

            printer.WriteLine(Peter.IsOlderThen(n));
            printer.WriteLine(Ann.IsOlderThen(n));

            #endregion

            printer.WriteLine(new string('-', 20));

            #region Task 2
            printer.WriteLine("\nTask 2");

            printer.WriteLine("Enter width: ");
            int width = Int32.Parse(Console.ReadLine());

            printer.WriteLine("Enter height: ");
            int height = Int32.Parse(Console.ReadLine());

            Rectangle rectangle = new Rectangle(0, 0, width, height);

            printer.WriteLine("The perimeter of example rectangle = " + rectangle.Perimeter());

            #endregion

            printer.ReadLine();

        }
    }
}
