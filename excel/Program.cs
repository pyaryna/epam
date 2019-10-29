using NLog;
using printer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excel
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter printer = new ConsolePrinter();
            Logger logger = LogManager.GetCurrentClassLogger();
            NameValueCollection settings = ConfigurationManager.AppSettings;
            Stopwatch stopwatch = new Stopwatch();

            Excel excelFile = new Excel();
            List<int> dataFromFile = null;

            try
            {
                stopwatch.Start();
                dataFromFile = excelFile.ReadFile(settings["fileToRead"], 1,
                (settings["columnsToRead"].Split(',').Select(Int32.Parse)).ToList());
                stopwatch.Stop();
                printer.WriteLine($"ReadFile, Elapsed={stopwatch.ElapsedMilliseconds}");   
            }
            catch(InvalidCastException e)
            {
                logger.Fatal("ReadFile" + e.Message);
            }
            catch (NullReferenceException e)
            {
                logger.Fatal(e.Message);
            }

            switch (settings["printResult"])
            {
                case "file":
                    try
                    {                        
                        stopwatch.Restart();
                        excelFile.WriteIntoFile("E:\\me\\epam\\epam\\excel\\bin\\Debug\\result.xlsx", 1, dataFromFile, Int32.Parse(settings["columnToWrite"]));
                        stopwatch.Stop();
                        printer.WriteLine($"WriteIntoFile, Elapsed={stopwatch.ElapsedMilliseconds}");
                    }
                    catch (InvalidCastException e)
                    {
                        logger.Fatal("WriteIntoFile" + e.Message);
                    }
                    break;

                case "console":
                    foreach (var number in dataFromFile)
                        printer.WriteLine(number.ToString());
                    break;
            }          

            printer.ReadLine();
        }
    }
}
