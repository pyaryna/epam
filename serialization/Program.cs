using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using printer;

namespace serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter printer = new ConsolePrinter();

            var cars = new List<Car>()
            {
                new Car(1, 5000, 5),
                new Car(2, 10000, 4),
                new Car(3, 15000, 3),
                new Car(4, 20000, 2),
                new Car(5, 25000, 1),
            };

            string path = "cars";

            #region XML

            printer.WriteLine("XMLSerializarion\n");

            XMLSerializer<Car> xmlFormatter = new XMLSerializer<Car>(cars, path + ".xml");
            xmlFormatter.Serialize();
            var newCarsFromXml = xmlFormatter.Deserialize() as List<Car>;

            foreach(var c in newCarsFromXml)
            {
                printer.WriteLine(c.ToString());                    
            }

            #endregion

            printer.WriteLine(new string('-', 20));

            #region Binary

            printer.WriteLine("\nBinarySerializarion\n");

            BinarySerializer<Car> dataFormatter = new BinarySerializer<Car>(cars, path + ".data");
            dataFormatter.Serialize();
            var newCarsFromBinary = dataFormatter.Deserialize() as List<Car>;

            foreach (var c in newCarsFromBinary)
            {
                printer.WriteLine(c.ToString());
            }

            #endregion

            printer.WriteLine(new string('-', 20));

            #region Json

            printer.WriteLine("\nJsonSerializarion\n");

            JsonSerializer<Car> jsonFormatter = new JsonSerializer<Car>(cars, path + ".json");
            jsonFormatter.Serialize();
            var newCarsFromJson = jsonFormatter.Deserialize() as List<Car>;

            foreach (var c in newCarsFromJson)
            {
                printer.WriteLine(c.ToString());
            }

            #endregion

            Console.ReadLine();
        }
    }
}
