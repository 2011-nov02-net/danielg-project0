using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using StoreProject.Library;

namespace StoreProject
{
    public class XMLFilePersistence
    {

        public XMLFilePersistence()
        {
        }

        public void LocationToXML(Location data)
        {
            try
            {
                string filePath = "../../../locationData.txt";

                FileStream writer = new FileStream(filePath, FileMode.OpenOrCreate);
                DataContractSerializer ser = new DataContractSerializer(typeof(Location));
                ser.WriteObject(writer, data);
                writer.Close();

            }
            catch
            {
                throw;
            }
        }

        public void XMLToLocation()
        {
            string filePath = "../../../locationData.txt";
            FileStream fs = new FileStream(filePath, FileMode.Open);

        }

    }
}
