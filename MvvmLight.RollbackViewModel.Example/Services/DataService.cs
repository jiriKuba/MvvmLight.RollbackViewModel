using MvvmLight.RollbackViewModel.Example.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight.RollbackViewModel.Example.Services
{
    class DataService : IDataService
    {
        public DataService()
        { }

        public void SaveObjectAsXmlToFile(ISerializable toSerial, String filePath)
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(toSerial.GetType());
            using (System.IO.TextWriter file = new System.IO.StreamWriter(filePath))
            {
                writer.Serialize(file, toSerial);
            }
        }

        public T LoadObjectAsXmlFromFile<T>(String filePath) where T : ISerializable
        {
            System.Xml.Serialization.XmlSerializer deserializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (System.IO.TextReader reader = new System.IO.StreamReader(filePath))
            {
                return (T)deserializer.Deserialize(reader);
            }
        }

        public T LoadObjectAsXmlFromStream<T>(System.IO.Stream fileStream) where T : ISerializable
        {
            System.Xml.Serialization.XmlSerializer deserializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (System.IO.TextReader reader = new System.IO.StreamReader(fileStream))
            {
                return (T)deserializer.Deserialize(reader);
            }
        }
    }
}