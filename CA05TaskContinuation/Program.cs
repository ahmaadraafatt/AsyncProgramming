using System.Threading.Channels;

namespace CA5TaskContinuation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(CountPrimeNumberInRange(2, 2_000_000));
            Task<int> task = Task.Run(() => CountPrimeNumberInRange(2, 3_000_000));
            //Console.WriteLine(task); // BAD !! Couse its BLOCK the Threads

            Console.WriteLine("using , OnCompleted");
            var awaiter = task.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine(awaiter.GetResult());
            });

            Console.WriteLine("Ahmed will be a fullStack Developer");

            Console.WriteLine("using Task Countiuewith");
            task.ContinueWith((x) => Console.WriteLine(x.Result));
            Console.ReadKey();
        }
        static int CountPrimeNumberInRange(int min, int max)
        {
            var result = 0;
            for (int i = min; i <= max; i++)
            {
                var isprime = true;
                var j = 2;
                while (j <= (int)Math.Sqrt(i))
                {
                    if (i % j == 0)
                    {
                        isprime = false;
                        break;
                    }
                    ++j;
                }
                    if (isprime)
                        result++;   
            }
            return result;
        }
    }
}
