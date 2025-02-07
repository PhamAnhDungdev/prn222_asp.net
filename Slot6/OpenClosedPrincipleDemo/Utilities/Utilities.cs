using OpenClosedPrincipleDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OpenClosedPrincipleDemo.Utilities
{
    internal class Utilities
    {
        static string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
        
        internal static List<Book> ReadData()
        {
            var cadJson = File.ReadAllText("Data/BookStore_01.json");
            return JsonConvert.DeserializeObject<List<Book>>(cadJson);
        }

        internal static List<Book> ReadDataExtra()
        {
            List<Book> books =  ReadData();
            var cadJson = ReadFile("Data/BookStore_02.json");
            books.AddRange(JsonConvert.DeserializeObject<List<Book>>(cadJson));
            return books;
        }
    }
}
