namespace CA11TaskCompinators
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var Has1000SubscribeTask = Task.Run(() => Has1000Subscribes());
            var Has4000ViewHoursTask = Task.Run(() => Has4000ViewHours());
            Console.WriteLine("using WhenAny");
            Console.WriteLine("=-=-=-=--=-=-=-=");

            var any = await Task.WhenAny(Has1000SubscribeTask, Has4000ViewHoursTask);
            Console.WriteLine(any.Result);

            Console.WriteLine("using WhenAll");
            Console.WriteLine("=-=-=-=--=-=-=-=");

            var all = await Task.WhenAll(Has1000SubscribeTask, Has4000ViewHoursTask);
            foreach (var item in all)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
        static Task<string> Has1000Subscribes()
        {
            Task.Delay(4000).Wait();
            return Task.FromResult("Congratulation You Got 1000 Subscribes");
        }
        static Task<string> Has4000ViewHours()
        {
            Task.Delay(4000).Wait();
            return Task.FromResult("Congratulation You Got 4000 View Hours");
        }
    }
}
