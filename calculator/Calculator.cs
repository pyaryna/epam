using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class Calculator
    {
        public double A { get; set; }

        public double B { get; set; }

        public string Operation { get; set; }

        ICalculatorPrinter _printer;

        Logger _logger = LogManager.GetCurrentClassLogger();

        public Calculator(){}

        public Calculator(ICalculatorPrinter printer)
        {
            _printer = printer;
        }

        public double Calculate()
        {
            try
            {
                switch (Operation)
                {
                    case "+":
                        return Add(A, B);
                    case "-":
                        return Substract(A, B);
                    case "*":
                        return Multiply(A, B);
                    case "/":
                        return Divide(A, B);
                    default:
                        throw new ArgumentException();
                }
            }
            catch(ArgumentException e)
            {
                _logger.Fatal(e.Message);
                return 0;
            }
        }
        public double Add(double a, double b)
        {
            return a + b;
        }
        public double Substract(double a, double b)
        {
            return a - b;
        }
        public double Multiply(double a, double b)
        {
            return a * b;
        }
        public double Divide(double a, double b)
        {
            try
            {
                return a / b;
            }
            catch (DivideByZeroException e)
            {
                _logger.Fatal(e.Message);
                return 0;
            }
        }

        public void WriteResult(double value)
        {
            _printer.WriteLine(value.ToString());
        }
        public void ReadExpression() 
        { 
            Parse(_printer.ReadLine());
        }

        private void Parse(string expression)
        {            
            var operands = expression.Split(',');
            try
            {
                A = Double.Parse(operands[0]);
                B = Double.Parse(operands[1]);
                Operation = operands[2];
            }
            catch(FormatException e)
            {
                _logger.Fatal(e.Message);
            }            
        }
    }
}
