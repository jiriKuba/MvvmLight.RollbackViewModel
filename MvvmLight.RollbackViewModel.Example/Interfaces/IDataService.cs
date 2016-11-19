using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight.RollbackViewModel.Example.Interfaces
{
    interface IDataService
    {
        /// <summary>
        /// Serialization object to file
        /// </summary>
        void SaveObjectAsXmlToFile(ISerializable toSerial, String filePath);

        /// <summary>
        /// Deserialization object from file
        /// </summary>
        T LoadObjectAsXmlFromFile<T>(String filePath) where T : ISerializable;

        /// <summary>
        /// Deserialization object from fileStream
        /// </summary>
        T LoadObjectAsXmlFromStream<T>(System.IO.Stream fileStream) where T : ISerializable;
    }
}
