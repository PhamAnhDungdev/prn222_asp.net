namespace AsynchronousDemonstration02
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await callMethod();
            Console.ReadKey(); //Chờ người dùng ấn phím
        }

        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Method 1");
                    count += 1;
                }
            });
            return count;
        }

        public static void Method2()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method 2");
            }
        }

        public static void Method3(int count)
        {
            Console.WriteLine("Method 3 is called.");
            Console.WriteLine($"Total count is {count}");
        }

        public static async Task callMethod()
        {
            Method2();
            var count = await Method1();
            Method3(count);
        }
    }
}
