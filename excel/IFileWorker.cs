using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excel
{
    interface IFileWorker
    {
        List<int> ReadFile(string path, int sheetAmount, List<int> columns);

        void WriteIntoFile(string path, int sheetAmount, List<int> numbers, int column);
    }
}
