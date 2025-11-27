namespace CA7AsyncVsSync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowThreadInfo(Thread.CurrentThread, 7);
            CallSynchrounous();

            ShowThreadInfo(Thread.CurrentThread, 10);
            CallAsynchrounous();

            ShowThreadInfo(Thread.CurrentThread, 13);

            Console.ReadKey();
        }
        static void CallAsynchrounous()
        {
            ShowThreadInfo(Thread.CurrentThread, 19);
            Task.Delay(4000).GetAwaiter().OnCompleted(() => {
                ShowThreadInfo(Thread.CurrentThread, 25);
                Console.WriteLine("============ ASYNCHROUNOUS ============"); });
        }
        static void CallSynchrounous()
        {
            Thread.Sleep(4000);
            ShowThreadInfo(Thread.CurrentThread, 25);
            Task.Run(() => Console.WriteLine("============ SYNCHROUNOUS ============")).Wait();
        }
        static void ShowThreadInfo(Thread Th, int line)
        {
            Console.WriteLine($"#Line : {line} Thread ID : {Th.ManagedThreadId} Pool {Th.IsThreadPoolThread} BackGround : {Th.IsBackground} ");
        }
    }
}
