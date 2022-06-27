namespace ExtinctionTextAdventure
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new Startup().Main().GetAwaiter().GetResult();
        }
    }
}