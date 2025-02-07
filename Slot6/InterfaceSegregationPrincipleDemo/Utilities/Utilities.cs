using InterfaceSegregationPrincipleDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
namespace InterfaceSegregationPrincipleDemo.Utilities

{
    internal class Utilities
    {
        internal static List<Video> ReadData(string fileId)
        {
            var filename = "Data/BookStore" + fileId + "./json";
            var cadJson = ReadFile(filename);
            return JsonConvert.DeserializeObject<List<Video>>(cadJson);
        }

        internal static string ReadFile(string filename)
        {
            return File.ReadAllText(filename);
        }
        
        
    }
}
