using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam.Task2
{
    interface ISize
    {
        int Width { get; set; }
        int Height { get; set; }

        int Perimeter();
    }
}
