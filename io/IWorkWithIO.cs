using printer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace io
{
    interface IWorkWithIO
    {
        void GetFilesTree(DirectoryInfo dir, IPrinter printer, int indentLevel);

        void FindFileInDirectory(DirectoryInfo dir, string partialName, IPrinter printer, int indentLevel);
    }
}
