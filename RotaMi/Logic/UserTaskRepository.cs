using RotaMi.Interfaces;
using RotaMi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;

namespace RotaMi.Logic
{
    public class UserTaskRepository : IRepository<User>
    {
        private string FilePath = @"C:\Users\mahad\OneDrive\Desktop\ChoreData.txt";
        public bool IsEmpty { get; set; }
        public void ReadData( out List<User> users )
        {
            users = new List<User>();

            string readData;
            try
            { 
                readData = File.ReadAllText(FilePath);
                users = JsonConvert.DeserializeObject<List<User>>(readData);
            }
            catch
            { 
                IsEmpty = true;
            }
           
        }

        public void WriteData(List<User> data)
        {
            var dataToWrite = JsonConvert.SerializeObject(data);
            File.WriteAllText(FilePath, dataToWrite);
        }

    }
}