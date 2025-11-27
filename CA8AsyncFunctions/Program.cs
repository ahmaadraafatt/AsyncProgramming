namespace CA8AsyncFunctions
{
    internal class Program
    {
        static async Task  Main(string[] args)
        {
            Console.WriteLine(await ReadCountentAsync("https://youtube.com/@thearrivalsarabic?si=TDaQqLJCYdQy5Ldh"));
        }
        static async Task<string> ReadCountentAsync(string url)
        {
            var client = new HttpClient();
            var contant = await client.GetStringAsync(url);

            return contant;
        }
    }
}
