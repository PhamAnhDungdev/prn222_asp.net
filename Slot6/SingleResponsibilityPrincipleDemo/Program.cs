using Newtonsoft.Json;
using SingleResponsibilityPrincipleDemo.Model;

namespace SingleResponsibilityPrincipleDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List of books");
            Console.WriteLine(new string('=', 30));
            var cadJson = File.ReadAllText("Data/BookStore.json");
            var bookList = JsonConvert.DeserializeObject<Book[]>(cadJson); // Parse Text => Json<Book>
            foreach (var book in bookList)
            {
                Console.WriteLine($"{book.Title.PadRight(39, ' ')} " + $"{book.Author.PadRight(20, ' ')} {book.Price}");
            }
            Console.Read();
        }
    }
}
