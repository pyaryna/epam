using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace serialization
{
    class BinarySerializer<T> : ISerializer<T> where T : class
    {
        public List<T> Collection;
        public string Path;

        BinaryFormatter _dataFormatter = new BinaryFormatter();

        public BinarySerializer() { }
        public BinarySerializer(List<T> collection, string path)
        {
            Collection = collection;
            Path = path;
        }

        public void Serialize()
        {
            using (FileStream fs = new FileStream(Path, FileMode.Create))
            {
                _dataFormatter.Serialize(fs, Collection);
            }
        }
        public object Deserialize()
        {
            List<T> newCarsFromData;

            using (FileStream fs = new FileStream(Path, FileMode.Open))
            {
                newCarsFromData = _dataFormatter.Deserialize(fs) as List<T>;
            }

            return newCarsFromData;
        }
    }
}
