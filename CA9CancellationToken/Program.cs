namespace CA9CancellationToken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            //DoCancellation01(cancellationTokenSource);
            //DoCancellation02(cancellationTokenSource);
            DoCancellation03(cancellationTokenSource);
            Console.ReadKey();
        }
        static async Task DoCancellation01(CancellationTokenSource cancellationTokenSource)
        {
            Task.Run(() =>
            {
                var input = Console.ReadKey();
                if(input.Key == ConsoleKey.Q)
                {
                    cancellationTokenSource.Cancel();
                    Console.WriteLine(" Task has been cancel ");
                }
            });

            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                Console.Write(" Checking... ");
                await Task.Delay(4000);
                Console.WriteLine($" Completed on {DateTime.Now}");
            }
            Console.WriteLine(" Check was termenated");
            cancellationTokenSource.Dispose();
        }
        static async Task DoCancellation02(CancellationTokenSource cancellationTokenSource)
        {
            Task.Run(() =>
            {
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Q)
                {
                    cancellationTokenSource.Cancel();
                    Console.WriteLine(" Task has been cancel ");
                }
            });

            while (true)
            {
                Console.Write(" Checking... ");
                await Task.Delay(4000,cancellationTokenSource.Token);
                Console.WriteLine($" Completed on {DateTime.Now}");
            }
            Console.WriteLine(" Check was termenated");
            cancellationTokenSource.Dispose();
        }

        static async Task DoCancellation03(CancellationTokenSource cancellationTokenSource)
        {
            Task.Run(() =>
            {
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Q)
                {
                    cancellationTokenSource.Cancel();
                    Console.WriteLine(" Task has been cancel ");
                }
            });


            try
            {
                while (true)
                {
                    cancellationTokenSource.Token.ThrowIfCancellationRequested();
                    Console.Write(" Checking... ");
                    await Task.Delay(4000);
                    Console.WriteLine($" Completed on {DateTime.Now}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(" Check was termenated");
            cancellationTokenSource.Dispose();
        }
    }
}
