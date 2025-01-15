namespace TaskDemonstration03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<Double>[] taskArray =
            {
                Task<double>.Factory.StartNew(() => DoComputation(1.0)),
                Task<double>.Factory.StartNew(() => DoComputation(100.0)),
                Task<double>.Factory.StartNew(() => DoComputation(100.0)),
            };
            var results = new double[taskArray.Length];
            double sum = 0;
            for (int i = 0; i < taskArray.Length; i++)
            {
                results[i] = taskArray[i].Result;
                Console.WriteLine("{0:N1} {1}", results[i],
                    i == taskArray.Length - 1 ? "= " : "+ ");
                sum += results[i];
            }
            Console.WriteLine("{0:N1}", sum);
        }

        private static double DoComputation(double start)
        {
            double sum = 0;
            for ( var value = start; value <= start + 10; value += .1)
            {
                sum += value;
            }
            return sum;
        }
    }
}
