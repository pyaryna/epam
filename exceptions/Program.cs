using epam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter printer = new ConsolePrinter();

            printer.WriteLine("Enter task number: {1(OutOfMemory), 2(OutOfRange) or 3(Argument)}");

            int taskNumber;

            bool nHasParsed = Int32.TryParse(printer.ReadLine(), out taskNumber);
            if (!nHasParsed)
                printer.WriteLine("Invalid task number");           
            else
            {
                switch (taskNumber)
                {
                    case (1):
                        try
                        {
                            printer.WriteLine("StackOverflowException cannot be caught");
                            StackOverflowMethod();
                        }
                        catch (StackOverflowException e)
                        {
                            printer.WriteLine(e.Message);
                        }
                        break;

                    case (2):
                        try
                        {
                            OutOfRangeMethod();
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            printer.WriteLine(e.Message);
                        }
                        break;

                    case (3):
                        int a = 0, b = 0;
                        try
                        {
                            printer.WriteLine("Enter a:");
                            a = Int32.Parse(printer.ReadLine());

                            printer.WriteLine("Enter b:");
                            b = Int32.Parse(printer.ReadLine());

                            DoSomeMath(a, b);
                        }
                        catch (ArgumentException e)
                        when (e.ParamName == "a")
                        {
                            printer.WriteLine(e.Message);
                        }
                        catch (ArgumentException e)
                        when (e.ParamName == "b")
                        {
                            printer.WriteLine(e.Message);
                        }
                        break;

                    default:
                        printer.WriteLine("Invalid task number");
                        break;
                }

            }                                       
            printer.ReadLine();
        }

        static public int StackOverflowMethod()
        {
            return StackOverflowMethod();
        }

        static public void OutOfRangeMethod()
        {
            int[] testArray = new int[]{ 1, 2 };

            for (int i = 0; i <= testArray.Length; i++)
                testArray[i] += 5;
        }

        static public void DoSomeMath(int a, int b)
        {
            if (a < 0)
                throw new ArgumentException("Parameter should be greater than 0", "a");
            if (b > 0)
                throw new ArgumentException("Parameter should be less than 0", "b");
        }
    }
}
