namespace ExtinctionTextAdventure
{
    internal static class Program
    {
        private static void Main()
        {
            new Startup().Main().GetAwaiter().GetResult();
        }
    }
}