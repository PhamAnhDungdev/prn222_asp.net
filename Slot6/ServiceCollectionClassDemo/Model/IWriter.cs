using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCollectionClassDemo.Model
{
    public interface IXMLWriter
    {
        void WriteXML();


    }
    public interface IJSONWriter
    {
        void WriteJSON();
    }
}
