using System;
using System.Collections.Generic;
using System.Text;

namespace printer
{
    public interface IPrinter
    {
        void WriteLine(string value);
        string ReadLine();
    }
}
