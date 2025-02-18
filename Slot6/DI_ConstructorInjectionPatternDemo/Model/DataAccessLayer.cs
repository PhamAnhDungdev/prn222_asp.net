using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_ConstructorInjectionPatternDemo.Model
{
    internal interface IbookReader
    {
        void ReadBooks();
    }
    public class XMLBookReader : IbookReader
    {
        public void ReadBooks()
        {
            Console.WriteLine("Books read in XML format");
        }
    }
    public class JSONBookReader : IbookReader
    {
        public void ReadBooks()
        {
            Console.WriteLine("Books read in JSON format");
        }
    }
}
