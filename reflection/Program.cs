using logger;
using printer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace reflection
{
    class Program
    {       
        static void Main(string[] args)
        {
            ConsolePrinter printer = new ConsolePrinter();

            Reflector reflector = new Reflector("printer", printer, new Logger(printer));

            printer.WriteLine(new string('-', 20));

            reflector.ListAllTypes();
            reflector.ListAllMembers("FilePrinter");
            reflector.GetParams("FilePrinter", "WriteLine");
            object[] instanceParameters = new object[] { "testFile.txt" };
            reflector.CreateInstance("FilePrinter", instanceParameters);
            object[] methodParameters = new object[] { "some text for invoked method" };
            reflector.InvokeMethod("FilePrinter", "WriteLine", instanceParameters, methodParameters);
            reflector.InvokeMethod("FilePrinter", "WriteLine", instanceParameters);

            printer.ReadLine();
        }
    }
}
