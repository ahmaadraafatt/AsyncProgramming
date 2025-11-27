namespace CA1ThreadVsTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {

           var th =  new Thread(() => Display("Ahmed using Thread !!!"));
            th.Start();
            th.Join();

            Task.Run(() => Display("Ahmed using Task !!!")).Wait();
            Console.ReadKey();
        }
        static void Display(string name)
        {
            ShowThreadInfo(Thread.CurrentThread);

            Console.WriteLine(name);
        }

        private static void ShowThreadInfo(Thread Th)
        {
            Console.WriteLine($"Thread ID : {Th.ManagedThreadId} Thread is Pool : {Th.IsThreadPoolThread}  Thread is BackGround : {Th.IsBackground}");
        }
    }

    
}
