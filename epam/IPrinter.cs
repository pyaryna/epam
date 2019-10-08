using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam
{
    public interface IPrinter
    {
        void WriteLine(string value);
        string ReadLine();
    }
}
