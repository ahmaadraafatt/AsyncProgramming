namespace CA2TaskReturnsValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<DateTime> time = Task.Run(GetDateTime);
            //Console.WriteLine(time.Result); //Block Thread until Result is Ready

            Console.WriteLine(time.GetAwaiter().GetResult());
            Console.ReadKey();
        }
        static DateTime GetDateTime() => DateTime.Now;
    }
}
