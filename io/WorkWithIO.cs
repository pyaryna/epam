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
    class WorkWithIO: IWorkWithIO
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public void GetFilesTree(DirectoryInfo dir, IPrinter printer, int indentLevel)
        {
            printer.WriteLine($"{new string('\t', indentLevel)} {dir.ToString()}");

            try
            {
                DirectoryInfo[] subDirectories = dir.GetDirectories();
                FileInfo[] filesInDir = dir.GetFiles();

                foreach (DirectoryInfo d in subDirectories)
                {
                    GetFilesTree(d, printer, indentLevel + 1);
                }

                foreach (FileInfo f in filesInDir)
                {
                    printer.WriteLine($"{new string('\t', indentLevel + 1)} {f.Name}");
                }
            }
            catch (IOException e)
            {
                _logger.Fatal("GetFilesTree method", e.Message);
            }


        }
        public void FindFileInDirectory(DirectoryInfo dir, string partialName, IPrinter printer, int indentLevel)
        {
            try
            {
                DirectoryInfo[] subDirectories = dir.GetDirectories();

                FileInfo[] filesInDir = dir.GetFiles("*" + partialName);

                foreach (FileInfo foundFile in filesInDir)
                {
                    string fullName = foundFile.FullName;
                    Console.WriteLine($"{new string('\t', indentLevel)} {foundFile.FullName}");
                }

                foreach (DirectoryInfo d in subDirectories)
                {
                    FindFileInDirectory(d, partialName, printer, indentLevel + 1);
                }
            }
            catch (IOException e)
            {
                _logger.Fatal("FindFileInDirectory method", e.Message);
            }            
        }
    }
}
