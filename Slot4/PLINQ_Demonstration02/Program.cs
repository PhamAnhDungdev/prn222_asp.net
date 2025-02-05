using System.Collections.Concurrent;
using System.Diagnostics;

namespace PLINQ_Demonstration02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var limit = 2_000_000;
            var numbers = Enumerable.Range(0, limit).ToList();

            var watch = Stopwatch.StartNew(); // Đo thời gian thực thi của đoạn mã
            var primeNumbersFromForEach = GetPrimeList(numbers);
            watch.Stop();

            var watchForParallel = Stopwatch.StartNew();
            var primeNumbersFromParallelForEach = GetPrimeListWithParallel(numbers);
            watchForParallel.Stop();

            Console.WriteLine($"Classical foreach loop | Total prime numbers: " +
                $"{primeNumbersFromForEach.Count} | Time Taken : " + 
                $"{watch.ElapsedMilliseconds} ms.");
            Console.WriteLine($"Parallel.foreach loop | Total prime numbers: " +
                $"{primeNumbersFromParallelForEach.Count} | Time Taken : " +
                $"{watchForParallel.ElapsedMilliseconds} ms.");

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static bool IsPrime(int number)
        {
            bool result = true;
            if (number < 2)
            {
                return false;
            }
            for (var i = 2; i <= Math.Sqrt(number) && result == true; i++)
            {
                if (number % i == 0)
                {
                    result = false;
                }
            }
            return result;
        }

        private static IList<int> GetPrimeList(IList<int> numbers) => numbers.Where(IsPrime).ToList();

        private static IList<int> GetPrimeListWithParallel(IList<int> numbers)
        {
            var primeNumbers = new ConcurrentBag<int>(); // Lập trình song song, tập lưu  trữ kiểu int và có các method để xử lí song song.
            Parallel.ForEach(numbers, number =>
            {
                if (IsPrime(number))
                {
                    primeNumbers.Add(number);
                }
            });
            return primeNumbers.ToList();
        }
    }
}
