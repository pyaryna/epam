using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class CalculatorFilePrinter: ICalculatorPrinter
    {
        public string PathToFileToRead { get; set; }
        public string PathToFileToWrite { get; set; }

        Logger _logger = LogManager.GetCurrentClassLogger();

        public CalculatorFilePrinter(){}

        public CalculatorFilePrinter(string readPath, string writePath)
        {
            PathToFileToRead = readPath;
            PathToFileToWrite = writePath;
        }
        public void WriteLine(string value)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(PathToFileToWrite))
                {
                    file.WriteLine("result = " + value);
                }
            }
            catch (IOException e)
            {
                _logger.Fatal("Reading file " + e.Message);
            }
            
        }
        public string ReadLine()
        {
            try
            {
                using (StreamReader file = new StreamReader(PathToFileToRead))
                {
                    return file.ReadLine();
                }
            }
            catch(IOException e)
            {
                _logger.Fatal("Reading file " + e.Message);
                return "";
            }
        }
    }
}
