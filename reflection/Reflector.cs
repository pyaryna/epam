using logger;
using printer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace reflection
{
    class Reflector: IReflector
    {
        public Assembly Assembly { get; set; }
        ConsolePrinter _printer;
        Logger _logger;

        public Reflector() { }
        public Reflector(string assemblyName, ConsolePrinter printer, Logger logger)
        {
            _printer = printer;
            _logger = logger;
            try
            {
                Assembly = Assembly.Load(assemblyName);
                _printer.WriteLine("Assembly loaded successfully");
                _printer.WriteLine(Assembly.FullName);
            }
            catch (FileNotFoundException e)
            {
                _logger.WriteMessage("!!!LOG: " + e.Message);
            }
        }

        public void ListAllTypes()
        {
            _printer.WriteLine("\nList of all types of assembly:\n");
            try
            {
                Type[] types = Assembly.GetTypes();
                foreach (Type t in types)
                    _printer.WriteLine(t.Name);
            }
            catch(NullReferenceException e)
            {
                _logger.WriteMessage("!!!LOG: " + e.Message);
            }            

            _printer.WriteLine(new string('-', 20));
        }

        public void ListAllMembers(string className)
        {
            _printer.WriteLine("\nList of all members of assembly class:\n");

            try
            {
                Type type = Assembly.GetType(Assembly.GetName().Name + "." + className);

                _printer.WriteLine(type.ToString());

                MemberInfo[] members = type.GetMembers();

                foreach (MemberInfo item in members)
                    _printer.WriteLine($"\t{item.MemberType}: {item}");
            }
            catch (NullReferenceException e)
            {
                _logger.WriteMessage("!!!LOG: " + e.Message);
            }            

            _printer.WriteLine(new string('-', 20));
        }

        public void GetParams(string className, string methodName)
        {
            try
            {
                Type type = Assembly.GetType(Assembly.GetName().Name + "." + className);
                MethodInfo method = type.GetMethod(methodName);

                _printer.WriteLine("\nassembly name: " + Assembly.GetName().Name + "\nclass name: " + className + "\nmethod name: " + method.Name);

                ParameterInfo[] parameters = method.GetParameters();

                _printer.WriteLine("Amount of parameters: " + parameters.Length.ToString());

                foreach (var p in parameters)
                {
                    _printer.WriteLine("name: " + p.Name);
                    _printer.WriteLine("position: " + p.Position.ToString());
                    _printer.WriteLine("parameter type: " + p.ParameterType.ToString());
                }
            }
            catch (NullReferenceException e)
            {
                _logger.WriteMessage("!!!LOG: " + e.Message);
            }            

            _printer.WriteLine(new string('-', 20));
        }

    }
}
