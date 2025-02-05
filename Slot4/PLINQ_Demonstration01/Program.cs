namespace PLINQ_Demonstration01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var range = Enumerable.Range(1, 1000_000);
            var resultList = range.Where(i => i % 3 == 0).ToList(); // Dùng LINQ thông thường
            Console.WriteLine($"Sequential: Total items are {resultList.Count}");
            resultList = range.AsParallel().Where(i => i % 3 == 0).ToList(); // Dùng thư viện song song làm nhiều đoạn để chạy nhanh hơn. //Method syntax
            Console.WriteLine($"Parallel: Total items are {resultList.Count}");
            resultList = (from i in range.AsParallel() // Cùng dùng tương tự. Query syntax // Giống với SQL
                          where i % 3 == 0
                          select i
            ).ToList();
            Console.WriteLine($"Parallel: Total items are {resultList.Count}");
            Console.ReadLine();
        }
    }
}
