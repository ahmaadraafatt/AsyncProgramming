namespace CA3LongRunningTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var task = Task.Factory.StartNew(() => RunLongTask(),
                TaskCreationOptions.LongRunning);
            Console.ReadKey();
        }

        private static void RunLongTask()
        {
            Thread.Sleep(3000);
            ShowThreadInfo(Thread.CurrentThread);
            Console.WriteLine("Completed");
        }
        static void ShowThreadInfo(Thread Th)
        {
            Console.WriteLine($"Thread ID : {Th.ManagedThreadId} Thread is Pool : {Th.IsThreadPoolThread}  Thread is BackGround : {Th.IsBackground}");
        }
    }
}
