using NLog;
using printer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stylecop
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter printer = new ConsolePrinter();
            Logger logger = LogManager.GetCurrentClassLogger();

            Rectangle testRctangle1 = new Rectangle(new Point(1, 1), new Point(2, 2));
            Rectangle testRctangle2 = new Rectangle(new Point(3, 3), new Point(4, 4));

            printer.WriteLine(testRctangle1.ToString());
            printer.WriteLine(testRctangle2.ToString());
            printer.WriteLine(testRctangle1.Move(2, 3).ToString());
            printer.WriteLine(testRctangle1.ChangeSize(2).ToString());
            printer.WriteLine(testRctangle1.GetCapsuleOfTwoShapes(testRctangle2).ToString());
            try
            {
                printer.WriteLine(testRctangle1.GetIntersection(testRctangle2).ToString());
                
            }
            catch(ArgumentException e)
            {
                logger.Fatal("GetCapsuleOfTwoShapes method for rectangles; " + e.Message);
            }            

            printer.WriteLine(new string('-', 20));

            Circle testCircle1 = new Circle(new Point(4, 2), 1);

            Circle testCircle2 = new Circle(new Point(2, 3), 4);

            printer.WriteLine(testCircle1.ToString());
            printer.WriteLine(testCircle2.ToString());
            printer.WriteLine(testCircle1.Move(2, 3).ToString());
            printer.WriteLine(testCircle1.ChangeSize(2).ToString());
            printer.WriteLine(testCircle1.GetCapsuleOfTwoShapes(testCircle2).ToString());
            try
            {
                printer.WriteLine(testCircle1.GetIntersection(testCircle2).ToString());
                
            }
            catch (ArgumentException e)
            {
                logger.Fatal("GetCapsuleOfTwoShapes method for circles; " + e.Message);
            }

            printer.ReadLine();
        }
    }
}
