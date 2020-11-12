using System;
using System.Text.Json;
using StoreProject.Library.Order;
using System.IO;
using StoreProject.Library;
using System.Collections.Generic;
//using Newtonsoft.Json;

namespace StoreProject
{
    public class JsonFilePersistence
    {
        private readonly string _filePath;
        
        public JsonFilePersistence()
        {
        }


        public void WriteStrings(List<string> words)
        {
            string filePath = "../../../wordData.json";
            string json = JsonSerializer.Serialize(words);

            File.WriteAllText(filePath, json);
        }


        public List<string> ReadStrings()
        {
            string filePath = "../../../wordData.json";
            string json = File.ReadAllText(filePath);
            List<string> words = JsonSerializer.Deserialize<List<string>>(json);
            return words;
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
                return new Order("", "", 0);
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


        public void WriteLocation(List<Location> data)
        {
            string filePath = "../../../locationData.json";
            ///Convert the data from Order class into a Serialzed string
            string json = JsonSerializer.Serialize(data);
            //Is this gonna work

            //string json1 = Newtonsoft.Json.JsonConvert.SerializeObject<Location>(data);

            //Write the json data to the file at _filePath
            File.WriteAllText(filePath, json);
            
        }


        public List<Location> ReadLocation()
        {
            string filePath = "../../../locationData.json";
            ///Convert the data from Order class into a Serialzed string
            string json;
           
            try
            {
                json = File.ReadAllText(filePath);
            }
            catch (IOException)
            {
               
                return new List<Location>();
            }


            List<Location> locations = JsonSerializer.Deserialize<List<Location>>(json);



            return locations;
        }
    }
}
