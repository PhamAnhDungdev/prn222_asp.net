using InterfaceSegregationPrincipleDemo.Model;

namespace InterfaceSegregationPrincipleDemo
{
    internal class Program
    {
        static List<Video> bookList;

        static void PrintBooks(List<Video> bookList)
        {
            Console.WriteLine("List of books");
            Console.WriteLine(new string('*', 20));
            foreach (var book in bookList)
            {
                Console.WriteLine($"{book.Title.PadRight(39, ' ')}" +
                    $"{book.Author.PadRight(20, ' ')} {book.Price}" + " " +
                    $"{book.Topic?.PadRight(12,' ')}" + 
                    $"{book.Duration ?? ""}");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {

            String id = string.Empty;
            Console.Title = "Interfae Segregation Principle Demo";
            do
            {
                Console.Write("File no, to read: 1/2/3 - Enter(exit): ");
                id = Console.ReadLine();
                if ("123".Contains(id) && !string.IsNullOrEmpty(id))
                {
                    bookList = Utilities.Utilities.ReadData(id);
                    PrintBooks(bookList);
                }
                } while ( !string.IsNullOrEmpty( id ) );
        }
    }
}
