namespace CA6TaskDelay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DelayusingTask(5000);
            SleepwithThread(5000);
            Console.ReadKey();
        }
        static void DelayusingTask(int ms)
        {
            Task.Delay(ms).GetAwaiter().OnCompleted(() => {
                Console.WriteLine($"Completed After using Task.Delay({ms})");
            });
        }
        static void SleepwithThread(int ms)
        {
            Thread.Sleep(ms);
            Console.WriteLine($"Completed After using Thread.Sleep({ms})");

        }
    }
}
