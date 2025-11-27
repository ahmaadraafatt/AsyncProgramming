namespace CA12ConcurrencyAndParallelism
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var things = new List<DailyDuty>
           {
               new DailyDuty("Cleanning House"),
               new DailyDuty("pray the five"),
               new DailyDuty("learning English"),
               new DailyDuty("learning programming"),
               new DailyDuty("Coding")
           };

            Console.WriteLine("Usign Parallel");
            await ProcessThingsInParallel(things);

            Console.WriteLine("Usign Concurrent");
            await ProcessThingsInConcurrent(things);
        }

        static Task ProcessThingsInParallel(IEnumerable<DailyDuty> things)
        {
            Parallel.ForEach(things, thing => thing.Process());
            return Task.CompletedTask;
        }
        static Task ProcessThingsInConcurrent(IEnumerable<DailyDuty> things)
        {
            foreach (var thing in things)
            {
                thing.Process();
            }

            return Task.CompletedTask;
        }


        class DailyDuty
        {
            public string title { get; private set; }
            public bool Processed { get; private set; }
            public DailyDuty(string title)
            {
                this.title = title;
            }
            public void Process()
            {
                Console.WriteLine($"TID: {Thread.CurrentThread.ManagedThreadId}," +
                    $"ProcessorId: {Thread.GetCurrentProcessorId()}");
                Task.Delay(100).Wait();
                this.Processed = true;
            }
        }
    }
}
