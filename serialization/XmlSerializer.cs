using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace serialization
{
    class XMLSerializer<T>: ISerializer<T> where T : class
    {
        public List<T> Collection;
        public string Path;

        XmlSerializer _xmlFormatter = new XmlSerializer(typeof(List<T>));

        public XMLSerializer() { }
        public XMLSerializer(List<T> collection, string path)
        {
            Collection = collection;
            Path = path;
        }

        public void Serialize()
        {        
            using (StreamWriter fs = new StreamWriter(Path))
            {
                _xmlFormatter.Serialize(fs, Collection);
            }
        }
        public object Deserialize()
        {
            List<T> newCarsFromXml;

            using (StreamReader fs = new StreamReader(Path))
            {
                newCarsFromXml = _xmlFormatter.Deserialize(fs) as List<T>;
            }

            return newCarsFromXml;
        }
    }
}
