using LiskovSubstitutionPrincipleDemo.Model;
using LiskovSubstitutionPrincipleDemo.Utilities;

namespace LiskovSubstitutionPrincipleDemo
{
    internal class Program
    {
        static List<Book> bookList;

        static void PrintBooks(List<Book> bookList)
        {
            Console.WriteLine("List of books");
            Console.WriteLine(new string('*', 20));
            foreach (var book in bookList)
            {
                Console.WriteLine($"{book.Title.PadRight(39, ' ')}" +
                    $"{book.Author.PadRight(20, ' ')} {book.Price}");
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please,  press 'yes' to read an extra file, ");
            Console.WriteLine("'topic' to include topic book or any other key for a single file");
            var ans = Console.ReadLine();
            bookList = (ans.ToLower() != "yes" && ans.ToLower() != "topic") ? Utilities.Utilities.ReadData() : Utilities.Utilities.ReadData(ans);
            PrintBooks(bookList);
        }
    }
}
