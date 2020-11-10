using System;
using System.Text.Json;
using StoreProject.Library.Order;
using System.IO;
using StoreProject.Library;

namespace StoreProject
{
    public class JsonFilePersistence
    {
        private readonly string _filePath;
        
        public JsonFilePersistence()
        {
        }

        /// <summary>
        /// Take info from 
        /// </summary>
        /// <returns>An Order object</returns>

        public Order ReadOrder()
        {
            //declare the json string
            string json;

            try
            {
                //Read the json data from the file at _filepath
                json = File.ReadAllText(_filePath);
            }
            catch(IOException)
            {
                return new Order("", "", "");
            }


            //Deserialze the string into an object of type Order
            Order data = JsonSerializer.Deserialize<Order>(json);

            //return the Order object that was created.
            return data;


        }

        public void WriteOrder(Order data)
        {

            ///Convert the data from Order class into a Serialzed string
            string json = JsonSerializer.Serialize(data);

            //This is to
            Console.WriteLine(json);

            //Write the json data to the file at _filePath
            //File.WriteAllText(_filePath, json);
        }


        public void WriteLocation(Location data)
        {
            string filePath = "../../../locationData.json";
            ///Convert the data from Order class into a Serialzed string
            string json = JsonSerializer.Serialize(data);


            //Write the json data to the file at _filePath
            //File.WriteAllText(filePath, json);
            File.AppendAllText(filePath, json);
        }
    }
}
