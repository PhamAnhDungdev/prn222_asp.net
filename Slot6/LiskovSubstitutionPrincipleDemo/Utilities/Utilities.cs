using LiskovSubstitutionPrincipleDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LiskovSubstitutionPrincipleDemo.Utilities
{
    internal class Utilities
    {
        static string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
        
        internal static List<Book> ReadData()
        {
            var cadJson = File.ReadAllText("Data/BookStore.json");
            return JsonConvert.DeserializeObject<List<Book>>(cadJson);
        }

        internal static List<Book> ReadData(string Extra)
        {
            List<Book> books =  ReadData();
            string filename = "Data/BookStore2.json";
            var cadJson = ReadFile(filename);
            books.AddRange(JsonConvert.DeserializeObject<List<Book>>(cadJson));
            if (Extra == "topic")
            {
                filename = "Data/BookStore3.json";
                cadJson = ReadFile(filename);
                books.AddRange(JsonConvert.DeserializeObject<List<Book>>(cadJson));
            }
            return books;
        }
    }
}
