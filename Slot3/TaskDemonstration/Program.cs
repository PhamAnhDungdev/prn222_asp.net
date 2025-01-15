namespace TaskDemonstration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";
            Task task01 = new Task(() => PrintNumber("Dung chao ban lan"));
            task01.Start();

            Task task02 = Task.Run(delegate
            {
                PrintNumber("Dung lai chao ban lan");
            });

            Task task03 = new Task(new Action(() =>
            {
                PrintNumber("Dung tiep tuc chao ban lan");
            }));
            task03.Start();
            Console.WriteLine($"Thread '{Thread.CurrentThread.Name}'");
            Console.ReadKey(); // Chờ người dùng ấn 1 phím bất kì.
        }

        static void PrintNumber(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.WriteLine($"{message}: {i}");
                Thread.Sleep(1000);
            }
        }
    }
}
