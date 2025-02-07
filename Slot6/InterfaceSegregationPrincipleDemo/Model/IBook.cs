using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrincipleDemo.Model
{
    internal interface IBook
    {
        string Title { get; set; }
        string Author { get; set; }
        double Price { get; set; }
    }

    internal interface ITopic
    {
        string Topic { get; set; }
    }

    internal interface IDuration
    {
        string Duration { get; set; }
    }
}
