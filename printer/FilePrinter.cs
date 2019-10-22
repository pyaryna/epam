using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace printer
{
    public class FilePrinter: IPrinter
    {
        string _path;

        public FilePrinter() { }

        public FilePrinter(string path)
        {
            _path = path;
        }
        public void WriteLine(string value)
        {
            using (StreamWriter file = new StreamWriter(_path))
            {
                file.WriteLine(value);
            }
        }
        public string ReadLine()
        {
            using (StreamReader file = new StreamReader(_path))
            {
                return file.ReadLine();                
            }
        }
    }
}
