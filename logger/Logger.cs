using printer;
using System;

namespace logger
{
    public class Logger: ILogger
    {
        private IPrinter _printer;
        private LogLevel _level;
        private string _message;

        public Logger() { }

        public Logger(IPrinter printer)
        {
            _printer = printer;
        }

        public void Configuration(IPrinter printer, LogLevel level, Exception exception)
        {
            _printer = printer;
            _level = level;
            _message = _level.ToString() + " | " + exception.Message;
        }

        public void WriteMessage(string message)
        {
            _printer.WriteLine(message);           
        }

        public string ReadMessage()
        {
            if (_printer is ConsolePrinter)
                throw new NotImplementedException("Console does not support reading");
            return _printer.ReadLine();
        }
    }
}
