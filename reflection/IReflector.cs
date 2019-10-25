using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace reflection
{
    interface IReflector
    {
        void ListAllTypes();

        void ListAllMembers(string className);

        void GetParams(string className, string methodName);
    }
}
