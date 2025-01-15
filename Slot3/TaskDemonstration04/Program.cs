namespace TaskDemonstration04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tasks = new List<Task<int>>();
            var source = new CancellationTokenSource();
            var token = source.Token;
            int completedIterations = 0;

            for (int n = 0; n < 20; n++)
            {
                tasks.Add(Task.Run(() =>
                {
                    int iterations = 0;
                    for (int ctr = 1; ctr <= 2_000_000; ctr++)
                    {
                        token.ThrowIfCancellationRequested();
                        iterations++;
                    }
                    Interlocked.Increment(ref completedIterations);
                    if ( completedIterations >= 10)
                    {
                        source.Cancel();
                    }
                    return iterations;
                }));
            }

            Console.WriteLine("Waiting for the first 10 tasks to complete...\n");
            try
            {
                Task.WaitAll(tasks.ToArray());
            } catch (AggregateException ex)
            {
                Console.WriteLine("Status of tasks: \n");
                Console.WriteLine("{10,20} {1,20} {2,14:10}", "Task Id", "Status" , "Iterations");
                foreach (var t in tasks)
                {
                    Console.WriteLine("{0,10} {1,20} {2,14}", t.Id, t.Status, t.Status != TaskStatus.Canceled ? t.Result.ToString("NO") : "n/a");
                }
            }
            Console.ReadLine();
        }
    }
}
