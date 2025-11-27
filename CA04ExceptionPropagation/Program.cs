namespace CA4ExceptionPropagation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // == 1 ==
            //try
            //{
            //    var th = new Thread(throwExption);
            //    th.Start();
            //    th.Join();
            //}
            //catch
            //{
            //    Console.WriteLine("Exption Thrown!!!");
            //}

            // == 2 ==  
            //var th = new Thread(ThrowExptionWithTryCatch);
            //th.Start();
            //th.Join();

            // == 3 == With task to catch in main method Thread
            try
            {
                Task.Run(throwExption).Wait();
            }
            catch 
            {
                Console.WriteLine("Exption Thrown!!!");
            }

            Console.ReadKey();
        }
        static void throwExption()
        {
            throw new NullReferenceException();  
        }
        //static void ThrowExptionWithTryCatch()
        //{
        //    try
        //    {
        //        throw new NullReferenceException();
        //    }
        //    catch 
        //    {
        //        Console.WriteLine("Exption Thrown!!!");
        //    }
        //}
    }
}
