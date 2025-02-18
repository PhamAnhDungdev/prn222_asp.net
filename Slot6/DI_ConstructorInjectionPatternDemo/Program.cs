using DI_ConstructorInjectionPatternDemo.Model;

namespace DI_ConstructorInjectionPatternDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookManager bm;
            Console.WriteLine("Please select type: ");
            var ans = Console.ReadLine();
            if(ans.ToLower().Contains("xml"))
            {
                bm = new BookManager(new XMLBookReader());
            } else
            {
                bm = new BookManager(new JSONBookReader());
            }
            bm.ReadBooks();
            Console.ReadLine();
        }
    }
}
