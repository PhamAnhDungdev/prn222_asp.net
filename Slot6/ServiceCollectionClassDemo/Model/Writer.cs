using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCollectionClassDemo.Model
{
    internal class XMLWriter : IXMLWriter
    {
        public void WriteXML()
        {
            Console.WriteLine("<message>Writing in XML Format</message>");
        }
    }
    internal class JSONWriter : IJSONWriter
    {
        public void WriteJSON()
        {
            Console.WriteLine("{'message': 'Writing in JSON Format' }");
        }
    }
}
