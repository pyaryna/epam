using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serialization
{
    class JsonSerializer<T> : ISerializer<T> where T : class  // package Newtonsoft.Json
    {
        public List<T> Collection;
        public string Path;       

        public JsonSerializer() { }
        public JsonSerializer(List<T> collection, string path)
        {
            Collection = collection;
            Path = path;
        }       

        public void Serialize()
        {
            string jsonFormatter = JsonConvert.SerializeObject(Collection);
            File.WriteAllText(Path, jsonFormatter);
        }
        public object Deserialize()
        {
            var result = File.ReadAllText(Path);
            var newCarsFromJson = JsonConvert.DeserializeObject<List<Car>>(result);

            return newCarsFromJson;
        }
    }
}
