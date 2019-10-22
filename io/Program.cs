using NLog;
using printer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace io
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter printer = new ConsolePrinter();           

            printer.WriteLine("Enter path to directory: ");
            string directoryPath = printer.ReadLine(); //@"E:\\me\\other"

            DirectoryInfo dir = new DirectoryInfo(directoryPath);

            WorkWithIO worker = new WorkWithIO();

            printer.WriteLine("\nTask 1");

            worker.GetFilesTree(dir, printer, 0);

            printer.WriteLine("\nTask 2");

            string partialName = ".txt";
            worker.FindFileInDirectory(dir, partialName, printer, 0);
                       
            printer.ReadLine();

        }      
    }
}
