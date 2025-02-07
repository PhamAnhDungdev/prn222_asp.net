using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipleDemo.Model
{
    public class Book : IBook
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
    }

    public class TopicBook : IBook
    {
        public string Topic { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
    }
}
