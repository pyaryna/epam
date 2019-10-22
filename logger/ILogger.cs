using System;
using System.Collections.Generic;
using System.Text;

namespace logger
{
    interface ILogger
    {
        void WriteMessage(string message);
        string ReadMessage();
    }
}
