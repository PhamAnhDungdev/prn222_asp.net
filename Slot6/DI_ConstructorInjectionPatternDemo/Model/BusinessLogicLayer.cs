using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_ConstructorInjectionPatternDemo.Model
{
    internal class BookManager
    {
        public IbookReader bookReader;

        public BookManager(IbookReader reader)
        {
            bookReader = reader;
        }

        public void ReadBooks()
        {
            bookReader.ReadBooks();
        }
    }
}
