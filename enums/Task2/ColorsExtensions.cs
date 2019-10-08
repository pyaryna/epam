using epam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enums.Task2
{
    static class ColorsExtensions
    {
        public static void PrintAscending(this Colors colors, IPrinter printer)
        {
            var colorsList = Enum.GetValues(typeof(Colors)).Cast<Colors>().ToList();

            var sortedColors = colorsList.OrderBy(c => (int)c);

            foreach (var c in sortedColors)
                printer.WriteLine($"{(int)c} - {c.ToString()}");
        }        
    }
}
